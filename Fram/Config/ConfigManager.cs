using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using System.IO;
using FileOperate;
using Newtonsoft.Json;
namespace Fram.Config
{
   public  class ConfigManager:Singleton<ConfigManager>
    {
        public const string ConfigFillContent = "Config\\ConfigFillContent.json";
        public HardWareConfigrationMuster HardWareConfigrationMuster { get; }
        public ConfigManager()
        {
          if(!File.Exists(ConfigFillContent))
            {
                Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + ConfigFillContent} is not exist");
                throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory+ConfigFillContent} is not exist");
            }
            string contents = File.ReadAllText(ConfigFillContent);
            ConfigContent configContent =JsonConvert.DeserializeObject<ConfigContent>(contents);
            string _exceptioninfo = string.Empty;
            foreach (var mem in configContent.ConfigFillPath)
            {
                if(!mem.EndsWith(".json"))
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
        List<IoCardConfig> m_ioCardConfigs = new List<IoCardConfig>();
        public List<IoCardConfig> IoCardConfigs
        {
            get { return m_ioCardConfigs; }
           
        } 
    }
}
