using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace HostNIPAddr
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button ButClose;
		internal System.Windows.Forms.Button ButDisplay;
		internal System.Windows.Forms.ListView ListHostIP;
		internal System.Windows.Forms.ColumnHeader HostName;
		internal System.Windows.Forms.ColumnHeader IpAddr;
		internal System.Windows.Forms.StatusBar Status;
		private System.Windows.Forms.TextBox TxtWorkGroup;
		private System.Windows.Forms.Label label1;
        private Label label2;
        private Button button1;
        private PictureBox pictureBox1;
		private System.Windows.Forms.ColumnHeader PhyAdd;
		[DllImport("iphlpapi.dll", ExactSpelling=true)]
        public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);

        private IContainer components;
    
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButClose = new System.Windows.Forms.Button();
            this.ButDisplay = new System.Windows.Forms.Button();
            this.ListHostIP = new System.Windows.Forms.ListView();
            this.HostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IpAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhyAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = new System.Windows.Forms.StatusBar();
            this.TxtWorkGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButClose
            // 
            this.ButClose.Location = new System.Drawing.Point(345, 222);
            this.ButClose.Name = "ButClose";
            this.ButClose.Size = new System.Drawing.Size(109, 20);
            this.ButClose.TabIndex = 7;
            this.ButClose.Text = "Network Status";
            this.ButClose.Click += new System.EventHandler(this.ButClose_Click);
            // 
            // ButDisplay
            // 
            this.ButDisplay.Location = new System.Drawing.Point(345, 186);
            this.ButDisplay.Name = "ButDisplay";
            this.ButDisplay.Size = new System.Drawing.Size(109, 20);
            this.ButDisplay.TabIndex = 6;
            this.ButDisplay.Text = "Build Network Info";
            this.ButDisplay.Click += new System.EventHandler(this.ButDisplay_Click);
            // 
            // ListHostIP
            // 
            this.ListHostIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HostName,
            this.IpAddr,
            this.PhyAdd});
            this.ListHostIP.Location = new System.Drawing.Point(12, 12);
            this.ListHostIP.Name = "ListHostIP";
            this.ListHostIP.Size = new System.Drawing.Size(325, 272);
            this.ListHostIP.TabIndex = 5;
            this.ListHostIP.UseCompatibleStateImageBehavior = false;
            this.ListHostIP.View = System.Windows.Forms.View.Details;
            // 
            // HostName
            // 
            this.HostName.Text = "Host Name";
            this.HostName.Width = 100;
            // 
            // IpAddr
            // 
            this.IpAddr.Text = "IP Address";
            this.IpAddr.Width = 100;
            // 
            // PhyAdd
            // 
            this.PhyAdd.Text = "Physical Address";
            this.PhyAdd.Width = 120;
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(0, 291);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(464, 22);
            this.Status.TabIndex = 4;
            // 
            // TxtWorkGroup
            // 
            this.TxtWorkGroup.Location = new System.Drawing.Point(346, 119);
            this.TxtWorkGroup.Name = "TxtWorkGroup";
            this.TxtWorkGroup.Size = new System.Drawing.Size(108, 20);
            this.TxtWorkGroup.TabIndex = 8;
            this.TxtWorkGroup.Text = "WORKGROUP";
            this.TxtWorkGroup.TextChanged += new System.EventHandler(this.TxtWorkGroup_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Work Group Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Please make sure all your Computers in LAN are turned on";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Clear N/W Stats";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HostNIPAddr.Properties.Resources.Capture11;
            this.pictureBox1.Location = new System.Drawing.Point(350, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 60);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(464, 313);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtWorkGroup);
            this.Controls.Add(this.ButClose);
            this.Controls.Add(this.ButDisplay);
            this.Controls.Add(this.ListHostIP);
            this.Controls.Add(this.Status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 352);
            this.MinimumSize = new System.Drawing.Size(480, 352);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAN Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private void ButDisplay_Click(object sender, System.EventArgs e)
		{
            try
			{
				this.Status.Text = "Collecting Information...";
				if(this.TxtWorkGroup.Text.Trim() == "")
				{
					MessageBox.Show("The Work Group name Should Not be Empty");
					return;
				}
				// Use Your work Group WinNT://&&&&(Work Group Name)
				DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + this.TxtWorkGroup.Text.Trim());
				DomainEntry.Children.SchemaFilter.Add("computer");
				// To Get all the System names And Display with the Ip Address
				foreach(DirectoryEntry machine in DomainEntry.Children)
				{
					string[] Ipaddr = new string[3];
					Ipaddr[0] = machine.Name;
					System.Net.IPHostEntry Tempaddr = null;
					try
					{
						Tempaddr = (System.Net.IPHostEntry)Dns.GetHostByName(machine.Name);
					}
					catch(Exception ex)
					{
						MessageBox.Show("Unable to connect woth the system :" + machine.Name );
						continue;
					}
					System.Net.IPAddress[] TempAd = Tempaddr.AddressList;
					foreach(IPAddress TempA in TempAd)
					{
						Ipaddr[1] = TempA.ToString();
						byte[] ab = new byte[6];
						int len = ab.Length;
						// This Function Used to Get The Physical Address
						int r = SendARP( (int) TempA.Address, 0, ab, ref len );
						string mac = BitConverter.ToString( ab, 0, 6 );
						Ipaddr[2] = mac;
					}             
					System.Windows.Forms.ListViewItem TempItem = new ListViewItem(Ipaddr);
					this.ListHostIP.Items.Add(TempItem);
                    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + Application.StartupPath + @"\NetInfo.mdf;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("insert into Net values ('" + Ipaddr[0] + "', '"+ Ipaddr[1] + "', '"+ Ipaddr[2] + "')", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
				}
				this.Status.Text = "Displayed";
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Error",System.Windows.Forms.MessageBoxButtons.OK  );
				Application.Exit();
			}
		}
		private void ButClose_Click(object sender, System.EventArgs e)
		{
            Form3 obj = new Form3();
            this.Hide();
            obj.Show();
		}
        private void TxtWorkGroup_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + Application.StartupPath + @"\NetInfo.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("DELETE from Net", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
	}
}
