using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fram.Hardware.MotionCard;
namespace Fram.Hardware.AxisDevice
{
    public class StepMotor : Motor
    {
        #region
      protected  MotionCardBase m_motionCard;
      protected  uint m_axisIndex;
        #endregion
        #region property
        public bool PowerStatue
        {
            get
            {
                int v = 0;
                m_motionCard.GetAxisIoData(m_axisIndex, ref v);
                return (v & (1 << 7)) != 0;
            }
            set
            {
                m_motionCard.PowerSet(m_axisIndex, value);
            }
        }
        public bool Busy
        {
            get
            {
                int v = 0;
                m_motionCard.GetAxisStatue(m_axisIndex, ref v);
              return   (v & (1 << 1)) != 0;
            }
        }
        public override double HomeAccV
        {
            get
            {
                double data=0;
                 m_motionCard.GetAxisHomeAcc(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisHomeAcc(m_axisIndex, value); }
        }
        public override void Stop()
        {
            m_motionCard.AxisEmgStop(m_axisIndex);
        }
        public override double HomeDecV
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisHomeDec(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisHomeDec(m_axisIndex, value); }
        }
        public override double HomeStartV
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisHomeStartV(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisHomeStartV(m_axisIndex, value); }
        }
        public override double HomeMaxV
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisHomeMaxV(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisHomeMaxV(m_axisIndex, value); }
        }
        public override int HomeMode
        {
            get
            {
                int data = 0;
                m_motionCard.GetAxisHomeMode(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisHomeMode(m_axisIndex, value); }
        }
        public override int HomeDir
        {
            get
            {
                int data = 0;
                m_motionCard.GetAxisHomeDir(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisHomeDir(m_axisIndex, value); }
        }

        public override double MoveAccV
        {
            get
            {
                double  data = 0;
                m_motionCard.GetAxisAcc(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisAcc(m_axisIndex, value); }
          
        }
        public override double MoveDecV
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisDec(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisDec(m_axisIndex, value); }
        }
        public override double MoveVS
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisStartV(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisStartV(m_axisIndex, value); }
        }
        public override double MoveVE
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisEndV(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisEndV(m_axisIndex, value); }
        }
        public override double MoveVM
        {
            get
            {
                double data = 0;
                m_motionCard.GetAxisMaxV(m_axisIndex, ref data);
                return data;
            }
            set { m_motionCard.SetAxisMaxV(m_axisIndex, value); }
        }
        #endregion
        public StepMotor(MotionCardBase motionCard,uint axisindex, string devicename, Guid guid) : base(devicename, guid)
        {
            m_motionCard = motionCard;
            m_axisIndex = axisindex;
        }
        public override async Task HomeAsync(bool ispositivedir)
        {
            if(ispositivedir)
              await m_motionCard.HomeAsync(m_axisIndex); 
            else
              await m_motionCard.HomeAsync(m_axisIndex);
        }
     
        public override async  Task AbsMoveAsync(int position)
        {
            await m_motionCard.AbsMoveAsync(m_axisIndex, position);
        }  
        public override void JogStart(bool ispositivedir)
        {
            m_motionCard.JogStart(m_axisIndex, ispositivedir);
        }
        public override void JogStop()
        {
            m_motionCard.JogStop(m_axisIndex);
        }
        public override async Task RelMoveAsync(int distance)
        {
            await m_motionCard.RelMoveAsync(m_axisIndex, distance);
        }
        public override void GetAxisIoStatue(ref int data)
        {
            m_motionCard.GetAxisIoData(m_axisIndex, ref data);

        }
        public override void GetAxisMotionStatue(ref int data)
        {
            m_motionCard.GetAxisStatue(m_axisIndex, ref data);
        }
        public override void GetAxisCPoint(ref double data)
        {
            m_motionCard.GetAxisPosition(m_axisIndex, ref data);
        }
        public override void SetAxisCPoint(double data = 0)
        {
            m_motionCard.SetAxisPosition(m_axisIndex, data);
        }
    }

}

