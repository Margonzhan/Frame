using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Communication;
namespace Fram.Hardware.IoCard
{
   public  class IoCardBase: HardwareBase,IIoCard
    {
        protected  byte[] lastInputStatueBuffer;//上次读取的输入io的状态
        protected byte[] inputStatueBuffer;//存放输入端状态,低位在前，
        protected byte[] lastWriteOutputStatueBuffer;//上次写的输出io的状态
        protected byte[] WriteOutputStatueBuffer;//当前的输出io的状态

        protected byte[] outputStatueBuffer;//存放输出端状态，地位在前

        protected Task ioTask;
        protected CancellationTokenSource ioTaskCTS;
        protected  readonly object LockReadInput = new object();
        protected readonly object LockReadOutput = new object();
        protected readonly object LockSetOutput = new object();
        #region property       

        public uint InputCount { get; private set; }
        public uint OutputCount { get; private set; }
        public IoCardBrand CardType { get; private set; }
        
        #endregion
        #region method
        public IoCardBase( Guid guid, string devicename, uint inputcount, uint outputcount) : base(devicename, guid)
        {               
            Guid = guid;
            DeviceName = devicename;
            InputCount = inputcount;
            OutputCount = outputcount;
            lastInputStatueBuffer= new byte[inputcount / 8 + (inputcount%8>0?1:0)];
            inputStatueBuffer = new byte[inputcount / 8 + (inputcount % 8 > 0 ? 1 : 0)];


            lastWriteOutputStatueBuffer = new byte[outputcount / 8 + (outputcount % 8 > 0 ? 1 : 0)];
            WriteOutputStatueBuffer = new byte[outputcount / 8 + (outputcount % 8 > 0 ? 1 : 0)];

            outputStatueBuffer = new byte[outputcount / 8 + (outputcount % 8 > 0 ? 1 : 0)];

        }        
        public virtual bool Open() { return true; }
        public virtual void Close() { }
        public virtual void StartWorking() { }
     
        public virtual void StopWorking() { }
       
      
        public virtual bool GetSingleInput(int index) { return false; }
        public virtual bool GetSingleOutput(int index) { return false; }
        public virtual void SetSingleOutput(int index, bool value) { }

        public virtual  byte[] GetAllInput() { return new byte[] { }; }
        public virtual byte[] GetAllOutput() { return  new byte[] { }; }
        public virtual void SetMultiOutPut(int startindex,int value) { }

        protected bool CheckContains(byte[] sourcedata, byte[] containdata, ref int startindex)
        {
            for (int i = 0; i < sourcedata.Length - containdata.Length - 1; i++)
            {
                if (sourcedata[i] == containdata[0])
                {
                    byte[] copy = new byte[containdata.Length];
                    Array.Copy(sourcedata, i, copy, 0, containdata.Length);
                    if (CheckSame(copy, containdata))
                    {
                        startindex = i;
                        return true;
                    }
                }
            }
            return false;
        }
        protected bool CheckSame(byte[] data1, byte[] data2)
        {
            if (data1.Length != data2.Length)
                return false;
            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != data2[i])
                    return false;
            }
            return true;
        }

        #endregion
    }
  
    public enum IoCardBrand
    {
        ZMotion_EMC0064,
        SerialIOCardTest,
        TcpClientIOCardTest,
        NLK_IOCard_16,
    }
}
