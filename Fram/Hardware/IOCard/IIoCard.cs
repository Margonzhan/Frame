using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.IoCard
{
   public  interface IIoCard
    {
        
        /// <summary>
        /// open and connect the io card
        /// </summary>
        /// <returns></returns>
        bool Open();
        /// <summary>
        /// close and disconnect the iocard
        /// </summary>
        void  Close();
        /// <summary>
        /// io开开始工作，正常情况下对象内部回开启一个线程来刷新io状态
        /// </summary>
        void StartWorking();
        /// <summary>
        /// 停止刷新io状态的线程
        /// </summary>
        void StopWorking();



        /// <summary>
        /// get the input statue at index
        /// </summary>
        /// <param name="index">the  inout statue at index</param>
        /// <returns></returns>
        bool GetSingleInput(int index);
        /// <summary>
        /// get the output statue at index
        /// </summary>
        /// <param name="index">the output statue at index</param>
        /// <returns></returns>
        bool GetSingleOutput(int index);
        /// <summary>
        /// set the output statue at index 
        /// </summary>
        /// <param name="index">the io offset want to set</param>
        /// <param name="value">the value want to set</param>
        void  SetSingleOutput(int index,bool value);
        /// <summary>
        /// Batch acquisition of input status
        /// </summary>
   
        /// <returns></returns>
        byte[] GetAllInput();
        /// <summary>
        /// Batch acquisition of outout status
        /// </summary>
    
        /// <returns></returns>
        byte [] GetAllOutput();
        /// <summary>
        /// Batch setting of output status
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="value"></param>
        void SetMultiOutPut(int startindex,int value);
    }
}
