using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace FileOperate
{
   public  class Log
    {
       private static string FilePath = AppDomain.CurrentDomain.BaseDirectory+"Log";
       private static readonly object m_lock = new object();
       public static void WriteString(string message)
       {
           lock (m_lock)
           {
               string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
               
                   CreateFile(filename);
                   using (FileStream filestream = new FileStream(FilePath + "\\" + filename, FileMode.Append, FileAccess.Write))
                   {
                       filestream.Write(strTobyts(message), 0, strTobyts(message).Length);
                       filestream.Flush();
                       filestream.Close();
                   }
               
           }
       }
       private static void CreateFile(string filename)
       {
           if (!Directory.Exists(FilePath))
           {
               Directory.CreateDirectory(FilePath);         
           }
           if (!File.Exists(FilePath +"\\"+ filename))
           {              
               FileStream fs=File.Create(FilePath + "\\" + filename);
               fs.Close();             
           }     
       }
       private static byte[] strTobyts(string message)
       {
           byte[] data;
           string info = DateTime.Now.TimeOfDay.ToString() + "  :"+message+"\r\n";
           data = Encoding.UTF8.GetBytes(info);
           return data;
       }
    }
}
