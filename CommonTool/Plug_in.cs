using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace CommonFunc
{
   public  class Plug_in
    {
              
        [DllImport("user32.dll", EntryPoint = "FindWindow",CharSet=CharSet.Auto, SetLastError = true)]
        public  static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",CharSet=CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hwnd,  StringBuilder  name, int cch);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto,SetLastError = true)]
        public  static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);


        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, string lParam);

        [DllImport("user32", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        public static extern void SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]//, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern bool IsWindowEnabled(IntPtr hWnd);

       

        public static void SetText(IntPtr handle, string text)
        {
            if (handle != IntPtr.Zero)
            {
                if (IsWindowEnabled(handle))
                    Plug_in.SendMessage(handle, GloableParam.WM_SETTEXT, 0, text);
            }
        }
    }
   static class GloableParam
    {
        public  const uint BM_CLICK = 0xF5; //鼠标点击的消息
        public  const uint WM_SETTEXT = 0x000C;//修改text消息
        public  const uint WM_GETTEXT = 0x000D;//修改text消息
        public  const int WM_KEYUP = 0X101;
        public  const int WM_KEYDOWN = 0X0100;

   }
}
