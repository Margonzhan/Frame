using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Fram.Station
{
    public abstract class StationBase
    {
        #region 字段
        bool m_SuspendFalg = false;//暂停标志
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();//任务取消通知      
        Task m_task;
        protected Queue<int> StepQueue = new Queue<int>();
        StationStatue m_stationStatue = StationStatue.WaitingReady;
        #endregion
        #region 属性
        public string StationName { get; set; }
        public StationStatue StationStatue {get;}
        #endregion
        StationBase(string stationname)
        {            
            StationName = stationname;
            m_task = new Task(ProcessTask, cancellationTokenSource.Token);
        }
        #region
        /// <summary>
        /// Init station statue
        /// </summary>
        /// <returns></returns>
        public virtual bool Init(ref string ErrMessage) { return true; }
        /// <summary>
        /// start the station task
        /// </summary>
        public  void Start()
        {
            if(m_stationStatue==StationStatue.WaitingReady)
            {
                throw new Exception($"{StationName} is on the statue WaitingReady");
            }
            if (m_stationStatue == StationStatue.Running)
                return;
            Resume();
          
            if(m_task.Status==TaskStatus.Created)
            {
                m_task.Start();
            }
            else if(m_task.Status==TaskStatus.Canceled||m_task.Status==TaskStatus.RanToCompletion)
            {
                cancellationTokenSource = new CancellationTokenSource();
                m_task = new Task(ProcessTask, cancellationTokenSource.Token);
                m_task.Start();
            }
            m_stationStatue = StationStatue.Running;
        }
        /// <summary>
        /// stop the station task
        /// </summary>
        public  void Stop()
        {
            if (m_stationStatue == StationStatue.WaitingReady)
            {
                throw new Exception($"{StationName} is on the statue WaitingReady");
            }
            cancellationTokenSource.Cancel();
            m_stationStatue = StationStatue.Stoped;
        }
        /// <summary>
        /// suspend the station task
        /// </summary>
        public  void Suspend()
        {
            if (m_stationStatue != StationStatue.Running)
            {
                throw new Exception($"{StationName} is on the statue {m_stationStatue.ToString()}");
            }
            m_SuspendFalg = false ;
            m_stationStatue = StationStatue.Suspend;
        }
        /// <summary>
        /// resume the station task
        /// </summary>
        public  void Resume()
        {
            if (m_stationStatue != StationStatue.Suspend|| m_stationStatue != StationStatue.Running)
            {
                throw new Exception($"{StationName} is on the statue {m_stationStatue.ToString()}");
            }
            m_SuspendFalg = true;
            m_stationStatue = StationStatue.Running;
        }

        private  void ProcessTask()
        {
            while (cancellationTokenSource.IsCancellationRequested)
            {
                if(m_SuspendFalg)
                {
                    Processor();
                }
            }
        }
       protected virtual void  Processor()
        {


        }

        public  T PeekStep<T>() where T:struct
        {
            int rtn = StepQueue.Peek();
            if (Enum.TryParse(rtn.ToString(), out T result))
                return result;
            else
                return default(T);

        }
        public void PushStep<T>(T step) where T:struct
        {
            StepQueue.Enqueue(step.GetHashCode());
        }
        public void PopStep()
        {
            StepQueue.Dequeue();
        }
        public void PopAndPushStep<T>(T step) where T:struct
        {
            StepQueue.Dequeue();
            StepQueue.Enqueue(step.GetHashCode());
        }
        #endregion
    }
    public enum StationStatue
    {
        WaitingReady,
        Ready,
        Running,
        Stoped,
        Suspend
    }
}
