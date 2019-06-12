using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace FileOperate
{
   public class INI
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string KeyName, string KeyValue, string FilePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string KeyName, string ValueDefult, StringBuilder KeyValue, int Size, string FilePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string KeyName, string ValueDefult, byte[] KeyValue, int Size, string FilePath);
       
       
       public long IniWrite(string Section, string KeyName, string KeyValue, string FilePath)
        {
            return WritePrivateProfileString(Section, KeyName, KeyValue, FilePath);
        }
        public int IniRead(string Section, string KeyName, StringBuilder KeyValue, string FilePath)
        {
            return GetPrivateProfileString(Section, KeyName, "defult", KeyValue, 2048, FilePath);
        }
        public string[] IniReadKey(string Section, string FilePath)
        {
            byte[] data=new byte[2048];
            string[] key;
            GetPrivateProfileString(Section, null, "defult", data, 2048, FilePath);
            string result = Encoding.UTF8.GetString(data);
            string str = result.Trim('\0');
            key = str.Split('\0');
            return key;
        }
        public string[] IniReadSection( string FilePath)
        {
            byte[] data = new byte[2048];
            string[] section;
            GetPrivateProfileString(null, null, "defult", data, 2048, FilePath);
            string result = Encoding.UTF8.GetString(data);
            string str = result.Trim('\0');
            section = str.Split('\0');
            return section;
        }

    }
}
