using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using System.IO;
using FileOperate;
namespace Fram.Config
{
   public  class ConfigManager:Singleton<ConfigManager>
    {
        public const string ConfigFillContent = "Config\\ConfigFillContent.json";
        
        public ConfigManager()
        {
          if(!File.Exists(ConfigFillContent))
            {
                Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + ConfigFillContent} is not exist");
                throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory+ConfigFillContent} is not exist");
            }
            string contents = File.ReadAllText(ConfigFillContent);
            ConfigContent configContent = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigContent>(contents);
            foreach(var mem in configContent.ConfigFillPath)
            {

            }
        }
    }
    class ConfigContent
    {
        public string[] ConfigFillPath { get; set; }
    }
}
