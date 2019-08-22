using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fram.Config;
using Fram.Hardware.IoCard;
namespace Fram.Hardware.IOBaseDevice
{
    [Serializable]
   public  class SingleIoDevice:HardwareBase, ISingleIoDevice
    {
        #region 
        IIoCard m_ioCard;
        bool m_IsInput;//true means input,
        int m_index;
        #endregion
        #region property
        public bool IsInput { get { return m_IsInput; } }
        public bool IsShow { get; set; } = true;
        
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ioCard">the iocard device to band</param>
        /// <param name="IsInput">the decice is a input or out io decice</param>
        /// <param name="index">the index to band to the iocard decice</param>
        public SingleIoDevice(IIoCard ioCard,bool IsInput,int index,string devicename,Guid guid):base(devicename,guid)
        {
            m_ioCard = ioCard;
            m_IsInput = IsInput;
            m_index = index;
        }
     
        public bool GetStatue()
        {
            if (m_IsInput)
                return m_ioCard.GetSingleInput(m_index);
            else
                return m_ioCard.GetSingleOutput(m_index);
        }
        public void SetStatue(bool value)
        {
            if (m_IsInput)
                return ;
            else
                m_ioCard.SetSingleOutput(m_index, value);
        }
    }
}
