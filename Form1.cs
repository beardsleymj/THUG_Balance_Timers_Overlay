using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUG_Balance_Timers_Overlay
{
    public partial class Form1 : Form
    {
        // Window dragging stuff
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        THUGTimers timers;
        Timer frameTimer = new Timer();
        
        public Form1()
        {
            InitializeComponent();

            timers = new THUGTimers();
            frameTimer.Tick += new EventHandler(timer_tick);
            frameTimer.Interval = 16;
            frameTimer.Enabled = true;
            frameTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Any_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Right)
            {
                this.ContextMenu = new ContextMenu();
                this.ContextMenu.MenuItems.Add("Always on top", menu_item_top);
                this.ContextMenu.MenuItems.Add("Exit", menu_item_exit);
            }
        }

        private void Any_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            double manual = timers.GetManualTimer();
            double grind = timers.GetGrindTimer();
            
            // Keep value after combo ends
            if (manual != 0.0 || grind != 0.0)
            {
                manualLabel.Text = String.Format("{0:#0.00}", timers.GetManualTimer());
                grindLabel.Text = String.Format("{0:#0.00}", timers.GetGrindTimer());
            }

        }

        private void menu_item_top(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.ContextMenu.MenuItems[0].Checked = false;
                this.TopMost = false;
            }
            else // TopMost == false
            {
                this.ContextMenu.MenuItems[0].Checked = true;
                this.TopMost = true;
            }

        }

        private void menu_item_exit(object sender, EventArgs e)
        {
            Close();
        }
    }
}
