using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Connection;
using System.Threading;
using FileOperate;
using Fram;
using System.Drawing;
namespace readCodetest
{
    /// <summary>
    /// 三菱plc串口通信类
    /// </summary>
    class FXSerialConnect
    {
        private static  FXSerialConnect m_instance;
        private readonly static object m_lock = new object();
        public bool M000 = false;//轨道1sensor
        public bool M001 = false;//轨道2sensor

        private byte M10_M17 = new byte();
        Thread ReadIoHandle;
        ComConnect serial;
        public static FXSerialConnect GetInstance()
        {
            if (m_instance == null)
            {
                lock (m_lock)
                {
                    if (m_instance == null)
                    {
                        m_instance = new FXSerialConnect();                    
                    }              
                }
            }
            return m_instance;
        }
        public FXSerialConnect()
        {
            M10_M17 = 0x00;
             ReadIoHandle = new Thread(ThreadReadI0);
             ReadIoHandle.IsBackground = true;
            
        }
        public void Connect(string portName, int baudrate, int databit, System.IO.Ports.Parity parity, System.IO.Ports.StopBits stopbits)
        {
            try
            {
                if (serial == null)
                {
                    serial = new ComConnect(portName, baudrate, databit, parity, stopbits);
                    serial.OpenSerialPort();
                    serial.PortDateReceiveEvent -= serial_PortDateReceiveEvent;
                    serial.PortDateReceiveEvent += serial_PortDateReceiveEvent;
                    ReadIoHandle.Start();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("打开PLC串口异常：" + ex.Message);
            }
        }
        private void ThreadReadI0()
        {
            while (true)
            {
                ReadM(0, 2);//读取M01，M02
                Thread.Sleep(50);
                WriteM10_M17();
                Thread.Sleep(50);
            }
        }
        void serial_PortDateReceiveEvent(object sender, PortEventArgs e)
        {
            byte[] datas = e.buffer;
            string str = System.Text.Encoding.Default.GetString(datas, 0, e.bytes);
            if (str.Contains("00FF")&&(str.Length>5)&&(str.Length<10))
            {             
                M000=(str.Substring(5,1)=="1"?true:false);
                DelegateUIControl.GetInstance().UpdateTextBox("txt_ErrorMessage", M000.ToString(), false, Color.Red);
                M001 = (str.Substring(6, 1) == "1" ? true : false);               
            }
        }
  
        private void ReadM(int startindex, int length)
        {
            try
            {
                string datastr = "ENQ00FFBR1M" + startindex.ToString("D4") + length.ToString("D2");
                serial.SendString(datastr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void WriteM10_M17()
        {
            string enq = Convert.ToString(0x05);
            string str = "00FFBW1M" + "0010" + "08" + System.Convert.ToString(M10_M17, 2).PadLeft(8,'0');         
            serial.SendString(str);
        }
        public void SetM10_M17(int index,bool onoff)
        {
            if (onoff)
            {
                
                M10_M17 = Convert.ToByte((0x80 >> index )| M10_M17);
            }
            else
            {
                M10_M17 = Convert.ToByte((~(0x80 >> index)) & M10_M17);
            }
           
        }
        public void WriteM(int index, bool onoff)
        {
            string str = "00FFBW3M" + index.ToString().PadLeft(4, '0') + "01";
            if (onoff)
            {
                str += "1";
            }
            else
                str += "0";
            serial.SendString(str);
        }
        public void WriteD(int index, int number)
        {
            string str = "00FFWW0D" + index.ToString().PadLeft(4, '0') + "01" + number.ToString("X4");
          
            serial.SendString(str);
            
        }
        public void CloseConnect()
        {
            serial.Close();
        }
    }
}
