using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonFunc
{
    public class Time_Meter
    {
        private long m_TimeStart;
        public Time_Meter()
        {
            m_TimeStart = DateTime.Now.Ticks;
        }
        public void Start()
        {
            m_TimeStart = DateTime.Now.Ticks;
        }
        /// <summary>
        /// 判断时间是否已经超过sencond秒
        /// </summary>
        /// <param name="second"> 时间是否已经超过second 秒 </param>
        /// <returns></returns>
        public bool IstimeOn(double  second)
        {
            double  timepass = (TimeSpan.FromTicks(DateTime.Now.Ticks) - TimeSpan.FromTicks(m_TimeStart)).TotalSeconds;
            if (second < timepass)
                return true;
            return false;
        }
        /// <summary>
        /// 获取从开始到现在经过的时间
        /// </summary>
        /// <returns> </returns>
        public double  TimePass()
        {
            return (TimeSpan.FromTicks(DateTime.Now.Ticks) - TimeSpan.FromTicks(m_TimeStart)).TotalSeconds;
        }
      
    }
}
