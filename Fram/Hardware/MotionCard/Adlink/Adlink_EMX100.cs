using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS168_W64;
using APS_Define_W32;
using System.IO;
using System.Threading;
using Fram.Hardware.IoCard;

namespace Fram.Hardware.MotionCard
{
    class Adlink_EMX100: MotionCardBase, IIoCard
    {

        #region 读io使用
        protected byte[] lastInputStatueBuffer;//上次读取的输入io的状态
        protected byte[] inputStatueBuffer;//存放输入端状态,低位在前，
        protected byte[] lastWriteOutputStatueBuffer;//上次写的输出io的状态
        protected byte[] WriteOutputStatueBuffer;//当前的输出io的状态

        protected byte[] outputStatueBuffer;//存放输出端状态，地位在前

        protected Task ioTask;
        protected CancellationTokenSource ioTaskCTS;

        public uint InputCount { get; private set; }
        public uint OutputCount { get; private set; }
        #endregion


        public Adlink_EMX100(string devicename, Guid guid, int inputCount,int outputCount, int cardid = 0) :base(devicename,guid,cardid)
        {
            Open();
        }
        public   override bool  Open()
        {
            int boardIdInBits = 0;

            int ret = APS168.APS_register_emx(1, 0);
            // Card(Board) initial,mode bit0(0:By system assigned, 1:By dip switch)  

            ret = APS168.APS_initial(ref boardIdInBits, m_cardIdMode);
            if (ret >= 0)
            {
              
                APS168.APS_get_first_axisId(m_cardId, ref m_startAxisIndex, ref m_totalAxisCount);
                int CardName=0;
                APS168.APS_get_card_name(m_cardId, ref CardName);
                if (CardName != (Int32)APS_Define.DEVICE_NAME_ENET_EMX100)
                {
                    throw new Exception("运动控制是型号不是EMX100！");                                     
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
       
        
        public  void StopWorking()
        {
            ioTaskCTS.Cancel();
        }


        private void IOThread()
        {
            GetAllOutputStatue();
            while (!ioTaskCTS.IsCancellationRequested)
            {
                GetAllInputStatue();

                SetAllOutput();
                Thread.Sleep(20);
            }
        }


        #region io operate

        private void GetAllInputStatue()
        {
           

        }
        private void GetAllOutputStatue()
        {

           

        }
        private bool SetAllOutput()
        {
            return true;
        }




        public  bool GetSingleInput(int index)
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
        public  bool GetSingleOutput(int index)
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
        public  byte GetAllInput(int startindex, int offset)
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
            // return data;
            return 0x00;
        }
        public  int GetAllOutput(int startindex, int offset)
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
            return data;
        }
        public  void SetSingleOutput(int index, bool value)
        {
            int group = index / 32;
            int channel = index % 32;
            int _data = Convert.ToInt32(value);
            int rtn=APS168.APS_write_d_channel_output(m_cardId, group, channel, _data);
            if (rtn != 0)
                throw new Exception("写D0 {index} 失败");
        }
        public  void SetMultiOutPut(int startindex, int value)
        {
            
        }
        #endregion
        public override void PowerSet(uint axisindex, bool value)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_servo_on((int)axisindex, Convert .ToInt32(value));
        }
        public override async Task AbsMoveAsync(uint axisindex,  int position)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if(!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_ACC, acc);
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_DEC, dec);
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VS, startv);

            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VM, maxv);
            int maxv = 0;
            APS168.APS_get_axis_param((int)axisindex, (int)APS_Define.PRA_VM, ref  maxv);
            await Task.Run(() => 
            {
                APS168.APS_absolute_move((int)axisindex, position, (int)maxv);
                //等待Motion Down完成
                int motionStatusMdn = 5;
                while ((APS168.APS_motion_status((int)axisindex) & 1 << motionStatusMdn) == 0)
                {
                    Thread.Sleep(100);
                }
            });
            
        }
        public override async Task RelMoveAsync(uint axisindex,  int distance)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_ACC, acc);
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_DEC, dec);
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VS, startv);

            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_VM, maxv);
            int maxv = 0;
            APS168.APS_get_axis_param((int)axisindex, (int)APS_Define.PRA_VM, ref maxv);
            await Task.Run(() =>
           {
               APS168.APS_relative_move((int)axisindex, distance, (int)maxv);
               int motionStatusMdn = 5;
               while ((APS168.APS_motion_status((int)axisindex) & 1 << motionStatusMdn) == 0)
               {
                   Thread.Sleep(50);
               }
           });
          

        }
        public override void JogStart(uint axisindex,  bool positiveDirection)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            //jog mode 0 means constant mode,1 means step mode
            APS168.APS_set_axis_param((int)axisindex, (int)APS_Define.PRA_JG_MODE, 0);
            APS168.APS_set_axis_param((int)axisindex, (int)APS_Define.PRA_JG_DIR, positiveDirection?0:1);
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_ACC, acc);
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_DEC, dec);
            APS168.APS_jog_start((int)axisindex, 1);         
        }
        public override void JogStop(uint axisindex)
        {
            APS168.APS_jog_start((int)axisindex, 0);
        }
        public override async Task HomeAsync(uint axisindex)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
           // APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_DIR,Convert .ToInt32(homedir)); // Set home direction
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_HOME_ACC, acc);
            //// Set homing acceleration rate
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_HOME_VM, maxv); // Set homing maximum velocity.
            //APS168.APS_set_axis_param_f((int)axisindex, (Int32)APS_Define.PRA_HOME_VS, startv); // Set homing start speed

            await Task.Run(() =>
            {
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
               // Thread.Sleep(500);
               // APS168.APS_set_position_f((int)axisindex,0);
            });
            
        

        }
        public override void AxisNormalStop(uint axisindex)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_stop_move((int)axisindex);          
        }
        public override void AxisEmgStop(uint axisindex)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_emg_stop((int)axisindex);          
        }
        public override void SetAxisAcc(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_ACC, (int)paramvalue);          
        }
        public override void GetAxisAcc(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_ACC,ref pv);
            paramvalue = pv;
        }
        public override void SetAxisDec(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_DEC, pv);
            paramvalue = pv;
        }
        public override void GetAxisDec(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_DEC,ref pv);
            paramvalue = pv;
        }
        public override void SetAxisEndV(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_VE, (int)paramvalue);
        }
        public override void GetAxisEndV(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");

            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_VE, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisMaxV(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_VM, (int)paramvalue);
         
        }
        public override void GetAxisMaxV(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");

            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_VM, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisStartV(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_VS, (int)paramvalue);
            
        }
        public override void GetAxisStartV(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_VS, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisHomeAcc(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_ACC, (int)paramvalue);
        }
        public override void GetAxisHomeAcc(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_ACC, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisHomeDec(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_ACC, (int)paramvalue);
            paramvalue = pv;
        }
        public override void GetAxisHomeDec(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_ACC, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisHomeMaxV(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_VM, (int)paramvalue);
           
        }
        public override void GetAxisHomeMaxV(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_VM, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisHomeStartV(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
         
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_VS, (int)paramvalue);
        }
        public override void GetAxisHomeStartV(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_VS, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisHomeMode(uint axisindex, int paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
          
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_MODE, paramvalue);
           
        }
        public override void GetAxisHomeMode(uint axisindex, ref int paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
           
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_MODE, ref paramvalue);
        }
        public override void SetAxisHomeDir(uint axisindex, int paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");          
            APS168.APS_set_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_DIR, paramvalue);
           
        }
        public override void GetAxisHomeDir(uint axisindex, ref int paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            
            APS168.APS_get_axis_param((int)axisindex, (Int32)APS_Define.PRA_HOME_DIR, ref paramvalue);
           
        }





        public override void GetAxisPosition(uint axisindex, ref double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            int pv = -1;
            APS168.APS_get_position((int)axisindex, ref pv);
            paramvalue = pv;
        }
        public override void SetAxisPosition(uint axisindex, double paramvalue)
        {
            if (!m_isInitialed)
                throw new Exception("请先初始化");
            if (!m_isLoadConfigFile)
                throw new Exception("未加载xml配置文件");
            
            APS168.APS_set_position((int)axisindex, (int)paramvalue);

        }
        public override void GetAxisIoData(uint axisindex, ref int value)
        {
            value = APS168.APS_motion_io_status((int)axisindex);           
        }
        public override void GetAxisStatue(uint axisindex, ref int value)
        {
            value = APS168.APS_motion_status((int)axisindex);            
        }

        public byte[] GetAllInput()
        {
            throw new NotImplementedException();
        }

        public byte[] GetAllOutput()
        {
            throw new NotImplementedException();
        }

        public void StartWorking()
        {
            throw new NotImplementedException();
        }
    }
}
