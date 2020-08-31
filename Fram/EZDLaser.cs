using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace EZDLaser
{
   public  class EZDLaser
    {
        [DllImport("MarkEzd.dll", CharSet = CharSet.Unicode, EntryPoint = "lmc1_Initial", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Lmc1Initial(string strEzCadPath, int bTestMode, IntPtr hOwenWnd);

        [DllImport("MarkEzd.dll", CharSet = CharSet.Unicode, EntryPoint = "lmc1_ClearEntLib", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1ClearEntLib();

        [DllImport("MarkEzd.dll", CharSet = CharSet.Unicode, EntryPoint = "lmc1_AddCurveToLib", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1_AddCurveToLib(double[,] ptBuf,int ptNum,string lineName,int nPenNo,int bHatch);

        [DllImport("MarkEzd.dll", CharSet = CharSet.Unicode, EntryPoint = "lmc1_Mark", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1Mark(int bFlyMark);

        [DllImport("MarkEzd.dll", CharSet = CharSet.Unicode, EntryPoint = "lmc1_MoveEnt", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1MoveEnt(string  Name,double OffsetX,double OffsetY);

        [DllImport("MarkEzd.dll", CharSet = CharSet.Unicode, EntryPoint = "lmc1_SetDevCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1_SetDevCfg();

    }
}
