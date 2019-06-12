using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace CommonFunc
{
    /********************************************************************************
    ** 类名称： KeyboxFunc
    ** 描述：实现条码枪Keybox功能，光标在哪里，就在哪里输入字符
    ** 作者： zd
    ** 创建时间：2017-11-29
    ** 最后修改人：（无）
    ** 最后修改时间：（无）
    ** 版权所有 (C) :zd
    *********************************************************************************/
    public  class KeyboxFunc
    {

        [DllImport("user32.dll")]
        private  static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private  static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO lpgui);


        [StructLayout(LayoutKind.Sequential)]
        private  struct GUITHREADINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public rect rectCaret;
        }
        [StructLayout(LayoutKind.Sequential)]
        private  struct rect
        {
            int left;
            int top;
            int right;
            int bottom;
        }
       
        private static GUITHREADINFO? GetGuiThreadInfo(IntPtr hwnd)
        {
            GUITHREADINFO guiThreadInfo = new GUITHREADINFO();
            if (hwnd != IntPtr.Zero)
            {
                //Mbox.Info(GetTitle(hwnd), "O");
                uint threadId = GetWindowThreadProcessId(hwnd, IntPtr.Zero);


                guiThreadInfo.cbSize = Marshal.SizeOf(guiThreadInfo);

                if (GetGUIThreadInfo(threadId, ref guiThreadInfo) == false)

                    return null;
            }
            return guiThreadInfo;
        }      
       /// <summary>
        /// Show message at cursor position.
       /// </summary>
       /// <param name="text">message want to show</param>
        public static void SendText(string text)
        {
            IntPtr hwnd = GetForegroundWindow();
            if (String.IsNullOrEmpty(text))
                return;
            GUITHREADINFO? guiInfo = GetGuiThreadInfo(hwnd);
            if (guiInfo != null)
            {
                IntPtr ptr = (IntPtr)guiInfo.Value.hwndCaret;
                if (ptr != IntPtr.Zero)
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        SendMessage(ptr, 0x0102, (IntPtr)(int)text[i], IntPtr.Zero);
                    }
                }
            }
        }
    }
}
