﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Fram
{
    /// <summary>
    /// 用于跨线程操作空间
    /// </summary>
    class DelegateUIControl
    {
        private static DelegateUIControl m_Instance;
        private readonly static object m_lock = new object();
        public static DelegateUIControl GetInstance()
        {
            if (m_Instance == null)
            {
                lock (m_lock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new DelegateUIControl();
                    }              
                }
            }
            return m_Instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textboxname"></param>
        /// <param name="info"></要显示的信息>
        /// <param name="append"></追加模式还是覆盖>
        /// <param name="color"></字体颜色，如果为null，则默认黑色字体>       
        public void UpdateTextBox(string textboxname, string info, bool append, Color? color = null)
        {
            if (textboxname == "txt_ErrorMessage")
            {
                DelegateTextBox(txt_ErrorMessage, info, append, color);
            }
        }       
        private void DelegateTextBox(TextBox textbox,string info,bool append,Color? color=null)
        {
            color = color ?? Color.Black;
            if (textbox.InvokeRequired)
            {
                if(append)
                textbox.Invoke(new Action(() => {textbox.ForeColor=(Color)color;  textbox.Text+=info; }));
                else
                    textbox.Invoke(new Action(() => { textbox.ForeColor = (Color)color; textbox.Text = info; }));
            }
            else
            {
                if (append)
                   { textbox.ForeColor = (Color)color; textbox.Text += info; 
                }
                else
                    { textbox.ForeColor = (Color)color; textbox.Text = info;
                }
            }
        }
        
        public  void DelegateButton(Button button, string info)
        {

            if (button.InvokeRequired)
            {
                button.Invoke(new Action(() => { button.Text = info; }));
            }
            else
            {
                button.Text = info;
            }
        }
        public TextBox txt_ErrorMessage;
    }
   
}