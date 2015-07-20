using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Amazon.EC2.Model;
using AwsLibs;

namespace AwsTools
{
    public partial class frmMain : Form
    {
        readonly AwsFacade _facade = new AwsFacade();
        private List<Instance> _instances;
        public frmMain()
        {
            InitializeComponent();
            _instances = _facade.GetInstances();
            lblRegion.Text = string.Format(lblRegion.Tag.ToString(), ConfigurationManager.AppSettings["AWSRegion"]);
            lblAccount.Text = string.Format(lblAccount.Tag.ToString(), ConfigurationManager.AppSettings["AWSProfileName"]);
            txtZonomiApiKey.Text = ToolkitSettings.Default.ZonomiApiKey;
            txtDomain.Text = ToolkitSettings.Default.DomainName;
            lblMyPublicIp.Text = string.Format(lblMyPublicIp.Tag.ToString(), GetPublicIP());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboInstances.DataSource = _instances.SelectMany(x => x.Tags).Select(x => x.Value).ToList();
            BindInstance();
        }

        private void cboInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInstance();
        }

        private Instance GetSelectedInstance()
        {
            return _instances.Single(x => x.Tags[0].Value == cboInstances.SelectedItem);
        }

        private void BindInstance()
        {
            var instance = GetSelectedInstance();

            lblState.Text = string.Format(lblState.Tag.ToString(), instance.State.Name);
            lblDns.Text = string.Format(lblDns.Tag.ToString(), instance.PublicDnsName);
            lblIpAddress.Text = string.Format(lblIpAddress.Tag.ToString(), instance.PublicIpAddress);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _facade.StartInstance(GetSelectedInstance());
            MessageBox.Show("Start command issued!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _facade.StopInstance(GetSelectedInstance());
            MessageBox.Show("Stop command issued!");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindInstance();
            
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            var instance = GetSelectedInstance();
            var domain = string.Format("{0}.{1}", cboInstances.SelectedItem.ToString().Replace(" ", string.Empty), ToolkitSettings.Default.DomainName);
            var urlToUpdate = string.Format("https://zonomi.com/app/dns/dyndns.jsp?api_key={0}&host={1}&value={2}",
                ToolkitSettings.Default.ZonomiApiKey, domain, instance.PublicIpAddress);

            var request = (HttpWebRequest)WebRequest.Create(urlToUpdate);
            var response=(HttpWebResponse)request.GetResponse();
            response.Close();

            if(response.StatusCode!=HttpStatusCode.OK)
                throw new Exception("Dns Update failed");

            MessageBox.Show(string.Format("DNS Updated for : {0}", domain));
        }

        private void Setting_Changed(object sender, EventArgs e)
        {
            ToolkitSettings.Default.ZonomiApiKey = txtZonomiApiKey.Text;
            ToolkitSettings.Default.DomainName = txtDomain.Text;
            ToolkitSettings.Default.Save();
        }

        public static string GetPublicIP()
        {
            var url = "http://checkip.dyndns.org";
            var req = WebRequest.Create(url);
            var resp = req.GetResponse();
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
            var response = sr.ReadToEnd().Trim();
            var a = response.Split(':');
            var a2 = a[1].Substring(1);
            var a3 = a2.Split('<');
            var a4 = a3[0];
            return a4;
        }

    }
}
