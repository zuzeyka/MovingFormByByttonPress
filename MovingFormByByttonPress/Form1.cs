using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingFormByByttonPress
{
    public partial class Form1 : Form
    {
        DateTime StartTime;
        public Form1()
        {
            InitializeComponent();
            StartTime = DateTime.Now;
            label1.Text += StartTime;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point AfterRevievLocation = this.Location;
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    if (this.Location.X - 50 < 0)
                        AfterRevievLocation.X = 0;
                    else
                        AfterRevievLocation.X -= 50;
                    break;
                case Keys.Right:
                case Keys.D:
                    if (this.Location.X + this.Width + 50 > Screen.GetWorkingArea(AfterRevievLocation).Width)
                        AfterRevievLocation.X = Screen.GetWorkingArea(AfterRevievLocation).Width - this.Width;
                    else
                        AfterRevievLocation.X += 50;
                    break;
                case Keys.Up:
                case Keys.W:
                    if (this.Location.Y - 50 < 0)
                        AfterRevievLocation.Y = 0;
                    else
                        AfterRevievLocation.Y -= 50;
                    break;
                case Keys.Down:
                case Keys.S:
                    if (this.Location.Y + this.Height + 50 > Screen.GetWorkingArea(AfterRevievLocation).Height)
                        AfterRevievLocation.Y = Screen.GetWorkingArea(AfterRevievLocation).Height - this.Height;
                    else
                        AfterRevievLocation.Y += 50;
                    break;
            }
            this.Location = AfterRevievLocation;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var Miliseconds = (DateTime.Now - StartTime).TotalMilliseconds - 3;
            label2.Text = "Stop:" + DateTime.Now;
            if (Miliseconds >= 5000)
            {
                System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
                timer1.Enabled = false;
            }
            this.Text = Convert.ToString(Miliseconds);
        }
    }
}
