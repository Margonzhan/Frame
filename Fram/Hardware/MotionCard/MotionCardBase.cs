using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fram.Hardware.IoCard;
namespace Fram.Hardware.MotionCard
{
    public class MotionCardBase : HardwareBase
    {
        protected int m_startAxisIndex;
        protected int m_totalAxisCount;
        protected int m_cardId;
        protected bool m_isInitialed = false;
        protected bool m_isLoadConfigFile = false;
        protected int m_cardIdMode = 0;//which way to get the card id,auto system assigned or manul dis switch

        public int StartAxisIndex
        {
            get { return m_startAxisIndex; }
        }
        public int TotalAxisCount
        {
            get { return m_totalAxisCount; }
        }
        public int CardId
        {
            get { return m_cardId; }
        }
        public MotionCardBase(string devicename, Guid guid, int cardid = 0, int cardidmode = 0) : base(devicename, guid)
        {
            m_cardId = cardid;
            m_cardIdMode = cardidmode;
        }

        public virtual bool Open() { return true; }
        public virtual void LoadConfigFile(string filepath) { }

        public virtual void Close() { }      
        #region Io Operate
        #endregion
        #region axis operate
        /// <summary>
        /// absolute move
        /// </summary>
        /// <param name="axisindex">the axis want to operate</param>
        /// <param name="acc">acceration</param>
        /// <param name="dec">decrease velocity </param>
        /// <param name="startv">the start velocity </param>
        /// <param name="maxv"> the max velocity</param>
        /// <param name="position"> the pos want to move to</param>
      //  public virtual async Task AbsMove(uint axisindex,uint acc,uint dec,uint startv,uint maxv,int position) { }
        public virtual async Task AbsMoveAsync(uint axisindex, int position) { }

        /// <summary>
        /// relative move
        /// </summary>
        /// <param name="axisindex">the axis want to operate</param>
        /// <param name="acc">acceration</param>
        /// <param name="dec">decrease velocity </param>
        /// <param name="startv">the start velocity </param>
        /// <param name="maxv"> the max velocity</param>
        /// <param name="position"> the plus want to move</param>
       // public virtual async Task  RelMoveAsync(uint axisindex, uint acc, uint dec, uint startv, uint maxv, int distance) { }
        public virtual async Task RelMoveAsync(uint axisindex, int distance) { }

        /// <summary>
        /// jog move
        /// </summary>
        /// <param name="axisindex">the axis want to operate</param>
        ///  <param name="acc">acceration</param>
        /// <param name="dec">decrease velocity </param>
        /// <param name="velocity">running velocity </param>
        /// <param name="positiveDirection">true means move to negative direciton</param>
       // public virtual void JogStart(uint axisindex, uint acc, uint dec, uint velocity, bool positiveDirection) { }

        public virtual void JogStart(uint axisindex, bool positiveDirection) { }
        public virtual void JogStop(uint axisindex) { }
        /// <summary>
        /// set the server on or off
        /// </summary>
        /// <param name="axisindex">the axis want to operate</param>
        /// <param name="value">on means power on,off means power off</param>
        public virtual void PowerSet(uint axisindex, bool value) { }
        public virtual async Task HomeAsync(uint axisindex) { }
        
        public virtual void AxisNormalStop(uint axisindex) { }
        public virtual void AxisEmgStop(uint axisindex) { }

        public virtual void SetAxisAcc(uint axisindex, double paramvalue) { }
        public virtual void GetAxisAcc(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisDec(uint axisindex, double paramvalue) { }
        public virtual void GetAxisDec(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisStartV(uint axisindex, double paramvalue) { }
        public virtual void GetAxisStartV(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisMaxV(uint axisindex, double paramvalue) { }
        public virtual void GetAxisMaxV(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisEndV(uint axisindex, double paramvalue) { }
        public virtual void GetAxisEndV(uint axisindex, ref double paramvalue) { }

        public virtual void SetAxisHomeAcc(uint axisindex, double paramvalue) { }
        public virtual void GetAxisHomeAcc(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisHomeStartV(uint axisindex, double paramvalue) { }
        public virtual void GetAxisHomeStartV(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisHomeMaxV(uint axisindex, double paramvalue) { }
        public virtual void GetAxisHomeMaxV(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisHomeDec(uint axisindex, double paramvalue) { }
        public virtual void GetAxisHomeDec(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisHomeMode(uint axisindex, int paramvalue) { }
        public virtual void GetAxisHomeMode(uint axisindex, ref int paramvalue) { }
        public virtual void SetAxisHomeDir(uint axisindex, int paramvalue) { }
        public virtual void GetAxisHomeDir(uint axisindex, ref int paramvalue) { }


        public virtual void GetAxisPosition(uint axisindex, ref double paramvalue) { }
        public virtual void SetAxisPosition(uint axisindex,  double paramvalue) { }

        public virtual void GetAxisIoData(uint axisindex, ref int value) { }
        public virtual void GetAxisStatue(uint axisindex,ref int value) { }
          #endregion
    }
    public enum MotionCardBrand
    {
        AdlinkAMP204c,
        AdlinkEMX100,
    }
}
