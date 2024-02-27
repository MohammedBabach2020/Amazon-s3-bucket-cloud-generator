using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THE_BUCKETER
{
    public partial class launcher : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessageKey(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private const uint WM_SETTEXT = 0x000C;

        public launcher()
        {
            InitializeComponent();
        }
        Thread th1;
        Thread th2;
        static string GetSessionUsername()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            return identity != null ? identity.Name : "Unknown";
        }
        private void launcher_Load(object sender, EventArgs e)
        {

            button1.Location = new Point(330,330);

            //th1 = new Thread(changeThe_B_Location);
            //pictureBox1.Location = new Point(pictureBox1.Location.X, -217);
            //th2 = new Thread(changeThe_smile_Location);
            //th2.Start();

            //if (!th2.IsAlive)
            //{
            //    th1.Start();


            //}


        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

    

        private void changeThe_B_Location()
        {
         
            for (int i = -217; i <14; i++)
            {

                Invoke(new Action(() =>
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, i);
                }));
                Thread.Sleep(2);
            
            }
          
        }


        private void changeThe_Launch_Button_Location()
        {

            for (int i = 450; i > 367; i--)
            {
                Invoke(new Action(() =>
                {
                    button1.Location = new Point(button1.Location.X, i);
                }));
                Thread.Sleep(2);
             
            }

            }

        private void button1_Click_1(object sender, EventArgs e)
        {

             this.Hide();
            usingApi ua = new usingApi();
            ua.Show();
            //choices ch = new choices();
            //ch.Show();


        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void launcher_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
