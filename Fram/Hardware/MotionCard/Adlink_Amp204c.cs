using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS168_W64;
using APS_Define_W32;
using System.IO;
using System.Threading;
namespace Fram.Hardware.MotionCard
{
    class Adlink_Amp204c: MotionCardBase
    {
        public Adlink_Amp204c(string devicename, Guid guid, int cardid = 0):base(devicename,guid,cardid)
        {
            Open();
        }
        public   override bool  Open()
        {
            int boardIdInBits = 0;
            // Card(Board) initial,mode bit0(0:By system assigned, 1:By dip switch)  
            int ret = APS168.APS_initial(ref boardIdInBits, m_cardIdMode);
            if (ret >= 0)
            {
              
                APS168.APS_get_first_axisId(m_cardId, ref m_startAxisIndex, ref m_totalAxisCount);
                int CardName=0;
                APS168.APS_get_card_name(m_cardId, ref CardName);
                if (CardName != (Int32)APS_Define.DEVICE_NAME_PCI_825458 && CardName != (Int32)APS_Define.DEVICE_NAME_AMP_20408C)
                {
                    throw new Exception("运动控制是型号不是204C或208C！");                                     
                }
            }
            else
            {
                throw new Exception("运动控制卡初始化失败，请检查驱动是否装好或者MotionCreatePro已经开启！");                
            }
            m_isInitialed = true;
            return true;
        }
        public override void LoadConfigFile(string filepath)
        {
            if(!m_isInitialed)
            {
                throw new Exception(" 请先初始化控制卡！");
            }
            if(!File.Exists(filepath))
            {
                throw new Exception($" {filepath} 所指向的文件不存在！");
            }
            m_isLoadConfigFile = (APS168.APS_load_param_from_file(filepath) == 0);
            if(!m_isLoadConfigFile)
                throw new Exception($"加载配置文件失败 {filepath} ");
            
        }
        public override void Close()
        {
            APS168.APS_close();
        }
        public override bool GetSingleInput(int index)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            int group = index / 32;
            int data = 0;
            
            int rtn= APS168.APS_read_d_input(m_cardId, group, ref data);
            if (rtn != 0)
                throw new Exception("读DI {index} 失败");
            return (data & (1 << index))!=0;            
        }
        public override bool GetSingleOutput(int index)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            int group = index / 32;
            int channel = index % 32;
            int data = 0;
            int rtn= APS168.APS_read_d_channel_output(m_cardId, group, channel, ref data);
            if(rtn!=0)
                throw new Exception("读D0 {index} 失败");
            return data  != 0;          
        }
        public override int GetMultiInput(int startindex, int offset)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            int data=0;
            if((startindex%32+offset)<=32)
            {
                int group = startindex / 32;
                int _data = 0;
                int rtn = APS168.APS_read_d_input(m_cardId, group, ref _data);
                if (rtn != 0)
                    throw new Exception("GetMultiInput 失败");
                data = (_data >> startindex) & (0xffff>>offset);
            }
            else
            {
                int group = startindex / 32;
                int _data = 0;
                int rtn = APS168.APS_read_d_input(m_cardId, group, ref _data);
                if (rtn != 0)
                    throw new Exception("GetMultiInput 失败");
                data = _data >> (32 - startindex % 32);
                group = (startindex + offset) / 32;
                rtn = APS168.APS_read_d_input(m_cardId, group, ref _data);
                if (rtn != 0)
                    throw new Exception("GetMultiInput 失败");
                int data1 = _data & (0xffff << (32-(startindex + offset) % 32));
                data = data1 << (32 - startindex % 32) | data;
            }
            return data;
        }
        public override int GetMultiOutput(int startindex, int offset)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            int data=0;
            for (int i = 0; i < offset; i++)
            {
                int index = startindex + i;
                int group = index / 32;
                int channel = index % 32;
                int _data = 0;
                int rtn = APS168.APS_read_d_channel_output(m_cardId, group, channel, ref _data);
                if (rtn != 0)
                    throw new Exception("GetMultiOutput 失败");
                data = (data << 1) | _data;
            }
            return base.GetMultiOutput(startindex, offset);
        }
        public override void SetSingleOutput(int index, bool value)
        {
            int group = index / 32;
            int channel = index % 32;
            int _data = Convert.ToInt32(value);
            int rtn=APS168.APS_write_d_channel_output(m_cardId, group, channel, _data);
            if (rtn != 0)
                throw new Exception("写D0 {index} 失败");
        }
        public override void SetMultiOutPut(int startindex, int value)
        {
            base.SetMultiOutPut(startindex, value);
        }
        public override void PowerSet(uint axisindex, bool value)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_servo_on((int)axisindex, Convert .ToInt32(value));
        }
        public override void AbsMove(uint axisindex, uint acc, uint dec, uint startv, uint maxv, int position)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if(!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_ACC, acc);
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_DEC, dec);
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VS, startv);

            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VM, maxv);
            APS168.APS_absolute_move((int)axisindex, position, (int)maxv);
            //等待Motion Down完成
            int motionStatusMdn = 5;
            while ((APS168.APS_motion_status((int)axisindex) & 1 << motionStatusMdn) == 0)
            {
                Thread.Sleep(100);
            }
        }
        public override void RelMove(uint axisindex, uint acc, uint dec, uint startv, uint maxv, int distance)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_ACC, acc);
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_DEC, dec);
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VS, startv);

            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VM, maxv);

            APS168.APS_relative_move((int)axisindex, distance, (int)maxv);
            int motionStatusMdn = 5;
            while ((APS168.APS_motion_status((int)axisindex) & 1 << motionStatusMdn) == 0)
            {
                Thread.Sleep(100);
            }

        }
        public override void JogStart(uint axisindex, uint acc, uint dec, uint velocity, bool positiveDirection)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (int)APS_Define.PRA_JG_MODE, 1);
            APS168.APS_set_axis_param((int)axisindex, (int)APS_Define.PRA_JG_DIR, positiveDirection?0:1);
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_ACC, acc);
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_DEC, dec);
            APS168.APS_jog_start((int)axisindex, 1);         
        }
        public override void JogStop(uint axisindex)
        {
            APS168.APS_jog_start((int)axisindex, 0);
        }
        public override void Home(uint axisindex,uint homedir, uint acc, uint dec, uint startv, uint maxv, uint homemode)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_DIR,Convert .ToInt32(homedir)); // Set home direction
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_HOME_ACC, acc);
            // Set homing acceleration rate
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_HOME_VM, maxv); // Set homing maximum velocity.
            APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_HOME_VS, startv); // Set homing start speed
            APS168.APS_home_move((int)axisindex);

            int motionStatusCstp = 0, motionStatusAstp = 16;
            while ((APS168.APS_motion_status((int)axisindex) & 1 << motionStatusCstp) == 0)
            {
                Thread.Sleep(100);
            }
            Thread.Sleep(500);
            if ((APS168.APS_motion_status((int)axisindex) & 1 << motionStatusAstp) != 0)
            {
                throw new Exception($"轴 { axisindex} 回零失败！");
            }
        

        }
    }
}
