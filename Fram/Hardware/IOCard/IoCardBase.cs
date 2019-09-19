using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;
namespace Fram.Hardware.IoCard
{
   public  class IoCardBase: HardwareBase,IIoCard
    {
        #region property       
       
        public uint InputCount { get; private set; }
        public uint OutputCount { get; private set; }
        public IoCardBrand CardType { get; private set; }
        public BaseCommunicate Communicate { get; set; }
        #endregion
        #region method
        public IoCardBase(BaseCommunicate communicate, Guid guid, string devicename, uint inputcount, uint outputcount) : base(devicename, guid)
        {               
            Guid = guid;
            DeviceName = devicename;
            InputCount = inputcount;
            OutputCount = outputcount;
            Communicate = communicate;
        }        
        public virtual bool Open() { return true; }
        public virtual void Close() { }
        public virtual bool GetSingleInput(int index) { return false; }
        public virtual bool GetSingleOutput(int index) { return false; }
        public virtual void SetSingleOutput(int index, bool value) { }

        public virtual  int GetMultiInput(int startindex, int offset) { return 0; }
        public virtual int GetMultiOutput(int startindex,int offset) { return 0; }
        public virtual void SetMultiOutPut(int startindex,int value) { }
        #endregion
    }
    /// <summary>
    /// 硬件连接方式
    /// SerialPort:串口
    /// EtherNet:网口
    /// </summary>
   
    public enum IoCardBrand
    {
        ZMotion_EMC0064,
        SerialIOCardTest,
        TcpClientIOCardTest,
    }
}
