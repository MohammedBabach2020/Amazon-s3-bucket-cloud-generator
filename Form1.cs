using Amazon;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace THE_BUCKETER
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=" + Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\database.db;Version=3;providerName=System.Data.SqlClient";

        private FirefoxDriver[] drivers = new FirefoxDriver[100];
        private string[] files = new string[10];
        private int len = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void create_Click(object sender, EventArgs e)
        {
            if (proxyTxt.Text == "" || portTxt.Text == "" || nbuckets.Text == "" || nchars.Text == "" || username.Text == "" || password.Text == "" || len <= 0)
            {
                MessageBox.Show("Something missing bro ...");
            }
            else
            {
                Thread thr = new Thread(launch);
                thr.Start();
                create.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bucketsList.Columns[0].Width = (65 * bucketsList.Width) / 100;
            bucketsList.Columns[1].Width = (15 * bucketsList.Width) / 100;
            bucketsList.Columns[2].Width = (20 * bucketsList.Width) / 100;
            try
            {
                var EnumerableAllRegions = RegionEndpoint.EnumerableAllRegions;
                var regionsList = EnumerableAllRegions.ToList();

                for (int i = 0; i < regionsList.Count; i++)
                {
                    comboBox1.Items.Add(regionsList[i].SystemName);
                }


                SQLiteConnection conn = new SQLiteConnection(connectionString);
                SQLiteDataAdapter adpt = new SQLiteDataAdapter("select * from credentials", conn);
                DataTable tbl = new DataTable();
                adpt.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    username.Text = tbl.Rows[0].ItemArray[1].ToString();
                    password.Text = tbl.Rows[0].ItemArray[2].ToString();
                }

                conn = new SQLiteConnection(connectionString);
                adpt = new SQLiteDataAdapter("select * from parameters", conn);
                tbl = new DataTable();
                adpt.Fill(tbl);

                if (tbl.Rows.Count > 0)
                {
                    proxyTxt.Text = tbl.Rows[0].ItemArray[0].ToString();
                    portTxt.Text = tbl.Rows[0].ItemArray[1].ToString();
                    nchars.Text = tbl.Rows[0].ItemArray[2].ToString();
                    nbuckets.Text = tbl.Rows[0].ItemArray[3].ToString();
                    comboBox1.SelectedItem = tbl.Rows[0].ItemArray[4].ToString();
                }

                adpt = new SQLiteDataAdapter("select * from buckets", conn);
                tbl = new DataTable();
                adpt.Fill(tbl);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string[] row = { tbl.Rows[i].ItemArray[0].ToString(), "Copy", "Copy & Drop" };
                    bucketsList.Rows.Add(row);
                    if (tbl.Rows[i].ItemArray[1].ToString() == "1")
                    {
                        bucketsList.Rows[i].Cells[0].Style.BackColor = Color.Gray;
                        bucketsList.Rows[i].Cells[0].Style.SelectionBackColor = Color.Gray;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        public void launch()
        {
            try
            {
                FirefoxOptions options = new FirefoxOptions();
                Proxy proxy = new Proxy();
                proxy.Kind = ProxyKind.Manual;
                proxy.IsAutoDetect = false;
                proxy.SslProxy = proxyTxt.Text + ":" + portTxt.Text;
                options.Proxy = proxy;
                options.PageLoadStrategy = PageLoadStrategy.Normal;
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\WebDriver\bin\geckodriver.exe");
                FirefoxDriver driver = new FirefoxDriver(service, options);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                drivers[0] = driver;
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                string region = "";

                Invoke(new Action(() =>
                {
                    region = comboBox1.Text;
                }));
                driver.Navigate().GoToUrl("https://s3.console.aws.amazon.com/s3/buckets?region=1"+region);
                Thread.Sleep(3000);
                var usernameFied = driver.FindElement(By.Id("resolving_input"));
                wait.Until(d => usernameFied.Displayed);
                usernameFied.SendKeys(username.Text);

                var nextBtn = driver.FindElement(By.Id("next_button"));
                wait.Until(d => nextBtn.Displayed);
                nextBtn.Click();

                var passwordField = driver.FindElement(By.Id("password"));
                wait.Until(d => passwordField.Displayed);
                passwordField.SendKeys(password.Text);

                var signin_button = driver.FindElement(By.Id("signin_button_text"));
                wait.Until(d => signin_button.Displayed);
                signin_button.Click();

                Thread.Sleep(6000);

                for (int j = 0; j < Convert.ToInt32(nbuckets.Text); j++)
                {
                    var newbucket = this.createBucket();
                    driver.Navigate().GoToUrl("https://s3.console.aws.amazon.com/s3/buckets?region=us-east-1");
                    string createButton = (string)js.ExecuteScript("var createButton = document.getElementsByTagName('span'); for (var i = 0; i < createButton.length; i++){if (createButton[i].textContent  == 'Create bucket') { createButton[i].click(); } }");
                    var bucket = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div/div/div/div/div/div/div/main/div/div[2]/div/div/awsui-form/div/div[2]/span/span/div[1]/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/div/div/input"));
                    wait.Until(d => bucket.Displayed);
                    bucket.SendKeys(newbucket);

                    var enableAcls = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div/div/div/div/div/div/div/main/div/div[2]/div/div/awsui-form/div/div[2]/span/span/div[2]/div[1]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[2]"));
                    wait.Until(d => enableAcls.Displayed);
                    enableAcls.Click();

                    string blockPublicAccess = (string)js.ExecuteScript("var blockPublicAccess = document.getElementsByTagName('strong'); for (var i = 0; i < blockPublicAccess.length; i++){if (blockPublicAccess[i].innerHTML == 'Block <em>all</em> public access') { blockPublicAccess[i].click(); } }");
                    Thread.Sleep(1000);
                    string blockPublicAccessPermisson = (string)js.ExecuteScript("var blockPublicAccessPermisson = document.getElementsByTagName('span'); for (var i = 0; i < blockPublicAccessPermisson.length; i++){if (blockPublicAccessPermisson[i].textContent  == 'I acknowledge that the current settings might result in this bucket and the objects within becoming public.') { blockPublicAccessPermisson[i].click(); } }");
                    Thread.Sleep(1000);
                    createButton = (string)js.ExecuteScript("var createButton = document.getElementsByTagName('span'); for (var i = 0; i < createButton.length; i++){if (createButton[i].textContent  == 'Create bucket') { createButton[i].click(); } }");

                    Thread.Sleep(1000);
                    var urlBucket = "https://s3.console.aws.amazon.com/s3/upload/" + newbucket + "?region=us-east-1";
                    driver.Navigate().GoToUrl(urlBucket);
                    Thread.Sleep(2000);
                    for (int i = 0; i < files.Length; i++)
                    {
                        driver.FindElement(By.ClassName("upload-file-table__file-input")).SendKeys(files[i]);
                    }

                    string permissions = (string)js.ExecuteScript("var permissions = document.getElementsByTagName('span'); for (var i = 0; i < permissions.length; i++){if (permissions[i].innerHTML == 'Permissions') { permissions[i].click(); } }");
                    string Grant_public_read_access = (string)js.ExecuteScript("var Grant_public_read_access = document.getElementsByTagName('span'); for (var i = 0; i < Grant_public_read_access.length; i++){if (Grant_public_read_access[i].innerHTML == 'Grant public-read access') { Grant_public_read_access[i].click(); } }");
                    string publicaccess = (string)js.ExecuteScript("var publicaccess = document.getElementsByTagName('span'); for (var i = 0; i < publicaccess.length; i++){if (publicaccess[i].innerHTML == 'I understand the risk of granting public-read access to the specified objects.') { publicaccess[i].click(); } }");
                    string Upload = (string)js.ExecuteScript("var Upload = document.getElementsByTagName('span'); for (var i = 0; i < Upload.length; i++){if (Upload[i].textContent  == 'Upload') { Upload[i].click(); } }");

                    Invoke(new Action(() =>
                    {
                        string[] row = {newbucket, "Copy", "Copy & Drop" };
                        bucketsList.Rows.Add(row);
                        //richTextBox1.AppendText(newbucket + "\n");
                    }));

                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("insert into buckets (buck) values ('" + newbucket + "') ", conn);
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                        }
                 
                        conn.Close();
                    }

                    Thread.Sleep(files.Length * 1500);
                }
                Invoke(new Action(() =>
                {
                    create.Enabled = true;
                }));

              
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
                Invoke(new Action(() =>
                {
                    create.Enabled = true;
                }));
            }
        }

        private string createBucket()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void bucketsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                Clipboard.SetText(bucketsList.Rows[e.RowIndex].Cells[0].Value.ToString());
                bucketsList.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Gray;
                bucketsList.Rows[e.RowIndex].Cells[0].Style.SelectionBackColor = Color.Gray;
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

        private void updtaeParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (proxyTxt.Text != "" && portTxt.Text != "" && nchars.Text != "" && nbuckets.Text != "")
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("UPDATE parameters  SET proxy = '" + proxyTxt.Text + "' , port = '" + portTxt.Text + "', nchars = '" + nchars.Text + "'   , nbuckets = '" + nbuckets.Text + "' , region = '" + comboBox1.SelectedItem + "'       ", conn);
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

        private void updateCrendtialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text != "" && password.Text != "")
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new SQLiteCommand("UPDATE credentials SET username = '" + username.Text + "' , password = '" + password.Text + "'", conn);
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

        private void theOldest100ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Thread thr = new Thread(()=> { delete(100); });
            thr.Start();
            deleteBucketsToolStripMenuItem.Enabled = false;

        }

        private void theOldest200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(() => { delete(200); });
            thr.Start();
            deleteBucketsToolStripMenuItem.Enabled = false;


        }

        private void delete(int howmuch)
        {

            try
            {
                FirefoxOptions options = new FirefoxOptions();
                Proxy proxy = new Proxy();
                proxy.Kind = ProxyKind.Manual;
                proxy.IsAutoDetect = false;
                proxy.SslProxy = proxyTxt.Text + ":" + portTxt.Text;
                options.Proxy = proxy;
                options.PageLoadStrategy = PageLoadStrategy.Normal;
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\WebDriver\bin\geckodriver.exe");
                FirefoxDriver driver = new FirefoxDriver(service, options);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                drivers[0] = driver;
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                string region = "";

                Invoke(new Action(() =>
                {
                    region = comboBox1.Text;
                }));
                driver.Navigate().GoToUrl("https://s3.console.aws.amazon.com/s3/buckets?region=1" + region);
                
                Thread.Sleep(3000);

                var usernameFied = driver.FindElement(By.Id("resolving_input"));
                wait.Until(d => usernameFied.Displayed);
                usernameFied.SendKeys(username.Text);

                var nextBtn = driver.FindElement(By.Id("next_button"));
                wait.Until(d => nextBtn.Displayed);
                nextBtn.Click();

                var passwordField = driver.FindElement(By.Id("password"));
                wait.Until(d => passwordField.Displayed);
                passwordField.SendKeys(password.Text);

                var signin_button = driver.FindElement(By.Id("signin_button_text"));
                wait.Until(d => signin_button.Displayed);
                signin_button.Click();

                Thread.Sleep(6000);
                var sortBydate = (string)js.ExecuteScript("var sortBydate = document.getElementsByTagName('div'); for (var i = 0; i < sortBydate.length; i++){if (sortBydate[i].textContent  == 'Creation date') { sortBydate[i].click();sortBydate[i].click(); } }");
                Thread.Sleep(1000);


                for (int i = 0; i < howmuch; i++)
                {
                    Thread.Sleep(2000);
                    var chooseFirstelement = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div/div/div/div/div/main/div/div[2]/div/div/div[3]/div[2]/div/div/div/div/div[2]/div[1]/table/tbody/tr[1]/td[1]/label/span/span/span[1]/input"));
                    chooseFirstelement.Click();
                    Thread.Sleep(1000);

                    var emptyButton = (string)js.ExecuteScript("var emptyButton = document.getElementsByTagName('span'); for (var i = 0; i < emptyButton.length; i++){if (emptyButton[i].textContent  == 'Empty') { emptyButton[i].click(); } }");

                    Thread.Sleep(1000);
                    string fireEvent = "function fireEvent() { var awsui = document.querySelector('awsui-input'); awsui.value = 'permanently delete';if ('createEvent' in document) { var evt = document.createEvent('HTMLEvents');evt.initEvent('input', false, true);awsui.dispatchEvent(evt);} else {awsui.fireEvent('oninput');}}";
                    string permanentlyDeleteScript2 = "var emptyButton = document.getElementsByTagName('span'); for (var i = 0; i < emptyButton.length; i++){if (emptyButton[i].textContent  == 'Empty') { emptyButton[i].click(); } }";
                    string backifThebucketIsEmpty = "var backifThebucketIsEmpty = document.getElementsByTagName('span'); for (var i = 0; i < backifThebucketIsEmpty.length; i++){if (backifThebucketIsEmpty[i].textContent  == 'Buckets') { backifThebucketIsEmpty[i].click(); } }";
                    string backifThebucketIsNotEmpty = " setTimeout(()=>{ var backifThebucketIsNotEmpty = document.getElementsByTagName('span'); for (var i = 0; i < backifThebucketIsNotEmpty.length; i++){if (backifThebucketIsNotEmpty[i].textContent  == 'Exit') { backifThebucketIsNotEmpty[i].click(); } } } , 2000 ) ";

                    string permanentlyFinalScript = fireEvent + " const inputs = document.getElementsByTagName('input') ; for(var i=0; i<inputs.length ;i++){ if(inputs[i].getAttribute('placeholder') == 'permanently delete' ){ if(!inputs[i].hasAttribute('disabled')){ fireEvent() ; inputs[i].value = 'permanently delete'; " + permanentlyDeleteScript2 + backifThebucketIsNotEmpty + " } else{ " + backifThebucketIsEmpty + " }}}";

                    js.ExecuteScript(permanentlyFinalScript);
                    Thread.Sleep(3000);

                    chooseFirstelement = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div/div/div/div/div/main/div/div[2]/div/div/div[3]/div[2]/div/div/div/div/div[2]/div[1]/table/tbody/tr[1]/td[1]/label/span/span/span[1]/input"));
                    chooseFirstelement.Click();
                    Thread.Sleep(1000);
                    var deleteButton = (string)js.ExecuteScript("var deleteButton = document.getElementsByTagName('span'); for (var i = 0; i < deleteButton.length; i++){if (deleteButton[i].textContent  == 'Delete') { deleteButton[i].click(); } }");
                    Thread.Sleep(1000);
                    fireEvent = "function fireEvent() {var awsui = document.querySelector('awsui-input'); awsui.value = document.querySelectorAll('input[type=text]')[0].getAttribute('placeholder');if ('createEvent' in document) { var evt = document.createEvent('HTMLEvents');evt.initEvent('input', false, true);awsui.dispatchEvent(evt);} else {awsui.fireEvent('oninput');}}";
                    string bucketTodelete = fireEvent + " const inputs = document.getElementsByTagName('input') ; for(var i=0; i<inputs.length ;i++){ if(inputs[i].hasAttribute('placeholder')){ fireEvent() ; inputs[i].value = inputs[i].getAttribute('placeholder');  }}";
                    js.ExecuteScript(bucketTodelete);
                    Thread.Sleep(1000);
                    var finaleDeleteButn = (string)js.ExecuteScript("var finaleDeleteButn = document.getElementsByTagName('span'); for (var i = 0; i < finaleDeleteButn.length; i++){if (finaleDeleteButn[i].textContent  == 'Delete bucket') { finaleDeleteButn[i].click(); } }");

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Invoke(new Action(() =>
                {
                    deleteBucketsToolStripMenuItem.Enabled = true;
                }));
              
            }

        }


     

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(CopyAll);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }


        private void CopyAll()
        {
            var str = "";

            for (int i = 0; i < bucketsList.Rows.Count; i++)
            {
                str = str + bucketsList.Rows[i].Cells[0].Value.ToString() + "\n";
            }

            Clipboard.SetText(str);

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            choices ch = new choices();
            ch.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}