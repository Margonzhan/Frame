using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cszmcaux;
using System.IO.Ports;
using Communication;

namespace Fram.Hardware.IoCard
{
    /// <summary>
    /// 正运动公司的EMC存io控制卡，32路input，32路output
    /// </summary>
    public class EMC0064 : IoCardBase
    {
        IntPtr phandle;
        public EMC0064(BaseCommunicate communicate, Guid guid,string devicename,uint inputcount,uint outputcount) : base(communicate,  guid, devicename, inputcount, outputcount)
        {
            Open();
        }
        
        private new bool Open()
        {
            int ret=0;
            switch (Communicate.CommunicationType)
            {
                case CommunicatioinType.TcpClient:
                    TcpClientCommunicate tcpClientCommunicate = (TcpClientCommunicate)Communicate;
                     ret = zmcaux.ZAux_OpenEth(tcpClientCommunicate.LocalIpAddress, out phandle);                
                    break;
                case CommunicatioinType.SerialPort:
                    SerialCommunicate serialCommunicate = (SerialCommunicate)Communicate;
                    if (!serialCommunicate.PortName.StartsWith("COM"))
                        throw new Exception();
                    int comIndex = int.Parse( serialCommunicate.PortName.Substring(3, 1));
                    ret =  zmcaux.ZAux_OpenCom((uint)comIndex, out  phandle);
                    break;
                default:
                    // log the error info
                    break;
                    
            }
            
            if (ret == 0)
                return true;
            else
                return false;
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
        public override int GetMultiInput(int startindex, int offset)
        {
            int value=0;
            int[] data = new int[] { };
            int ret = zmcaux.ZAux_Direct_GetInMulti(phandle, startindex, startindex + offset, data);
            for(int i=0;i<offset;i++)
            {
                if(data[i]==1)
                {
                    value += 0x01 << i;
                }
            }
            return value;
        }
    }
}
