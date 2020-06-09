using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using CommonFunc;

namespace Fram
{
    /// <summary>
    /// 用于跨线程操作空间
    /// </summary>
  public  sealed class DelegateUIControl:Singleton<DelegateUIControl>
    {       
        #region 委托操作textbox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textboxname"></param>
        /// <param name="info"></要显示的信息>
        /// <param name="append"></追加模式还是覆盖>
        /// <param name="color"></字体颜色，如果为null，则默认黑色字体>       
        public void UpdateTextBox(string textboxname, string info, bool append, Color? color = null)
        {
            if(TxtBoxS.ContainsKey(textboxname))
            {
                if(TxtBoxS.TryGetValue(textboxname, out TextBox textBox))
                {
                    DelegateTextBox(textBox, info, append, color);
                }
            }          
        }       
        private void DelegateTextBox(TextBox textbox,string info,bool append,Color? color=null)
        {
            color = color ?? Color.Black;
            if (textbox.InvokeRequired)
            {
                if(append)
                    textbox.BeginInvoke(new Action(() => {textbox.ForeColor=(Color)color;  textbox.Text+=info; }));
                else
                    textbox.BeginInvoke(new Action(() => { textbox.ForeColor = (Color)color; textbox.Text = info; }));
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

        #endregion
        #region
        public void UpdateRichTBoxZD(string richTextBoxZdName, string info, bool append = true, Color? color = null, int fontSize = 9)
        {
            if (RichTxtBoxZdS.ContainsKey(richTextBoxZdName))
            {
                if (RichTxtBoxZdS.TryGetValue(richTextBoxZdName, out RichTextBoxZd richTextBoxZd))
                {
                    DelegateRichTBoxZD(richTextBoxZd, info, append, color, fontSize);
                }
            }
        }
        private void DelegateRichTBoxZD(RichTextBoxZd richTextBoxZd,string info,bool append=true,Color? color=null,int fontSize=9 )
        {
            color = color ?? Color.Black;
            
            if (richTextBoxZd.InvokeRequired)
            {
                if (append)
                    richTextBoxZd.BeginInvoke(new Action(() => {  richTextBoxZd.Append(info,color,fontSize); }));
                else
                    richTextBoxZd.BeginInvoke(new Action(() => { richTextBoxZd.ClearAll(); richTextBoxZd.Append(info, color, fontSize); }));
            }
            else
            {
                if (append)
                {
                    richTextBoxZd.Append(info, color, fontSize);
                    
                }
                else
                {
                    richTextBoxZd.ClearAll();
                    richTextBoxZd.Append(info, color, fontSize);
                }
            }
        }
        #endregion

        public Dictionary<string, TextBox> TxtBoxS = new Dictionary<string, TextBox>();
        public Dictionary<string, RichTextBoxZd> RichTxtBoxZdS = new Dictionary<string, RichTextBoxZd>();
    }
   
}
