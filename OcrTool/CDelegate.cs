using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using HalconDotNet;
using HalWindow;
using ViewROI;
namespace OcrTool
{
   
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
            public void UpdateHDisplay(string displyname, HObject image, List<RegionX> regionxlist, List<StringX> stringlist)
            {
                if (displyname == "FormSetHDisplay")
                {
                    DelegateHDisplay(FormSetHDisplay, image, regionxlist, stringlist);
                }
            }
            private void DelegateHDisplay(HDisplay disply, HObject image, List<RegionX> regionxlist, List<StringX> stringlist)
            {
                if (disply.InvokeRequired)
                {
                    disply.Invoke(new Action(() =>
                    {
                        disply.HImageX = image;
                        disply.HRegionXList = regionxlist;
                        disply.HStringXList = stringlist;
                    }));
                }
                else
                {
                    disply.HImageX = image;
                    disply.HRegionXList = regionxlist;
                    disply.HStringXList = stringlist;
                }
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
                else if(textboxname== "txt_CharsTrainf")
                {
                    DelegateTextBox(txt_CharsTrainf, info, append, color);
                }
            }
            private void DelegateTextBox(TextBox textbox, string info, bool append, Color? color = null)
            {
                color = color ?? Color.Black;
                if (textbox.InvokeRequired)
                {
                    if (append)
                        textbox.Invoke(new Action(() => { textbox.ForeColor = (Color)color; textbox.Text += info; }));
                    else
                        textbox.Invoke(new Action(() => { textbox.ForeColor = (Color)color; textbox.Text = info; }));
                }
                else
                {
                    if (append)
                    {
                        textbox.ForeColor = (Color)color; textbox.Text += info;
                    }
                    else
                    {
                        textbox.ForeColor = (Color)color; textbox.Text = info;
                    }
                }
            }

            public void DelegateButton(Button button, string info)
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
            public TextBox txt_ErrorMessage, txt_CharsTrainf;
            public HDisplay FormSetHDisplay;
        }
    
}
