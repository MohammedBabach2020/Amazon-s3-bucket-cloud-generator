using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THE_BUCKETER
{
    public partial class usingApi : Form
    {
        private string accessKey = "AKIA4AEZBICFAZYRXIG4";
        private string secretKey = "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";
        private string[] files = new string[10];
        private int len = 0;
        private string region ="";
     private string connectionString = @"Data Source=" + Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\database.db;Version=3;providerName=System.Data.SqlClient";
    // private string connectionString = @"Data Source=C:\Users\dev_team\source\repos\THE BUCKETER\THE BUCKETER\database.db;Version=3;providerName=System.Data.SqlClient";
        public usingApi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (proxy.Text != "")
            {
                if (port.Text != "")
                {
                    if (nchars.Text != "")
                    {
                        if (nBuckets.Text != "")
                        {
                            if (len > 0)
                            {


                                progressBar1.Maximum = Convert.ToInt32(nBuckets.Text);
                                progressBar1.Visible = true;
                                Thread thr = new Thread(createBucket);
                                thr.Start();
                                timer1.Start();
                                button1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Please choose the files you wanna upload on the buckets");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The number of buckets is undefined");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The number of characters is undefined");
                    }
                }
                else
                {
                    MessageBox.Show("The port is undefined");
                }
            }
            else
            {
                MessageBox.Show("The proxy is undefined");
            }
        }

        private string createBucketName()
        {
            char[] letters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'x', 'y', 'z' };
            var bucket = "";
            Random random = new Random();
            for (var i = 0; i < Convert.ToInt32(nchars.Text); i++)
            {
                int randomNumber = random.Next(35);
                bucket += letters[randomNumber];
            };
            return bucket;
        }

        private async void createBucket()
        {

            try
            {
                string proxyHost = proxy.Text;
            int proxyPort = Convert.ToInt32(port.Text);
            Invoke(new Action(() =>
            {
                string region = comboBox1.Text;
            }));
        
            var s3Config = new AmazonS3Config
            {
                ProxyHost = proxyHost,
                ProxyPort = proxyPort,
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };

            var s3Client = new AmazonS3Client(accessKeyText.Text, prvKeyText.Text, s3Config);
            for (int i = 0; i < Convert.ToInt32(nBuckets.Text); i++)
            {
                 
             
                    string bucketName = createBucketName();

                    var request = new PutBucketRequest
                    {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };
                    // Create the bucket
                    await s3Client.PutBucketAsync(request);
                    Console.WriteLine($"Bucket '{bucketName}' created successfully.");

                    var PutBucketOwnershipControlsRequest = new PutBucketOwnershipControlsRequest
                    {
                        BucketName = bucketName,
                        OwnershipControls = new OwnershipControls
                        {
                            Rules = new List<OwnershipControlsRule>
                {
                    new OwnershipControlsRule
                    {
                        ObjectOwnership = ObjectOwnership.BucketOwnerPreferred
                    }
                }
                        }
                    };

                    await s3Client.PutBucketOwnershipControlsAsync(PutBucketOwnershipControlsRequest);

                    PutPublicAccessBlockRequest PutPublicAccessBlockRequest = new PutPublicAccessBlockRequest
                    {
                        BucketName = bucketName,
                        PublicAccessBlockConfiguration = new PublicAccessBlockConfiguration
                        {
                            BlockPublicAcls = false,
                            IgnorePublicAcls = false,
                            BlockPublicPolicy = false,
                            RestrictPublicBuckets = false
                        }
                    };
                    await s3Client.PutPublicAccessBlockAsync(PutPublicAccessBlockRequest);
                    Console.WriteLine($"Public access enabled from the bucket '{bucketName}' successfully.");

                    string[] fileNames = files;

                    foreach (string filePath in fileNames)
                    {
                        // Get the file name without the path
                        string fileName = Path.GetFileName(filePath);

                            // Create a request to upload the file to the S3 bucket
                            PutObjectRequest PutObjectRequest = new PutObjectRequest
                            {
                                BucketName = bucketName,
                                Key = fileName,
                                FilePath = filePath
                            };

                            // Set the ACL of the object to make it public-read
                            PutObjectRequest.CannedACL = S3CannedACL.PublicRead;

                            // Upload the file
                            await s3Client.PutObjectAsync(PutObjectRequest);
                            Console.WriteLine($"Uploaded '{fileName}' and granted public-read access.");
                     
                    }

                    Invoke(new Action(() =>
                    {
                        string[] row = { bucketName, "Copy", "Copy & Drop" };
                        bucketsList.Rows.Add(row);
                        progressBar1.Value++;
                    }));
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("insert into buckets (buck) values ('" + bucketName + "') ", conn);
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                        }
                        cmd = new SQLiteCommand("insert into historic (bucket) values ('" + bucketName + "') ", conn);
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                        }

                        conn.Close();
                    }


             
              
            }


                Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    timer1.Stop();
                    label6.Text = "";
                }));

                t = 0;
                MessageBox.Show("Buckets has been created");

            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    timer1.Stop();
                    label6.Text = "";
                }));

            }

            _UpdateCount();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            files.Initialize();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label9.Text = "";
                len = openFileDialog1.FileNames.Length;
                files = openFileDialog1.FileNames;
                for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
                {
                    label9.Text = label9.Text + openFileDialog1.SafeFileNames[i] + " ";
                }
            }
            else
            {
                len = 0;
            }
        }

        private  void button3_Click(object sender, EventArgs e)
        {

            Thread th = new Thread(CopyAll);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();



        }

    

        private void CopyAll()
        {
            var str = "";
         
            for (int i = 0; i < bucketsList.Rows.Count;i++)
            {
                str = str + bucketsList.Rows[i].Cells[0].Value.ToString() + "\n";
            }

            Clipboard.SetText(str);

        }

        static async Task DeleteAllObjectsInBucketAsync(IAmazonS3 s3Client, string bucketName)
        {
            ListObjectsV2Response response = await s3Client.ListObjectsV2Async(new ListObjectsV2Request
            {
                BucketName = bucketName
            });

            foreach (S3Object entry in response.S3Objects)
            {
                await s3Client.DeleteObjectAsync(bucketName, entry.Key);
                Console.WriteLine($"Deleted object '{entry.Key}'");
            }
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.DodgerBlue;
        }

      

      

        private void updtaeParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (proxy.Text != "" && port.Text != "" && nchars.Text != "" && nBuckets.Text != "")
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("UPDATE parameters  SET proxy = '" + proxy.Text + "' , port = '" + port.Text + "', nchars = '" + nchars.Text + "'   , nbuckets = '" + nBuckets.Text + "' , region = '" +comboBox1.SelectedItem + "'       ", conn);
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                            MessageBox.Show("Parameters updated sucssefully");
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void usingApi_Load(object sender, EventArgs e)
        {
            try
            {

                bucketsList.Columns[0].Width = (65 * bucketsList.Width) / 100;
                bucketsList.Columns[1].Width = (15 * bucketsList.Width) / 100;
                bucketsList.Columns[2].Width = (20 * bucketsList.Width) / 100;

                var EnumerableAllRegions = RegionEndpoint.EnumerableAllRegions;
                var regionsList = EnumerableAllRegions.ToList();

                for (int i = 0; i< regionsList.Count;i++)
                {
                    comboBox1.Items.Add(regionsList[i].SystemName);
                }

                SQLiteConnection conn = new SQLiteConnection(connectionString);
                SQLiteDataAdapter adpt = new SQLiteDataAdapter("select * from credentials", conn);
                DataTable tbl = new DataTable();
                adpt.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    accessKeyText.Text = tbl.Rows[0].ItemArray[3].ToString();
                    prvKeyText.Text = tbl.Rows[0].ItemArray[4].ToString();
                }



                 conn = new SQLiteConnection(connectionString);
                 adpt = new SQLiteDataAdapter("select * from parameters", conn);
                 tbl = new DataTable();
                adpt.Fill(tbl);

                if (tbl.Rows.Count > 0)
                {
                    proxy.Text = tbl.Rows[0].ItemArray[0].ToString();
                    port.Text = tbl.Rows[0].ItemArray[1].ToString();
                    nchars.Text = tbl.Rows[0].ItemArray[2].ToString();
                    nBuckets.Text = tbl.Rows[0].ItemArray[3].ToString();
                    comboBox1.SelectedItem = tbl.Rows[0].ItemArray[4].ToString();
                }

                adpt = new SQLiteDataAdapter("select * from buckets", conn);
                tbl = new DataTable();
                adpt.Fill(tbl);

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string[] row = { tbl.Rows[i].ItemArray[0].ToString() , "Copy" ,"Copy & Drop" };
                    bucketsList.Rows.Add(row);

                    if(tbl.Rows[i].ItemArray[1].ToString() == "1")
                    {
                        bucketsList.Rows[i].Cells[0].Style.BackColor = Color.Gray;
                        bucketsList.Rows[i].Cells[0].Style.SelectionBackColor = Color.Gray;

                    }
                }



                _UpdateCount();

                // seting timer to update count each hour
                UpdateCount.Start();
                UpdateCount.Interval = 3600 * 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    

        async private void deleteBuckets(int howmuch)
        {
         
            string proxyHost = proxy.Text;
            int proxyPort = Convert.ToInt32(port.Text);
            Invoke(new Action(() =>
            {
                string region = comboBox1.Text;
            }));
          
            var s3Config = new AmazonS3Config
            {
                ProxyHost = proxyHost,
                ProxyPort = proxyPort,
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };

            var s3Client = new AmazonS3Client(accessKeyText.Text, prvKeyText.Text, s3Config);



            ListBucketsResponse listBuckets = await s3Client.ListBucketsAsync();

            // Limit the result to the first 100 buckets
            var first100Buckets = listBuckets.Buckets.ToList();



            int i = 0;

            foreach (var bucket in first100Buckets)
            {
                Console.WriteLine(bucket.BucketName);

                if (i < howmuch)
                {

                  
                        // Delete all objects in the bucket (empty the bucket first)
                        await DeleteAllObjectsInBucketAsync(s3Client, bucket.BucketName);

                        // Delete the empty bucket
                        var deleteBucketRequest = new DeleteBucketRequest
                        {
                            BucketName = bucket.BucketName
                        };

                        await s3Client.DeleteBucketAsync(deleteBucketRequest);

                        Console.WriteLine($"Bucket '{bucket.BucketName}' deleted successfully.");
                            Invoke(new Action(() =>
                            {
                                progressBar1.Value++;
                            }));

                   

                    i++;
                }
                else
                {
                    break;
                }

            }



            _UpdateCount();
            Invoke(new Action(() =>
            {
        
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                backToolStripMenuItem.Enabled = true;
                MessageBox.Show(howmuch.ToString() + " buckets deletd");
                timer1.Stop();
                label6.Text = "";
            }));


            t = 0;
      

        }


        private void theOldest100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

         private void theOldest200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 200;
            Thread th = new Thread(() => { deleteBuckets(200); });
            th.Start();
            timer1.Start();
            backToolStripMenuItem.Enabled = false;
        }

        private void bucketsList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                Clipboard.SetText(bucketsList.Rows[e.RowIndex].Cells[0].Value.ToString());
                bucketsList.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Gray;
                bucketsList.Rows[e.RowIndex].Cells[0].Style.SelectionBackColor = Color.Gray;

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {

                    conn.Open();
                    var cmd = new SQLiteCommand($"UPDATE buckets SET used = 1  WHERE buck = '{bucketsList.Rows[e.RowIndex].Cells[0].Value}'", conn);
                    if (cmd.ExecuteNonQuery() > -1)
                    {

                    }
                    conn.Close();
                }
                }

           else if (e.RowIndex > -1 && e.ColumnIndex == 2)
            {
                Clipboard.SetText(bucketsList.Rows[e.RowIndex].Cells[0].Value.ToString());
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand($"DELETE FROM buckets WHERE buck = '{bucketsList.Rows[e.RowIndex].Cells[0].Value}'", conn);
                    if (cmd.ExecuteNonQuery() > -1)
                    {
                        
                    }
                    conn.Close();
                }
                bucketsList.Rows.Remove(bucketsList.Rows[e.RowIndex]);
                MessageBox.Show("Deleted");


            }




        }

        private void bucketsList_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["copy"].Value = "Copy";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bucketsList.Rows.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM buckets", conn);
                if (cmd.ExecuteNonQuery() > -1)
                {
                    MessageBox.Show("Cleared");
                }
                conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            region = comboBox1.SelectedItem.ToString();
        }

        private void updateCrendtialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                if (accessKeyText.Text != "" && prvKeyText.Text != "")
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("UPDATE credentials SET accesskey = '" + accessKeyText.Text + "' , privateKey = '" + prvKeyText.Text + "'", conn);
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                            MessageBox.Show("Credentials updated sucssefully");
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ZZ(object sender, EventArgs e)
        {

        }

        int t = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            label6.Text = t.ToString() + " s";
        }

        private void deleteBucketsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string videoUrl = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)+@"\videoTutorial.zip";

            // Create a WebClient instance to download the file
            using (WebClient webClient = new WebClient())
            {
                // Prompt the user to choose a location to save the downloaded file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "videoTutorial.zip"; // Default file name
                saveFileDialog.Filter = "Video Files (*.zip)|*.zip|All files (*.*)|*.*";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string filePath = saveFileDialog.FileName;

                    // Download the video and save it to the selected file path
                    webClient.DownloadFile(videoUrl, filePath);

                    // Inform the user that the download is complete
                    MessageBox.Show("Download completed!");
                }
            }

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            choices ch = new choices();
            ch.Show();
        }

        private void usingApi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 100;
            Thread th = new Thread(() => { deleteBuckets(100); });
            th.Start();
            timer1.Start();
            backToolStripMenuItem.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 200;
            Thread th = new Thread(() => { deleteBuckets(200); });
            th.Start();
            timer1.Start();
            backToolStripMenuItem.Enabled = false;
        }



        async private void _UpdateCount()
        {
            string proxyHost = proxy.Text;
            int proxyPort = Convert.ToInt32(port.Text);


            if (proxyHost != "" && port.Text != "" && prvKeyText.Text != "" & accessKeyText.Text != "")
            {
                try
                {
                    var s3Config = new AmazonS3Config
                    {
                        ProxyHost = proxyHost,
                        ProxyPort = proxyPort,
                        RegionEndpoint = RegionEndpoint.GetBySystemName(region)
                    };

                    var s3Client = new AmazonS3Client(accessKeyText.Text, prvKeyText.Text, s3Config);
                    var bucketsList = await s3Client.ListBucketsAsync();

                    Invoke(new Action(() =>
                    {
                        updatedCount.Text = "Current buckets count = " + bucketsList.Buckets.Count.ToString();
                    }));
                  
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
       async private void UpdateCount_Tick(object sender, EventArgs e)
        {


            _UpdateCount();

        }
    }
}