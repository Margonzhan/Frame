using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    /// <summary>
    /// used for commucation class which needs to send something to tell other its online
    /// </summary>
   public  interface IHeartBeat
    {
        /// <summary>
        /// 心跳包发送关键字
        /// </summary>
        string HeartBeatKey { get; set; }

        /// <summary>
        /// 心跳包发送时间间隔,by millisecond
        /// </summary>
        int HeartBeatIntervals { get; set; }

        /// <summary>
        /// 是否启动心跳功能
        /// </summary>
        bool HeartBeatEnable { get; set; }




    }
}
