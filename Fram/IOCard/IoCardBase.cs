using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.IOCard
{
   public  class IoCardBase:IIoCard
    {
        #region property
        public string DeviceName { get; private set; }
        public Guid Guid { get; set; }
        public string CardType { get; private set; }
        #endregion
        #region method
        public IoCardBase()
        { }
        public virtual bool Open() { return true; }
        public virtual void Close() { }
        public virtual bool GetSingleInput(int index) { return false; }
        public virtual bool GetSingleOutput(int index) { return false; }
        public virtual void SetSingleOutput(int index, bool value) { }

        public virtual  int GetMultiInput(int startindex, int offset) { return 0; }
        public virtual int GetMultiOutput(int startindex,int offset) { return 0; }
        public virtual void SetMultiOutPut(int startindex,int value) { }
        #endregion
    }
}
