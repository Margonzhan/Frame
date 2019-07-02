using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using HalconDotNet;
namespace Fram
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            HOperatorSet.SetSystem("clip_region", "false");
            HOperatorSet.SetSystem("flush_graphic", "false");
            HOperatorSet.SetSystem("alloctmp_max_blocksize", -1);
            HOperatorSet.SetSystem("image_cache_capacity", 4194304);
            //Free the image imediatly
            HOperatorSet.SetSystem("global_mem_cache", "idle");
            //Free the operator imediatly
            //.SetSystem("temporary_mem_cache", "false");
            HOperatorSet.SetSystem("do_low_error", "disabled");
            HOperatorSet.SetSystem("thread_num", 4);
            HOperatorSet.SetSystem("reentrant", "true");
            HOperatorSet.SetSystem("temporary_mem_cache", "false");
            HOperatorSet.SetSystem("backing_store", "true");
            bool RunOne;
            using (Process CurrentProcess = Process.GetCurrentProcess())
            {               
                string processname = CurrentProcess.ProcessName;
                System.Threading.Mutex run = new System.Threading.Mutex(true, processname, out RunOne);
            }
            if (RunOne)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            else
                MessageBox.Show("已经运行了一个实例");
        }
    }
}
