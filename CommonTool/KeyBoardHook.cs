using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Diagnostics;

namespace CommonFunc
{
    /********************************************************************************
   ** 类名称： KeyBoardHook
   ** 描述：键盘监视
   ** 作者： zd
   ** 创建时间：2017-11-29
   ** 最后修改人：（无）
   ** 最后修改时间：（无）
   ** 版权所有 (C) :zd
   *********************************************************************************/
    public   class KeyBoardHook
    {
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        //委托   
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;
        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，Acrobat Reader会在你截取之前获得键盘。   
        static HookProc KeyBoardHookProcedure;

        //设置钩子   
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子   
        public static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll")]
        //调用下一个钩子   
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public static void Hook_Start()
        {
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardHookProcedure,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //如果设置钩子失败.   
                if (hHook == 0)
                {
                    Hook_Clear();
                }
            }
        }

        /// <summary>  
        /// 取消钩子事件  
        /// </summary>  
        public static void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
            
        }

        public static int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                System.Windows.Forms.Keys k = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), kbh.vkCode.ToString());
                switch (k)
                {                
                    case System.Windows.Forms.Keys.A:
                        {
                            if (kbh.flags == 0)
                            {
                                // 这里写按下后做什么事  

                            }
                            else if (kbh.flags == 128)
                            {
                                //放开后做什么事 
                              //  ThreadProcess.ReadEagle();
                              
                            }
                            
                            
                        }
                        break;
                }
                
            }
           
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }  
    }
}
