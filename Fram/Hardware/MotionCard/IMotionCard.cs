using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.MotionCard
{
  public interface IMotionCard
    {
        bool Open();
        void Close();
    }
}
