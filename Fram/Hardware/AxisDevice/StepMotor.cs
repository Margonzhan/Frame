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
        MotionCardBase m_motionCard;
        uint m_axisIndex;
        #endregion
        #region property
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
        public override double MoveAccV { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double MoveDecV { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double MoveV { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
        public StepMotor(MotionCardBase motionCard,uint axisindex, string devicename, Guid guid) : base(devicename, guid)
        {
            m_motionCard = motionCard;
            m_axisIndex = axisindex;
        }
        public override void Home(bool ispositivedir)
        {
           // m_motionCard.Home(m_axisIndex,)
        }
        public override void AbsMove(int position)
        {
            throw new NotImplementedException();
        }
        public override void JogStart(bool ispositivedir)
        {
            throw new NotImplementedException();
        }
        public override void JogStop()
        {
            throw new NotImplementedException();
        }
        public override void RelMove(int distance)
        {
            throw new NotImplementedException();
        }
    }

}

