using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fram.Hardware.Othrers
{
    /// <summary>
    /// tonghui 电压源
    /// </summary>
    public   class TH_Power
    {
        SerialPort port;
        string newLine = "\n";
        public TH_Power(string portname, int baudrate, Parity parity = Parity.None, int databit = 8, StopBits stopBits = StopBits.One)
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
