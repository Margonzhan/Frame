using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.IoCard
{
   public  class IoCardBase: HardwareBase,IIoCard
    {
        #region property       
        public uint COM { get; private set; }

        public Parity Parity { get; private set; }
        public StopBits StopBits { get; private set; }
        public uint BaudRate { get; private set; }
        public uint DataBits { get; private set; }
        public string IPAddress { get;private set; }
        public uint Port { get; private set; }
        public uint InputCount { get; private set; }
        public uint OutputCount { get; private set; }
        public IoCardBrand CardType { get; private set; }
        public IoCardConnectType CardConnectType { get; private set; }
        #endregion
        #region method
        public IoCardBase(IoCardConnectType connectType,uint Com,uint baudrate,StopBits stopBits,Parity parity,uint databits,
            Guid guid,string devicename,uint inputcount,uint outputcount):base(devicename, guid)
        {
            CardConnectType = connectType;
            COM = Com;
            BaudRate = baudrate;
            StopBits = stopBits;
            Parity = parity;
            DataBits = databits;
            Guid = guid;
            DeviceName = devicename;
            InputCount = inputcount;
            OutputCount = outputcount;
        }
        public IoCardBase(IoCardConnectType connectType, string ipaddress, uint port,
            Guid guid, string devicename, uint inputcount, uint outputcount):base(devicename, guid)
        {
            CardConnectType = connectType;
            IPAddress = ipaddress;
            Port = port;
            Guid = guid;
            DeviceName = devicename;
            InputCount = inputcount;
            OutputCount = outputcount;
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
    public enum IoCardConnectType
    {
        SerialPort,
        EtherNet,
    }
    public enum IoCardBrand
    {
        ZMotion_EMC0064,
    }
}
