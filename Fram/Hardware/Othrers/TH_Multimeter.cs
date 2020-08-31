using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.Othrers
{
   public  class TH_Multimeter
    {
        SerialPort port;
        string newLine = "\n";
        public TH_Multimeter(string portname, int baudrate, Parity parity = Parity.None, int databit = 8, StopBits stopBits = StopBits.One)
        {
            port = new SerialPort(portname, baudrate, parity, databit, stopBits);
            port.NewLine = newLine;

        }
        public void Connect()
        {
            try
            {
                if (port.IsOpen)
                    return;
                port.Open();

            }
            catch (Exception ex)
            {
                throw new Exception($"串口 {port.PortName} 打开失败，{ex.Message}");
            }
        }
        public void DisConnect()
        {
            try
            {
                if (port.IsOpen)
                    port.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public void SetVoltageParam(VoltRange voltRange = VoltRange.mV100, VoltPLC voltPLC = VoltPLC.PLC0_02)
        {
            if (!port.IsOpen)
                throw new Exception("设备未连接");
            String _voltRange;
            if (voltRange == VoltRange.Auto)
                _voltRange = "AUTO";
            else if (voltRange == VoltRange.mV100)
                _voltRange = "100M";
            else
                _voltRange = ((int)voltRange).ToString();
            string _voltPLC;
            if (voltPLC == VoltPLC.PLC0_2 || voltPLC == VoltPLC.PLC0_02)
                _voltPLC = ((double)2 / Math.Pow(10, (double)voltPLC - 1)).ToString($"F{(int)voltPLC}");
            else
                _voltPLC = ((int)voltPLC).ToString();
            try
            {
                string info = $"SENSE:VOLT:RANGE {_voltRange};:VOLT:NPLC {_voltPLC}";
                port.WriteLine(info);
            }
            catch (Exception ex)
            {

            }
        }
        public double GetVoltage()
        {
            double rtn = 0;
            if (!port.IsOpen)
                throw new Exception("设备未连接");
            string info = "INIT;:FETCH?";
            try
            {
                port.WriteLine(info);
                string volt = port.ReadLine();
                rtn = double.Parse(volt);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return rtn;
        }
        public SerialPort Port
        {
            get { return port; }
        }
        public enum VoltRange
        {

            [Description("1V量程")]
            V1 = 1,
            [Description("10V量程")]
            V10 = 10,
            [Description("100V量程")]
            V100 = 100,
            [Description("1000V量程")]
            V1000 = 1000,
            [Description("自动量程")]
            Auto,
            [Description("100mV")]
            mV100,
        }
        public enum VoltPLC
        {

            [Description("100PLC")]
            PLC100 = 100,
            [Description("10PLC")]
            PLC10 = 10,
            [Description("1PLC")]
            PLC1 = 1,
            [Description("0.2PLC")]
            PLC0_2,
            [Description("0.02PLC")]
            PLC0_02,

        }
    }
}
