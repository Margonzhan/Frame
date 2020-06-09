using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fram.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Core.Tests
{
    [TestClass()]
    public class BindingListThreadSafeTests
    {
        [TestMethod()]
        public void BindingListThreadSafeTest()
        {
            BindingListThreadSafe<double> list = new BindingListThreadSafe<double>(2);

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                list.Add(r.NextDouble());
            }
        }
    }
}