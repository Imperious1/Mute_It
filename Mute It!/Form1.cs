using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mute_It_
{
    public partial class Form1 : Form, OnProcessesChangeListener
    {

        private static Process[] processes;

        public Form1()
        {
            InitializeComponent();
        }

        private delegate void InsertIntoListDelegate(Process[] processes);

        public void onProcessChange(Process[] processes)
        {
            Form1.processes = processes;
            if (InvokeRequired) Invoke(new InsertIntoListDelegate(onProcessChange), new Object[] { processes });
            else
            {
               
                foreach (Process p in processes)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = p.ProcessName;
                    item.SubItems.Add(p.Id.ToString());
                    item.SubItems.Add("N/A");
                    item.SubItems.Add("God");
                    listView1.Items.Add(item);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void fuckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Process p in processes)
            {
                if(p.ProcessName == listView1.Items[listView1.SelectedIndices[0]].Text)
                {
                    p.Kill();
                }
            }
                // listView1.Items[listView1.SelectedIndices[0]].Text
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Process p in processes)
            {
                if (p.ProcessName == listView1.Items[listView1.SelectedIndices[0]].Text)
                {
                    ExecuteCommand("NirCmd.exe muteappvolume", p);
                }
            }
        }

        private static void ExecuteCommand(string v, Process process)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;
            ProcessInfo = new ProcessStartInfo("cmd.exe", String.Format("/K {0} {1}.exe 1", v, process.ProcessName));
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessInfo.UseShellExecute = true;
            Process = Process.Start(ProcessInfo);
        }
    }
}
