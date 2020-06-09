using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cszmcaux;
using System.IO.Ports;
using Communication;
using System.Net;
using System.Threading;

namespace Fram.Hardware.IoCard
{
    /// <summary>
    /// 正运动公司的EMC存io控制卡，32路input，32路output
    /// </summary>
    public class EMC0064 : IoCardBase
    {
        IntPtr phandle;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="devicename"></param>
        /// <param name="inputcount"></param>
        /// <param name="outputcount"></param>
        /// <param name="connectinfo">ComNumber or localIpAddress</param>
        public EMC0064( Guid guid, string devicename, uint inputcount, uint outputcount,string connectinfo) : base( guid, devicename, inputcount, outputcount)
        {
            Open(connectinfo);
        }
        public override void StartWorking()
        {
            if (ioTask == null || ioTask.IsCanceled || ioTask.Status == TaskStatus.RanToCompletion)
            {
                ioTaskCTS = new CancellationTokenSource();
                ioTask = new Task(IOThread, ioTaskCTS.Token);
                ioTask.Start();
            }
            else if (ioTask.Status == TaskStatus.Running)
                return;
        }
        public override void StopWorking()
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
        private  bool Open(string connectinfo)
        {
            int ret=0;

            if(connectinfo.ToUpper().Contains("COM"))
            {
                int comIndex = int.Parse(connectinfo.Substring(3, 1));
                ret = zmcaux.ZAux_OpenCom((uint)comIndex, out phandle);
            }
            else
            {
                if(IPAddress.TryParse(connectinfo,out IPAddress iPAddress))
                {
                    throw new Exception("EMC0064 io卡ip地址信息格式异常");
                }
                ret = zmcaux.ZAux_OpenEth(connectinfo, out phandle);
            }           
            
            if (ret == 0)
                return true;
            else
                return false;
        }
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
        public override bool GetSingleInput(int index)
        {
            uint value=0;
           int ret= zmcaux.ZAux_Direct_GetIn(phandle, index, ref  value);
            
            return value==0?false:true;
        }
        public override bool GetSingleOutput(int index)
        {
            uint value = 0;
            int ret = zmcaux.ZAux_Direct_GetOp(phandle, index, ref value);
            return value == 0 ? false : true;
        }
        public override void SetSingleOutput(int index, bool value)
        {
            uint _value;
            if (value)
                _value = 1;
            else
                _value = 0;
            int ret = zmcaux.ZAux_Direct_SetOp(phandle, index, _value);          
        }
        public override byte[] GetAllInput()
        {

            lock (LockReadInput)
            {
                byte[] data = new byte[inputStatueBuffer.Length];
                Array.Copy(inputStatueBuffer, data, inputStatueBuffer.Length);
                return data;

            }       
        }
        public override byte[] GetAllOutput()
        {
            lock (LockReadOutput)
            {
                byte[] data = new byte[lastWriteOutputStatueBuffer.Length];
                Array.Copy(lastWriteOutputStatueBuffer, data, data.Length);
                return data;
            }

        }
    }
}
