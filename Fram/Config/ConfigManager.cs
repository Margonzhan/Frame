using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using System.IO;
using FileOperate;
using Newtonsoft.Json;
using Fram.Hardware;
namespace Fram.Config
{
   public  class ConfigManager:Singleton<ConfigManager>
    {
        public const string ConfigFillContent = "Config\\ConfigFillContent.json";
        public HardWareConfigrationMuster HardWareConfigrationMuster { get; private set; }
        public ConfigManager()
        {
            if (!File.Exists(ConfigFillContent))
            {
                Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + ConfigFillContent} is not exist");
                throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory + ConfigFillContent} is not exist");
            }
            string contents = File.ReadAllText(ConfigFillContent);
            ConfigContent configContent = JsonConvert.DeserializeObject<ConfigContent>(contents);
            string _exceptioninfo = string.Empty;
            foreach (var mem in configContent.ConfigFillPath)
            {
                if (!mem.EndsWith(".json"))
                {
                    Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigFillContent} is not json file");
                    throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigFillContent} is not json file");
                }
                if (!File.Exists("Config\\" + mem))
                {
                    Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigFillContent} is not exist");
                    throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigFillContent} is not exist");
                }

                string _configinfo = File.ReadAllText("Config\\" + mem);
                HardWareConfigrationMuster = JsonConvert.DeserializeObject<HardWareConfigrationMuster>(_configinfo);
            }
        }      
       
    }
    /// <summary>
    /// save the config file path want to read 
    /// </summary>
   internal class ConfigContent
    {
        public string[] ConfigFillPath { get; set; }
    }
  public   class HardWareConfigrationMuster
    {
        List<MotionCardConfig> m_moitionCardConfigs = new List<MotionCardConfig>();
        List<IoCardConfig> m_ioCardConfigs = new List<IoCardConfig>();
        List<SingleIoDeviceConfig> m_singleIoDeviceConfigs = new List<SingleIoDeviceConfig>();
        List<CameraConfig> m_cameraConfigs = new List<CameraConfig>();
        public List<MotionCardConfig> MotionCardConfigs
        {
            get { return m_moitionCardConfigs; }
        }
        public List<IoCardConfig> IoCardConfigs
        {
            get { return m_ioCardConfigs; }          
        } 
        public List<SingleIoDeviceConfig> singleIoDeviceConfigs
        {
            get { return m_singleIoDeviceConfigs; }
        }
        public List<CameraConfig> CameraConfigs
        {
            get { return m_cameraConfigs; }
        }
    }
}
