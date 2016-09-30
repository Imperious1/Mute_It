using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mute_It_
{

    public interface OnProcessesChangeListener
    {
        void onProcessChange(Process[] processes);
    }
    class ProcessMonitor
    {

        private OnProcessesChangeListener listener;

        public ProcessMonitor(OnProcessesChangeListener listener)
        {
            this.listener = listener;
        }

        public void startMonitor()
        {
            Thread thread = new Thread(delegate ()
            {
                Process[] processes = Process.GetProcesses();
                listener.onProcessChange(processes);
            });
            thread.Start();
        }
    }
}
