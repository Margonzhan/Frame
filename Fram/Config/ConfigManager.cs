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
using Newtonsoft.Json.Linq;
using Communication;

namespace Fram.Config
{
   public  class ConfigManager:Singleton<ConfigManager>
    {
        public const string ConfigFillContent = "Config\\ConfigFile\\ConfigFillContent.json";
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
                    Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\ConfigFile\\" + ConfigFillContent} is not json file");
                    throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\ConfigFile\\" + ConfigFillContent} is not json file");
                }
                if (!File.Exists("Config\\ConfigFile\\" + mem))
                {
                    Log.WriteString($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\ConfigFile\\" + ConfigFillContent} is not exist");
                    throw new IOException($"{AppDomain.CurrentDomain.BaseDirectory + "Config\\ConfigFile\\" + ConfigFillContent} is not exist");
                }

                string _configinfo = File.ReadAllText("Config\\ConfigFile\\" + mem);
              //  dataConverter dataConverter = new dataConverter();
             //   HardWareConfigrationMuster = JsonConvert.DeserializeObject<HardWareConfigrationMuster>(_configinfo, dataConverter);
                HardWareConfigrationMuster = JsonConvert.DeserializeObject<HardWareConfigrationMuster>(_configinfo);

            }
        }
        //public class dataConverter : DATACreationConverter<BaseCommunicateConfig>
        //{
        //    protected override BaseCommunicateConfig Create(Type objectType, JObject jObject)
        //    {
        //        string info;
        //        if (FieldExists("TcpClient", jObject))
        //        {
        //            info= jObject.ToString();
        //            return JsonConvert.DeserializeObject<TcpClientConfig>(info);
        //            // return new TcpClientCommunicate(jObject.Value<String>("LocalIpAddress"), jObject.Value<uint>("LocalPort"), jObject.Value<String>("RemoteIpAddress"), jObject.Value<uint>("RemotePort"));
        //        }
        //        else
        //        {
        //            info = jObject.ToString();
                    
        //            return  JsonConvert.DeserializeObject<SerialPortConfig>(info);
        //        }
        //    }

        //    private bool FieldExists(string fieldName, JObject jObject)
        //    {
        //        return jObject.Value<string>("ConnectType") == fieldName;
        //    }
        //}

        public abstract class DATACreationConverter<T> : JsonConverter
        {
            /// <summary>
        
            /// Create an instance of objectType, based properties in the JSON object

            /// </summary>

            /// <param name="objectType">type of object expected</param>

            /// <param name="jObject">

            /// contents of JSON object that will be deserialized

            /// </param>

            /// <returns></returns>
            protected abstract T Create(Type objectType, JObject jObject);

            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader,Type objectType,object existingValue,JsonSerializer serializer)
            {
                // Load JObject from stream
                JObject jObject = JObject.Load(reader);

                // Create target object based on JObject
                T target = Create(objectType, jObject);

                // Populate the object properties
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
            public override void WriteJson(JsonWriter writer,object value,JsonSerializer serializer)
            {
                throw new NotImplementedException();
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
        List<AxisConfig> m_axisConfigs = new List<AxisConfig>();
        List<CameraConfig> m_cameraConfigs = new List<CameraConfig>();
        List<SerialPortConfig> m_serialPortConfigs = new List<SerialPortConfig>();
        List<TcpClientConfig> m_tcpClientConfigs = new List<TcpClientConfig>();
        public List<MotionCardConfig> MotionCardConfigs
        {
            get { return m_moitionCardConfigs; }
        }
        public List<IoCardConfig> IoCardConfigs
        {
            get { return m_ioCardConfigs; }          
        } 
        public List<SingleIoDeviceConfig> SingleIoDeviceConfigs
        {
            get { return m_singleIoDeviceConfigs; }
        }
        public List<AxisConfig> AxisConfigs
        {
            get { return m_axisConfigs; }
        }
        public List<CameraConfig> CameraConfigs
        {
            get { return m_cameraConfigs; }
        }
        public List<SerialPortConfig> SerialPortConfigs
        {
            get { return m_serialPortConfigs; }
        }
        public List<TcpClientConfig> TcpClientConfigs
        {
            get { return m_tcpClientConfigs; }
        }
    }
}
