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
        public string StationName { get;private  set; }
        public StationStatue StationStatue { get { return m_stationStatue; } protected set { m_stationStatue = value; } }
        
        #endregion
       public  StationBase(string stationname)
        {            
            StationName = stationname;
            m_task = new Task(ProcessTask, cancellationTokenSource.Token);
        }
        #region function
        /// <summary>
        /// Init station statue
        /// </summary>
        /// <returns></returns>
        public abstract void  Init(ref string ErrMessage);

        public abstract void AddFirstStep();
       
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

            if(m_stationStatue==StationStatue.Ready|| m_stationStatue == StationStatue.Stoped)
            {
                AddFirstStep();
                m_SuspendFalg = false;
                TaskRun();
                return;
            }
            if(m_stationStatue == StationStatue.Suspend)
            {
                m_SuspendFalg = false;
            }
        }
        private void TaskRun()
        {
            if (m_task.Status == TaskStatus.Created)
            {
                m_task.Start();
            }
            else if (m_task.Status == TaskStatus.Canceled || m_task.Status == TaskStatus.RanToCompletion)
            {
                cancellationTokenSource = new CancellationTokenSource();
                m_task = new Task( ProcessTask, cancellationTokenSource.Token);
                m_task.Start();
            }
            m_stationStatue = StationStatue.Running;
        }
        /// <summary>
        /// stop the station task
        /// </summary>
        public virtual   void Stop()
        {
            if (m_stationStatue == StationStatue.WaitingReady)
            {
                throw new Exception($"{StationName} is on the statue WaitingReady");
            }


            m_SuspendFalg = false;
            cancellationTokenSource.Cancel();
            m_stationStatue = StationStatue.Stoped;
            StepQueue.Clear();
        }
        /// <summary>
        /// suspend the station task
        /// </summary>
        public virtual  void Suspend()
        {          
            if(m_stationStatue==StationStatue.Running)
            {
                m_SuspendFalg = true;
                m_stationStatue = StationStatue.Suspend;
            }         
        }
   
        private async void ProcessTask()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                if(!m_SuspendFalg)
                {
                  await  Processor();
                }
                Thread.Sleep(10);
            }
        }
       protected virtual async Task  Processor()
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
        public int PopStep()
        {
          return   StepQueue.Dequeue();
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
