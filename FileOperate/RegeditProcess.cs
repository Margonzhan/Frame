using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
namespace FileOperate
{
    /// <summary>
    /// 提供注册表文件的读写操作，目前只有current_user 目录下文件的读取
    /// </summary>
    class RegeditProcess
    {
        public object  ReadKey(string path, string keyname)
        {
            object returnValue = new object();
            RegistryKey software=null;
            try
            {
               software = Registry.CurrentUser.OpenSubKey(path, true);
               returnValue = software.GetValue(keyname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(software!=null)
                software.Close();
            }
            return returnValue;
        }
        
        public void WriteKey(string path, string keyname,string keyvalue)
        {
            RegistryKey key = null;
            RegistryKey software = null;
            try
            {
                key = Registry.CurrentUser;
                software = key.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
         
                software.SetValue("keyname", keyvalue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                key.Close();
            }
        }
    }
}
