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
        /// <param name="startindex"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        int GetMultiInput(int startindex,int offset);
        /// <summary>
        /// Batch acquisition of outout status
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        int GetMultiOutput(int startindex, int offset);
        /// <summary>
        /// Batch setting of output status
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="value"></param>
        void SetMultiOutPut(int startindex,int value);
    }
}
