using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.AxisDevice
{
   public  abstract class Motor:HardwareBase
    {
        public Motor(string devicename,Guid guid):base(devicename,guid)
        {

        }
        /// <summary>
        /// 电机停止
        /// </summary>
        public abstract void Stop();
       
        /// <summary>
        /// 回原点加速度
        /// </summary>
        public abstract double HomeAccV
        {
            get;set;
        }
        /// <summary>
        /// 回原点减速度
        /// </summary>
        public abstract double HomeDecV
        { get; set; }
        /// <summary>
        /// 回原点起始速度
        /// </summary>
        public abstract double HomeStartV
        { get; set; }
        /// <summary>
        /// 回原点最大速度
        /// </summary>
        public abstract double HomeMaxV
        { get; set; }
        /// <summary>
        /// 回原点方式，视轴卡定义而定
        /// </summary>
        public abstract int HomeMode
        { get; set; }
        /// <summary>
        /// 回原点方向
        /// </summary>
        public abstract int HomeDir
        {
            get;set;
        }
        /// <summary>
        /// 移动加速度
        /// </summary>
        public abstract  double MoveAccV
        { get; set; }
        /// <summary>
        /// 移动减速度
        /// </summary>
        public abstract double MoveDecV
        { get; set; }
        /// <summary>
        /// 移动起始速度
        /// </summary>
        public abstract double MoveVS
        { get; set; }
        /// <summary>
        /// 移动停止速度
        /// </summary>
        public abstract double MoveVE
        { get; set; }
        /// <summary>
        /// 移动最大速度
        /// </summary>
        public abstract double MoveVM
        { get; set; }
        /// <summary>
        /// 回原点函数
        /// </summary>
        /// <param name="homedir">回原点方向，true 为正向回原点，false 为负向回原点</param>
        /// <returns></returns>
        public abstract Task HomeAsync(bool homedir);
      /// <summary>
      /// 绝对移动函数
      /// </summary>
      /// <param name="position">绝对位置</param>
      /// <returns></returns>
         public abstract Task AbsMoveAsync(int position);  
        /// <summary>
        /// 相对移动函数
        /// </summary>
        /// <param name="distance">相对移动距离</param>
        /// <returns></returns>
         public abstract Task RelMoveAsync(int distance);
        /// <summary>
        /// jog运动开始
        /// </summary>
        /// <param name="ispositivedir"></param>
         public abstract void JogStart(bool ispositivedir);
        /// <summary>
        /// jog运动停止
        /// </summary>
         public abstract void JogStop();
        /// <summary>
        /// 获取轴相关io状态，比如限位信号，报警信号等
        /// </summary>
        /// <param name="data"></param>
        public abstract void GetAxisIoStatue(ref int data);
        /// <summary>
        /// 获取轴运动状态
        /// </summary>
        /// <param name="data"></param>
        public abstract void GetAxisMotionStatue(ref int data);
        /// <summary>
        /// 获取轴当前位置
        /// </summary>
        /// <param name="data"></param>
        public abstract void GetAxisCPoint(ref double data);
        /// <summary>
        /// 设置轴当前位置
        /// </summary>
        /// <param name="data"></param>
        public abstract void SetAxisCPoint(double data = 0);
    }
}
