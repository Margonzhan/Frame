using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fram
{
    /// <summary>
    /// 项目全局变量
    /// </summary>
    public   class MachineStatueControl
    {
        
        MachineStatue machineStatue = MachineStatue.WAITINGINIT;
        readonly object m_lock = new object();
        public   event  EventHandler<MachineStatueChangeEventArgs> MachineStatueChangeHandle ;
        public    MachineStatue MachineStatue
        {

            get
            {
                lock (m_lock)
                    return machineStatue;
            }
            set
            {
                lock (m_lock)
                {
                    if (machineStatue != value)
                    {
                        if(MachineStatueChangeHandle!=null)
                        {
                            MachineStatueChangeEventArgs e = new MachineStatueChangeEventArgs() { MachineStatue = value };
                            MachineStatueChangeHandle(this, e);
                        }
                    }
                    machineStatue = value;

                }
            }
        }

     
    }
    public class MachineStatueChangeEventArgs:EventArgs
    {
      public   MachineStatue MachineStatue { get; set; }
    }

    public enum MachineStatue
    {
        WAITINGINIT,//等待初始化
        RUNNING,//运行中
        WAITINGRUN,//等待运行
        RESETING,//复位中
        SUSPENDING,//暂停中
        STOPING,//停止中
        EMERGENCYSTOPING//紧急停止中
    }
}
