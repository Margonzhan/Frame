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
       public  Dictionary<string, StationBase> StationDictionry;//station collection
       public  StationManager()
        {
            StationDictionry = new Dictionary<string, StationBase>();
        }
        private  StationBase GetStationByName(string stationname)
        {
            StationBase _station = null;
            if(StationDictionry.ContainsKey(stationname))
            {
                _station = StationDictionry[stationname];
            }
            return _station;
        }
        public string InitAll()
        {
            string errorInfo = null;
            foreach(var mem in StationDictionry)
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
            if(InitAll()==string.Empty)
            {
                foreach (var mem in StationDictionry)
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
            foreach (var mem in StationDictionry)
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
            foreach (var mem in StationDictionry)
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
            foreach (var mem in StationDictionry)
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
    }
}
