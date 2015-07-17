using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Amazon.EC2.Model;
using AwsLibs;

namespace AwsTools
{
    public partial class Form1 : Form
    {
        readonly AwsFacade _facade = new AwsFacade();
        private List<Instance> _instances;
        public Form1()
        {
            InitializeComponent();
            _instances = _facade.GetInstances();
            lblRegion.Text = string.Format(lblRegion.Tag.ToString(), ConfigurationManager.AppSettings["AWSRegion"]);
            lblAccount.Text = string.Format(lblAccount.Tag.ToString(), ConfigurationManager.AppSettings["AWSProfileName"]);
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
    }
}
