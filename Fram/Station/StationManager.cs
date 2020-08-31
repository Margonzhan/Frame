using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using FileOperate;
namespace Fram.Station
{
   public  class StationManager:Singleton<StationManager>
    {
       public  Dictionary<string, StationBase> StationDictionary;//station collection
       public  StationManager()
        {
            StationDictionary = new Dictionary<string, StationBase>();
        }
        public   StationBase GetStationByName(string stationname)
        {
            StationBase _station = null;
            if(StationDictionary.ContainsKey(stationname))
            {
                _station = StationDictionary[stationname];
            }
            return _station;
        }
        public string InitAll()
        {
            string errorInfo = null;
            foreach(var mem in StationDictionary)
            {
                string error = null;
                mem.Value.Init(ref error);
                if (!string.IsNullOrEmpty(error))
                {
                    errorInfo += error;
                }
            }
            return errorInfo;
        }
        public void StartAll()
        {
           // if(string.IsNullOrEmpty(InitAll()))
            {
                foreach (var mem in StationDictionary)
                {
                    try
                    {
                        mem.Value.Start();
                    }
                    catch (Exception ex)
                    {
                        Log.WriteString(ex.Message);

                    }
                    
                   
                }
            }

        }
        public void StopAll()
        {          
            foreach (var mem in StationDictionary)
            {
                try
                {
                    mem.Value.Stop();
                }
                catch (Exception ex)
                {
                    Log.WriteString(ex.Message);
                }
            }           
        }
        public void SuspendAll()
        {
            foreach (var mem in StationDictionary)
            {
                try
                {
                    mem.Value.Stop();
                }
                catch (Exception ex)
                {
                    Log.WriteString(ex.Message);
                }
            }
        }
        public void ResumeAll()
        {
            foreach (var mem in StationDictionary)
            {
                try
                {
                    mem.Value.Resume();
                }
                catch (Exception ex)
                {
                    Log.WriteString(ex.Message);
                }
            }
        }       
    }
}
