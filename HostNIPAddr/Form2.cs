using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace HostNIPAddr
{
    public partial class Form2 : Form
    {
        static public string workgroup;
        public static int i;
        public Form2()
        {
           // InitializeComponent();
        }
        public Form2(string wk)
        {
            InitializeComponent();
            ListHostIP.Items.Clear();
            workgroup = wk;
            try
            {
                //this.Status.Text = "Collecting Information...";

                if (workgroup.Trim() == "")
                {
                    MessageBox.Show("The Work Group name Should Not be Empty");
                    return;
                }
                // Use Your work Group WinNT://&&&&(Work Group Name)
                DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + workgroup.Trim());
                DomainEntry.Children.SchemaFilter.Add("computer");
                // To Get all the System names And Display with the Ip Address
                foreach (DirectoryEntry machine in DomainEntry.Children)
                {
                    string[] Ipaddr = new string[3];
                    Ipaddr[0] = machine.Name;
                    System.Net.IPHostEntry Tempaddr = null;
                    try
                    {
                        Tempaddr = (System.Net.IPHostEntry)Dns.GetHostByName(machine.Name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to connect woth the system :" + machine.Name);
                        continue;
                    }
                    System.Net.IPAddress[] TempAd = Tempaddr.AddressList;
                    foreach (IPAddress TempA in TempAd)
                    {
                        Ipaddr[1] = TempA.ToString();
                        byte[] ab = new byte[6];
                        int len = ab.Length;
                        // This Function Used to Get The Physical Address
                        int r = SendARP((int)TempA.Address, 0, ab, ref len);
                        string mac = BitConverter.ToString(ab, 0, 6);
                        Ipaddr[2] = mac;
                    }
                    System.Windows.Forms.ListViewItem TempItem = new ListViewItem(Ipaddr);
                    this.ListHostIP.Items.Add(TempItem);
                }
                // this.Status.Text = "Displayed";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK);
                Application.Exit();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection cn= new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + Application.StartupPath + @"\NetInfo.mdf;Integrated Security=True");
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Net", cn);
            DataSet ds2=new DataSet();
            da2.Fill(ds2);
            ListHostIP.Items.Clear();
            for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
            {
                string []a=new string[3];
                a[0]=ds2.Tables[0].Rows[i]["MacAddrs"].ToString();
                a[1]=ds2.Tables[0].Rows[i]["IpAddrs"].ToString();
                a[2]=ds2.Tables[0].Rows[i]["HostName"].ToString();
                System.Windows.Forms.ListViewItem TempItem = new ListViewItem(a);
                this.ListHostIP.Items.Add(TempItem);
            }
                // TODO: This line of code loads data into the 'netInfoDataSet.Net' table. You can move, or remove it, as needed.
            try
            {
                //this.Status.Text = "Collecting Information...";
                if (workgroup.Trim() == "")
                {
                    MessageBox.Show("The Work Group name Should Not be Empty");
                    return;
                }
                // Use Your work Group WinNT://&&&&(Work Group Name)
                DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + workgroup.Trim());
                DomainEntry.Children.SchemaFilter.Add("computer");
                // To Get all the System names And Display with the Ip Address
                int i = 0;
                foreach (DirectoryEntry machine in DomainEntry.Children)
                {
                    string[] Ipaddr = new string[3];
                    Ipaddr[2] = machine.Name;
                    System.Net.IPHostEntry Tempaddr = null;
                    try
                    {
                        Tempaddr = (System.Net.IPHostEntry)Dns.GetHostByName(machine.Name);
                        System.Net.IPAddress[] TempAd = Tempaddr.AddressList;
                        foreach (IPAddress TempA in TempAd)
                        {
                            Ipaddr[1] = TempA.ToString();
                            byte[] ab = new byte[6];
                            int len = ab.Length;
                            // This Function Used to Get The Physical Address
                            int r = SendARP((int)TempA.Address, 0, ab, ref len);
                            string mac = BitConverter.ToString(ab, 0, 6);
                            Ipaddr[0] = mac;
                        }
                        if (ListHostIP.Items[i].Text == (Ipaddr[0]).ToString())
                        {
                            ListHostIP.Items[i].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            ListHostIP.Items[i].BackColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        ListHostIP.Items[i].BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK);
                Application.Exit();
            }
        }
        private void ListHost_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show((++i).ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }
        private void Colse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListHostIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
