using CommonFunc;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;

namespace Fram
{
    public class GloablObject : Singleton<GloablObject>
    {
        VoltageMeasurement voltageMeasurement;
        Power power;
        public void Init()
        {
            power = new Power("COM4", 9600);
            power.Connect();
            power.SetVoltage(5);

            voltageMeasurement = new VoltageMeasurement("COM3", 115200);
            voltageMeasurement.Connect();
            voltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, VoltageMeasurement.VoltPLC.PLC0_02);

        }

        public VoltageMeasurement VoltageMeasurement
        {
            get
            {
                if (voltageMeasurement != null)
                {
                    return voltageMeasurement;
                }
                else
                {
                    throw new ArgumentNullException("voltageMeasurement reference is null");
                }
            }
        }
        public Power Power
        {
            get
            {
                if (power != null)
                {
                    return power;
                }
                else
                {
                    throw new ArgumentNullException("power reference is null");
                }
            }
        }

    }
    public class VoltageMeasurement
    {
        SerialPort port;
        string newLine = "\n";
        public VoltageMeasurement(string portname, int baudrate, Parity parity = Parity.None, int databit = 8, StopBits stopBits = StopBits.One)
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
    public class Power
    {
        SerialPort port;
        string newLine = "\n";
        public Power(string portname, int baudrate, Parity parity = Parity.None, int databit = 8, StopBits stopBits = StopBits.One)
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
                if (null == GetAddress())
                {
                    throw new Exception($"连接设备 {port.PortName } 失败");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Connect error:{ex.Message}");
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
        /// <summary>
        /// 锁定仪器面板，锁定后，仪器按钮将不能使用
        /// </summary>
        /// <param name="islock"></param>
        public void SysTemLock(bool islock)
        {
            string info = string.Empty;
            if (islock)
                info = "SYSTem:lock";

            else
                info = "SYSTem:local";
            if (port.IsOpen)
            {
                try
                {
                    port.WriteLine(info);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                throw new Exception("串口未打开");
            }
        }
        public void SetVoltage(float voltage)
        {
            if (port.IsOpen)
            {
                if (null == GetAddress())
                    throw new Exception($"{port.PortName} 所连接设备掉线");
                string info = "Voltage " + voltage.ToString("F3");
                port.WriteLine(info);
                Thread.Sleep(50);
                string ff = voltage.ToString("F3");
                string vvv = GetVoltage();
                if (ff != vvv)
                {
                    throw new Exception($"SetVoltage {voltage} falid");
                }
            }
            else
            {
                throw new Exception($"{port.PortName}未连接");
            }
        }
        public string GetVoltage()
        {
            string rtn = string.Empty;
            if (port.IsOpen)
            {
                if (null == GetAddress())
                    throw new Exception($"{port.PortName} 所连接设备掉线");
                string info = "Voltage?";
                port.WriteLine(info);
                rtn = port.ReadLine().Trim();
            }
            else
            {
                throw new Exception($"{port.PortName}未连接");
            }
            return rtn;
        }
        public void OutPut(bool powerOn)
        {
            if (port.IsOpen)
            {
                if (null == GetAddress())
                    throw new Exception($"{port.PortName} 所连接设备掉线");
                string info = "Output " + (powerOn ? "1" : "0");
                port.WriteLine(info);
                Thread.Sleep(50);
                if ((powerOn ? "1" : "0") != GetOutPutStatue())
                {
                    throw new Exception($" set Output  falid");
                }
            }
            else
            {
                throw new Exception($"{port.PortName}未连接");
            }
        }
        public string GetOutPutStatue()
        {
            string rtn = string.Empty;
            if (port.IsOpen)
            {
                if (null == GetAddress())
                    throw new Exception($"{port.PortName} 所连接设备掉线");
                string info = "Output?";
                port.WriteLine(info);
                rtn = port.ReadLine();
            }
            else
            {
                throw new Exception($"{port.PortName}未连接");
            }
            return rtn;
        }
        private string GetAddress()
        {

            string rtn = string.Empty;
            if (port.IsOpen)
            {
                try
                {
                    port.WriteLine("system:address?");
                    rtn = port.ReadLine();
                }
                catch (Exception e)
                {
                    throw new Exception("GetAddress error: " + e.Message);
                }

            }
            return rtn;
        }
    }
}
