using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SocketManager.CreateConnection();
            LoadJobs();
        }

        private void LoadJobs()
        {
            dgvJobs.DataSource = SocketManager.GetJobs();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SocketManager.OpenConnection();
            lblStatus.Text = "Open";
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            SocketManager.CloseConnection();
            lblStatus.Text = "Closed";
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void btnInsertJob_Click(object sender, EventArgs e)
        {
            string jobTitle = txtJobTitle.Text;
            decimal minSalary = numMinimumSalary.Value;
            decimal maxSalary = numMaximumSalary.Value;

            Jobs j = new Jobs(jobTitle, minSalary, maxSalary);

            SocketManager.InsertJob(j);
        }

        private void numMinimumSalary_ValueChanged(object sender, EventArgs e)
        {
            numMaximumSalary.Minimum = numMinimumSalary.Value;
        }

        private void numMaximumSalary_ValueChanged(object sender, EventArgs e)
        {
            numMinimumSalary.Maximum = numMaximumSalary.Value;
        }

        private void txtJobTitle_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtJobTitle.Text))
                btnInsertJob.Enabled = true;
            else 
                btnInsertJob.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvJobs.Rows)
            {
                int id = (int)row.Cells["JobId"].Value;

                string jobTitle = (string)row.Cells["JobTitle"].Value;
                decimal? minSalary = row.Cells["MinSalary"].Value as decimal?;
                decimal? maxSalary = row.Cells["MaxSalary"].Value as decimal?;

                Jobs jobs = new Jobs(jobTitle, minSalary ?? 0, maxSalary ?? 0);
                SocketManager.UpdateJob(jobs);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }
    }
}
