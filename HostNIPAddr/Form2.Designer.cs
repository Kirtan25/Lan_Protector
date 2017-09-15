using System.Runtime.InteropServices;
namespace HostNIPAddr
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.netBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.netInfoDataSet = new HostNIPAddr.NetInfoDataSet();
            this.netTableAdapter = new HostNIPAddr.NetInfoDataSetTableAdapters.NetTableAdapter();
            this.ListHostIP = new System.Windows.Forms.ListView();
            this.PhyAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IpAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Colse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.netBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netInfoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // netBindingSource
            // 
            this.netBindingSource.DataMember = "Net";
            this.netBindingSource.DataSource = this.netInfoDataSet;
            // 
            // netInfoDataSet
            // 
            this.netInfoDataSet.DataSetName = "NetInfoDataSet";
            this.netInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // netTableAdapter
            // 
            this.netTableAdapter.ClearBeforeFill = true;
            // 
            // ListHostIP
            // 
            this.ListHostIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PhyAdd,
            this.HostName,
            this.IpAddr});
            this.ListHostIP.Location = new System.Drawing.Point(12, 2);
            this.ListHostIP.Name = "ListHostIP";
            this.ListHostIP.Size = new System.Drawing.Size(336, 272);
            this.ListHostIP.TabIndex = 6;
            this.ListHostIP.UseCompatibleStateImageBehavior = false;
            this.ListHostIP.View = System.Windows.Forms.View.Details;
            this.ListHostIP.SelectedIndexChanged += new System.EventHandler(this.ListHostIP_SelectedIndexChanged);
            // 
            // PhyAdd
            // 
            this.PhyAdd.Text = "Physical Address";
            this.PhyAdd.Width = 125;
            // 
            // HostName
            // 
            this.HostName.Text = "IP Address";
            this.HostName.Width = 100;
            // 
            // IpAddr
            // 
            this.IpAddr.Text = "Host Name";
            this.IpAddr.Width = 105;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Form2_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Rebuild Network Information";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HostNIPAddr.Properties.Resources.Capture11;
            this.pictureBox1.Location = new System.Drawing.Point(238, 280);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 58);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Colse
            // 
            this.Colse.Location = new System.Drawing.Point(52, 315);
            this.Colse.Name = "Colse";
            this.Colse.Size = new System.Drawing.Size(75, 23);
            this.Colse.TabIndex = 9;
            this.Colse.Text = "Close";
            this.Colse.UseVisualStyleBackColor = true;
            this.Colse.Click += new System.EventHandler(this.Colse_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 348);
            this.Controls.Add(this.Colse);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListHostIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Network Status";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.netBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netInfoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NetInfoDataSet netInfoDataSet;
        private System.Windows.Forms.BindingSource netBindingSource;
        private NetInfoDataSetTableAdapters.NetTableAdapter netTableAdapter;
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);

        internal System.Windows.Forms.ListView ListHostIP;
        internal System.Windows.Forms.ColumnHeader HostName;
        internal System.Windows.Forms.ColumnHeader IpAddr;
        private System.Windows.Forms.ColumnHeader PhyAdd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Colse;


    }
}