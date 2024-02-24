
namespace THE_BUCKETER
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bucketsList = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nbuckets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nchars = new System.Windows.Forms.TextBox();
            this.create = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.proxyTxt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updtaeParamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCrendtialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBucketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theOldest100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theOldest200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Bucket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copyanddrop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bucketsList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(867, 452);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 40);
            this.button2.TabIndex = 57;
            this.button2.Text = "Clear all";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(371, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 40);
            this.button1.TabIndex = 54;
            this.button1.Text = "Files";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Controls.Add(this.bucketsList);
            this.panel5.Location = new System.Drawing.Point(371, 12);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(649, 419);
            this.panel5.TabIndex = 53;
            // 
            // bucketsList
            // 
            this.bucketsList.AllowUserToAddRows = false;
            this.bucketsList.AllowUserToDeleteRows = false;
            this.bucketsList.AllowUserToOrderColumns = true;
            this.bucketsList.AllowUserToResizeRows = false;
            this.bucketsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bucketsList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.bucketsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bucketsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bucketsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.bucketsList.ColumnHeadersHeight = 30;
            this.bucketsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bucketsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bucket,
            this.copy,
            this.copyanddrop});
            this.bucketsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bucketsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bucketsList.EnableHeadersVisualStyles = false;
            this.bucketsList.GridColor = System.Drawing.Color.White;
            this.bucketsList.Location = new System.Drawing.Point(3, 3);
            this.bucketsList.Name = "bucketsList";
            this.bucketsList.RowHeadersVisible = false;
            this.bucketsList.RowTemplate.DividerHeight = 2;
            this.bucketsList.RowTemplate.Height = 35;
            this.bucketsList.Size = new System.Drawing.Size(643, 413);
            this.bucketsList.TabIndex = 59;
            this.bucketsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bucketsList_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(1042, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 19);
            this.label7.TabIndex = 20;
            this.label7.Text = "password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(1042, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 36);
            this.label6.TabIndex = 15;
            this.label6.Text = "Credentials";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel6.Location = new System.Drawing.Point(1042, 327);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(262, 4);
            this.panel6.TabIndex = 19;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.DodgerBlue;
            this.username.Location = new System.Drawing.Point(1042, 230);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(262, 17);
            this.username.TabIndex = 15;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.White;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.DodgerBlue;
            this.password.Location = new System.Drawing.Point(1042, 308);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(262, 17);
            this.password.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel7.Location = new System.Drawing.Point(1042, 249);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(262, 4);
            this.panel7.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(1042, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(1, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 36);
            this.label5.TabIndex = 52;
            this.label5.Text = "Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(7, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "N° of buckets:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.Location = new System.Drawing.Point(7, 375);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 4);
            this.panel4.TabIndex = 50;
            // 
            // nbuckets
            // 
            this.nbuckets.BackColor = System.Drawing.Color.White;
            this.nbuckets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nbuckets.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbuckets.ForeColor = System.Drawing.Color.DodgerBlue;
            this.nbuckets.Location = new System.Drawing.Point(7, 356);
            this.nbuckets.Name = "nbuckets";
            this.nbuckets.Size = new System.Drawing.Size(262, 17);
            this.nbuckets.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(7, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 48;
            this.label3.Text = "N° of characters:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(7, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 4);
            this.panel3.TabIndex = 47;
            // 
            // nchars
            // 
            this.nchars.BackColor = System.Drawing.Color.White;
            this.nchars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nchars.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nchars.ForeColor = System.Drawing.Color.DodgerBlue;
            this.nchars.Location = new System.Drawing.Point(7, 267);
            this.nchars.Name = "nchars";
            this.nchars.Size = new System.Drawing.Size(262, 17);
            this.nchars.TabIndex = 46;
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.White;
            this.create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.create.FlatAppearance.BorderSize = 2;
            this.create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.ForeColor = System.Drawing.Color.DodgerBlue;
            this.create.Location = new System.Drawing.Point(535, 452);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(160, 40);
            this.create.TabIndex = 45;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(7, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 44;
            this.label2.Text = "Port :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(7, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 4);
            this.panel2.TabIndex = 43;
            // 
            // portTxt
            // 
            this.portTxt.BackColor = System.Drawing.Color.White;
            this.portTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTxt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.portTxt.Location = new System.Drawing.Point(7, 188);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(262, 17);
            this.portTxt.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(7, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 41;
            this.label1.Text = "Proxy :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(7, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 4);
            this.panel1.TabIndex = 40;
            // 
            // proxyTxt
            // 
            this.proxyTxt.BackColor = System.Drawing.Color.White;
            this.proxyTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.proxyTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxyTxt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.proxyTxt.Location = new System.Drawing.Point(7, 110);
            this.proxyTxt.Name = "proxyTxt";
            this.proxyTxt.Size = new System.Drawing.Size(262, 17);
            this.proxyTxt.TabIndex = 39;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(371, 498);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 58;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.deleteBucketsToolStripMenuItem,
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1315, 29);
            this.menuStrip1.TabIndex = 60;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updtaeParamsToolStripMenuItem,
            this.updateCrendtialsToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // updtaeParamsToolStripMenuItem
            // 
            this.updtaeParamsToolStripMenuItem.Name = "updtaeParamsToolStripMenuItem";
            this.updtaeParamsToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.updtaeParamsToolStripMenuItem.Text = "Update parameters";
            this.updtaeParamsToolStripMenuItem.Click += new System.EventHandler(this.updtaeParamsToolStripMenuItem_Click);
            // 
            // updateCrendtialsToolStripMenuItem
            // 
            this.updateCrendtialsToolStripMenuItem.Name = "updateCrendtialsToolStripMenuItem";
            this.updateCrendtialsToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.updateCrendtialsToolStripMenuItem.Text = "Update Crendtials";
            this.updateCrendtialsToolStripMenuItem.Click += new System.EventHandler(this.updateCrendtialsToolStripMenuItem_Click);
            // 
            // deleteBucketsToolStripMenuItem
            // 
            this.deleteBucketsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theOldest100ToolStripMenuItem,
            this.theOldest200ToolStripMenuItem});
            this.deleteBucketsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.deleteBucketsToolStripMenuItem.Name = "deleteBucketsToolStripMenuItem";
            this.deleteBucketsToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.deleteBucketsToolStripMenuItem.Text = "Delete buckets";
            // 
            // theOldest100ToolStripMenuItem
            // 
            this.theOldest100ToolStripMenuItem.Name = "theOldest100ToolStripMenuItem";
            this.theOldest100ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.theOldest100ToolStripMenuItem.Text = "The oldest 100";
            this.theOldest100ToolStripMenuItem.Click += new System.EventHandler(this.theOldest100ToolStripMenuItem_Click);
            // 
            // theOldest200ToolStripMenuItem
            // 
            this.theOldest200ToolStripMenuItem.Name = "theOldest200ToolStripMenuItem";
            this.theOldest200ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.theOldest200ToolStripMenuItem.Text = "The oldest 200";
            this.theOldest200ToolStripMenuItem.Click += new System.EventHandler(this.theOldest200ToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button3.Location = new System.Drawing.Point(701, 452);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 40);
            this.button3.TabIndex = 61;
            this.button3.Text = "Copy all";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 21;
            this.comboBox1.Location = new System.Drawing.Point(7, 434);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 29);
            this.comboBox1.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Location = new System.Drawing.Point(7, 401);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 19);
            this.label10.TabIndex = 72;
            this.label10.Text = "Region :";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // Bucket
            // 
            this.Bucket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(141)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Bucket.DefaultCellStyle = dataGridViewCellStyle2;
            this.Bucket.FillWeight = 118.7817F;
            this.Bucket.HeaderText = "Bucket";
            this.Bucket.Name = "Bucket";
            // 
            // copy
            // 
            this.copy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.copy.DefaultCellStyle = dataGridViewCellStyle3;
            this.copy.FillWeight = 81.21828F;
            this.copy.HeaderText = "Copy";
            this.copy.Name = "copy";
            this.copy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.copy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.copy.ToolTipText = "Copy";
            // 
            // copyanddrop
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.copyanddrop.DefaultCellStyle = dataGridViewCellStyle4;
            this.copyanddrop.HeaderText = "Copy & Drop";
            this.copyanddrop.Name = "copyanddrop";
            this.copyanddrop.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1315, 550);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.username);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.nbuckets);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.nchars);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.proxyTxt);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THE BUCKETER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bucketsList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox nbuckets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox nchars;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox proxyTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView bucketsList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updtaeParamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCrendtialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBucketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theOldest200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theOldest100ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bucket;
        private System.Windows.Forms.DataGridViewTextBoxColumn copy;
        private System.Windows.Forms.DataGridViewTextBoxColumn copyanddrop;
    }
}

