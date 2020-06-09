using Communication;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fram.Hardware.IoCard
{
   public  class NLK_IOCard_16 : IoCardBase
    {
        SerialPort port;
        int CrcPloy = 0xA001;//crc校验多项式
        int CardIndex;
        




        public NLK_IOCard_16(Guid guid, string devicename, uint inputcount, uint outputcount,int cardIndex,string portName, int baudRate=9600, StopBits stopBits = StopBits.One,Parity parity=Parity.None,string newline="\r\n") : base(guid, devicename, inputcount, outputcount)
        {
            port = new SerialPort();
            port.BaudRate = baudRate;
            port.StopBits = stopBits;
            port.Parity = parity;
            port.NewLine = newline;
            port.PortName = portName;
            CardIndex = cardIndex;
        }
        public override bool Open()
        {
            if(!port.IsOpen)
            {
                try
                {
                    port.Open();
                }
                catch(Exception ex)
                {
                    throw new Exception($"{DeviceName } 打开失败，"+ex.Message);
                }
            }

            
            return true;
        }
        public override void Close()
        {
            if (port.IsOpen)
                port.Close();         
        }
        public override  void StartWorking()
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


        private  void IOThread()
        {
            GetAllOutputStatue();
            while (!ioTaskCTS.IsCancellationRequested)
            {
                GetAllInputStatue();

                SetAllOutput();
                Thread.Sleep(20);
            }
        }
       
        private void GetAllInputStatue()
        {         
            byte[] data = new byte[6];
            data[0] = (byte)CardIndex;
            data[1] = 0x03;
            data[2] = 0x80;
            data[3] = 0x40;
            data[4] = 0x00;
            data[5] = 0x02;

            byte[] senddata = new byte[8];

            CRC.CRC16(data, CrcPloy, ref senddata[7], ref senddata[6]);

            data.CopyTo(senddata, 0);
            port.Write(senddata, 0, senddata.Length);
            Thread.Sleep(50);
            int count = port.BytesToRead;
            byte[] rtnData = new byte[count];
            port.Read(rtnData, 0, count);

            int startIndex = 0;
            byte[] retDataHead = new byte[] { (byte)CardIndex, 0x03,0x04 };
            if(!CheckContains(rtnData, retDataHead,ref startIndex))
            {
                return;
            }
            byte[] useInfo = new byte[7];
            Array.Copy(rtnData, startIndex, useInfo, 0, useInfo.Length);
            byte crcH = 0;
            byte crcL = 0;
            CRC.CRC16(useInfo, CrcPloy, ref crcL, ref crcH);
            if(crcL!=rtnData[startIndex+useInfo.Length+1]||crcH!= rtnData[startIndex + useInfo.Length])
            {
                return;
            }
            lock(LockReadInput)
            {
                inputStatueBuffer[0] = rtnData[startIndex + 6];
                inputStatueBuffer[1] = rtnData[startIndex + 5];
            }
            
            if (CheckSame(lastInputStatueBuffer,inputStatueBuffer))
            {               
                return;
            }
            //可触发事件
            inputStatueBuffer.CopyTo(lastInputStatueBuffer, 0);
          
        }
        
        private void GetAllOutputStatue()
        {
            
                byte[] data = new byte[6];
                data[0] = (byte)CardIndex;
                data[1] = 0x01;
                data[2] = 0x00;
                data[3] = 0x00;
                data[4] = 0x00;
                data[5] = 0x20;

                byte[] senddata = new byte[8];

                CRC.CRC16(data, CrcPloy, ref senddata[7], ref senddata[6]);

                data.CopyTo(senddata, 0);
                port.Write(senddata, 0, senddata.Length);
                Thread.Sleep(50);
                int count = port.BytesToRead;
                byte[] rtnData = new byte[count];
                port.Read(rtnData, 0, count);

                int startIndex = 0;
                byte[] retDataHead = new byte[] { (byte)CardIndex, 0x01, 0x04 };
                if (!CheckContains(rtnData, retDataHead, ref startIndex))
                {
                    return;
                }
                byte[] useInfo = new byte[7];
                Array.Copy(rtnData, startIndex, useInfo, 0, useInfo.Length);
                byte crcH = 0;
                byte crcL = 0;
                CRC.CRC16(useInfo, CrcPloy, ref crcL, ref crcH);
                if (crcL != rtnData[startIndex + useInfo.Length + 1] || crcH != rtnData[startIndex + useInfo.Length])
                {
                    return;
                }
                lock (LockSetOutput)
                {
                    lastWriteOutputStatueBuffer[0] = rtnData[startIndex + 3];
                    lastWriteOutputStatueBuffer[1] = rtnData[startIndex + 4];
                    WriteOutputStatueBuffer[0] = rtnData[startIndex + 3];
                    WriteOutputStatueBuffer[1] = rtnData[startIndex + 4];
            
                }
                                          
        }
        private bool  SetAllOutput()
        {
            byte[] writeOutputStatueBufferCopy = new byte[WriteOutputStatueBuffer.Length];
            lock (LockSetOutput)
            {
                if (CheckSame(lastWriteOutputStatueBuffer, WriteOutputStatueBuffer))
                {
                    return true;
                }
                Array.Copy(WriteOutputStatueBuffer, writeOutputStatueBufferCopy, WriteOutputStatueBuffer.Length);
            }
           
            byte[] data = new byte[11];
            data[0] = (byte)CardIndex;
            data[1] = 0x10;
            data[2] = 0x80;
            data[3] = 0x50;
            data[4] = 0x00;
            data[5] = 0x02;
            data[6] = 0x04;
        
            data[7] = writeOutputStatueBufferCopy[1];
            data[8] = writeOutputStatueBufferCopy[0];
            byte[] senddata = new byte[data.Length + 2];

            CRC.CRC16(data, CrcPloy, ref senddata[data.Length + 1], ref senddata[data.Length]);

            data.CopyTo(senddata, 0);
            port.Write(senddata, 0, senddata.Length);

            //校验返回数据
            Thread.Sleep(50);
            int count = port.BytesToRead;
            byte[] rtnData = new byte[count];
            port.Read(rtnData, 0, count);
            int startIndex = 0;
            byte[] retDataHead = new byte[] { (byte)CardIndex, 0x10, 0x80,0x50 };
            if (!CheckContains(rtnData, retDataHead, ref startIndex))
            {
                return false;
            }
            byte[] useInfo = new byte[6];
            Array.Copy(rtnData, startIndex, useInfo, 0, useInfo.Length);
            byte crcH = 0;
            byte crcL = 0;
            CRC.CRC16(useInfo, CrcPloy, ref crcL, ref crcH);
            if (crcL != rtnData[startIndex + useInfo.Length + 1] || crcH != rtnData[startIndex + useInfo.Length])
            {
                return false;
            }
            lock(LockReadOutput)
            {
                Array.Copy(writeOutputStatueBufferCopy, lastWriteOutputStatueBuffer, WriteOutputStatueBuffer.Length);
            }
            return true;
        }
        
        

        public override bool GetSingleInput(int index)
        {
            lock (LockReadInput)
            {
                if (index > (InputCount - 1))
                {
                    throw new IndexOutOfRangeException($"{DeviceName} GetSingleOutput 参数index超限");
                }
                if ((inputStatueBuffer[index / 8] & (0x01 << (index % 8))) != 0)
                    return true;
                else
                    return false;
            }

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
     
        public override bool GetSingleOutput(int index)
        {
            lock (LockReadInput)
            {
                if (index > (InputCount - 1))
                {
                    throw new IndexOutOfRangeException($"{DeviceName} GetSingleOutput 参数index超限");
                }
                if ((lastWriteOutputStatueBuffer[index / 8] & (0x01 << (index % 8))) != 0)
                    return true;
                else
                    return false;
            }
        }
        public override byte[] GetAllOutput()
        {
            lock(LockReadOutput)
            {
                byte[] data = new byte[lastWriteOutputStatueBuffer.Length];
                Array.Copy(lastWriteOutputStatueBuffer, data, data.Length);
                return data;
            }
            
        }
        public override void SetMultiOutPut(int startindex, int value)
        {
            lock (LockSetOutput)
            {
                if (startindex > (OutputCount - 1))
                {
                    throw new IndexOutOfRangeException($"{DeviceName} SetMultiOutPut 参数startindex超限");
                }
                int v = value;
                int valuebit = 1;
                while(v/2>0)
                {
                    v = v / 2;
                    valuebit++;
                }
                if (startindex+ valuebit > (OutputCount - 1))
                {
                    throw new IndexOutOfRangeException($"{DeviceName} SetMultiOutPut 参数value超限");
                }
                for(int i=0;i<valuebit;i++)
                {
                    if ((value & 0x01) != 0)
                    {
                        WriteOutputStatueBuffer[(startindex+i) / 8] = (byte)((int)WriteOutputStatueBuffer[(startindex + i) / 8] | (0x01 << ((startindex + i) % 8)));
                    }
                    else
                    {
                        WriteOutputStatueBuffer[(startindex + i) / 8] = (byte)((int)WriteOutputStatueBuffer[(startindex + i) / 8] & ~(0x01 << ((startindex + i) % 8)));
                    }
                    value = value >> 1;

                }
            }
        }
        public override void SetSingleOutput(int index, bool value)
        {
            lock (LockSetOutput)
            {
                if (index > (OutputCount - 1))
                {
                    throw new IndexOutOfRangeException($"{DeviceName} SetSingleOutput 参数index超限");
                }
                if (value)
                    WriteOutputStatueBuffer[index / 8] = (byte)((int)WriteOutputStatueBuffer[index / 8]|(0x01<<(index%8))) ;
                else
                    WriteOutputStatueBuffer[index / 8] = (byte)((int)WriteOutputStatueBuffer[index / 8] & ~(0x01 << (index % 8)));
            }


        }
    }
}
