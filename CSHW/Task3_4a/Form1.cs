using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3_4a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            myTimer.Tick += TimerTick;
        }

        int sec;
        string Tick()
        {
            sec++;
            var outputStringBuilder = new StringBuilder();

            if ((sec / 60).ToString().Length == 1)
            {
                outputStringBuilder.Append("0");
            }

            outputStringBuilder.Append(sec / 60).Append(" : ");

            if ((sec % 60).ToString().Length == 1)
            {
                outputStringBuilder.Append("0");
            }

            outputStringBuilder.Append(sec % 60);

            return outputStringBuilder.ToString();
        }
        void ResetSec()
        {
            sec = 0;
        }

        private void StartButton_MouseClick(object sender, MouseEventArgs e)
        {
            myTimer.Enabled = true;
        }

        private void StopButton_MouseClick(object sender, MouseEventArgs e)
        {
            myTimer.Enabled = false;
        }

        private void ResetButton_MouseClick(object sender, MouseEventArgs e)
        {
            myTimer.Stop();
            outputTextBox.Clear();
            ResetSec();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            outputTextBox.Text = Tick();
        }
    }
}
