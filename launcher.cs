using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THE_BUCKETER
{
    public partial class launcher : Form
    {
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


            th1 = new Thread(changeThe_B_Location);
            pictureBox1.Location = new Point(pictureBox1.Location.X, -217);
            th2 = new Thread(changeThe_smile_Location);
            th2.Start();

            if (!th2.IsAlive)
            {
                th1.Start();


            }
        

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

        private void changeThe_smile_Location()
        {

        
            for (int i = -428; i < 206; i++)
            {

                Invoke(new Action(() =>
                {
                 
                    panel1.Location = new Point(i, panel1.Location.Y);

                   
                }));

                if (i == 0)
                {
                    th1.Start();
                }
                Thread.Sleep(1);

            }
            Thread.Sleep(400);
            Invoke(new Action(() =>
            {

                pictureBox2.Visible = true;


            }));

            Thread th3 = new Thread(changeThe_Launch_Button_Location);
            th3.Start();
       

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            choices ch = new choices();
            ch.Show();


        }

        private void closeBtn_Click(object sender, EventArgs e)
        {

            try
            {

                if (th1.IsAlive)
                {
                    th1.Abort();

                }
                if (th2.IsAlive)
                {
                    th2.Abort();

                }
                Application.Exit();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
         

           

        }
    }
}
