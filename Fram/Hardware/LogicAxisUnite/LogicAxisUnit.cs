
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.LogicAxisUnite
{
   public  class LogicAxisUnit:HardwareBase
    {
        
        Dictionary<string, LogicAxis> logicAxisS = new Dictionary<string, LogicAxis>();
        Dictionary<string, AxisUnitPoint> axisUnitPoints = new Dictionary<string, AxisUnitPoint>();
        public LogicAxisUnit(string devicename, Guid guid) : base(devicename, guid)
        {

        }
        public void Home()
        {

        }
        public void LoadPoint(string productName)
        {
            string pointFileDir =$" {AppDomain.CurrentDomain.BaseDirectory}+\\PointsFile\\{productName}";
            string pointFilePath = $"{pointFileDir} + \\ + {DeviceName}.json";
            if (Directory.Exists(pointFileDir))
            {
                if (File.Exists(pointFilePath))
                {
                    string pointTxt = File.ReadAllText(pointFilePath);
                    Dictionary<string, AxisUnitPoint> valuePairs = JsonConvert.DeserializeObject<Dictionary<string, AxisUnitPoint>>(pointTxt);
                    axisUnitPoints.Clear();
                    axisUnitPoints = valuePairs;
                }
            }

        }
        public void MoveToPoint(string PointName)
        {
             AxisUnitPoint axisUnitPoint=  axisUnitPoints[PointName];
            if(axisUnitPoint!=null)
            {
                uint maxIndex = axisUnitPoint.axisPoints.Max(x => x.MoveIndex);
                uint minIndex = axisUnitPoint.axisPoints.Min(x => x.MoveIndex);
                for(uint i=minIndex;i<maxIndex+1;i++)
                {
                    List<AxisPoint> axisPoints= axisUnitPoint.axisPoints.FindAll(x => x.MoveIndex == i);
                    if(axisPoints==null)
                    {
                        continue;
                    }
                    Task[] tasks=new Task[axisPoints.Count];
                    for(int m=0;m< axisPoints.Count;m++)
                    {
                        logicAxisS[axisPoints[m].LogicAxisName].Motor.MoveVM = axisPoints[m].Speed;
                        tasks[m]=  logicAxisS[axisPoints[m].LogicAxisName].Motor.AbsMoveAsync((int)axisPoints[m].Position);
                    }
                    Task.WaitAll(tasks);
                }
            }
            else
            {
                throw new KeyNotFoundException($"not exist the point named as {PointName}");
            }
        }
        public void SavePoint(string productName)
        {
            string pointFileDir = $" {AppDomain.CurrentDomain.BaseDirectory}+\\PointsFile\\{productName}";
            string pointFilePath = $"{pointFileDir} + \\ + {DeviceName}.json";
            if (!Directory.Exists(pointFileDir))
            {
                Directory.CreateDirectory(pointFileDir);
            }
            string pointTxt = JsonConvert.SerializeObject(axisUnitPoints);
            File.WriteAllText(pointFilePath, pointTxt);
        }
        public void AddLogicAxis(string key, LogicAxis value)
        {
            if (logicAxisS.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            logicAxisS.Add(key, value);
        }
        public void RemoveLogicAxis(string key)
        {
            if (!logicAxisS.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            logicAxisS.Remove(key);
        }
        public LogicAxis GetLogicAxisByKey(string key)
        {
            return logicAxisS[key];
        }
        public Dictionary<string, LogicAxis> AxisDeviceS
        {
            get { return logicAxisS; }
        }

        public void AddPoint(string key, AxisUnitPoint value)
        {
            if (axisUnitPoints.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            axisUnitPoints.Add(key, value);
        }
        public void RemovePoint(string key)
        {
            if (!axisUnitPoints.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            axisUnitPoints.Remove(key);
        }
        public AxisUnitPoint GetPointByKey(string key)
        {
            return axisUnitPoints[key];
        }
        public Dictionary<string, AxisUnitPoint> AxisUnitPoints
        {
            get { return axisUnitPoints; }
        }




    }
}
