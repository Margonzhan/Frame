using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.Othrers
{
    /// <summary>
    /// 金橙子激光器
    /// </summary>
    public  class EzdLaser
    {

        const string mpath = "Laser\\MarkEzd.dll";

        [DllImport(mpath, CharSet = CharSet.Unicode, EntryPoint = "lmc1_Initial", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Lmc1Initial(string strEzCadPath, int bTestMode, IntPtr hOwenWnd);

        [DllImport(mpath, CharSet = CharSet.Unicode, EntryPoint = "lmc1_ClearEntLib", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1ClearEntLib();

        [DllImport(mpath, CharSet = CharSet.Unicode, EntryPoint = "lmc1_AddCurveToLib", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1_AddCurveToLib(double[,] ptBuf, int ptNum, string lineName, int nPenNo, int bHatch);

        [DllImport(mpath, CharSet = CharSet.Unicode, EntryPoint = "lmc1_Mark", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1Mark(int bFlyMark);

        [DllImport(mpath, CharSet = CharSet.Unicode, EntryPoint = "lmc1_MoveEnt", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1MoveEnt(string Name, double OffsetX, double OffsetY);

        [DllImport(mpath, CharSet = CharSet.Unicode, EntryPoint = "lmc1_SetDevCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1_SetDevCfg();
    }
}
