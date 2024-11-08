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
        private DAL_Jobs DalJobs;

        public Form1()
        {
            InitializeComponent();

            DalJobs = new DAL_Jobs();

            LoadJobs();

            //-------LINQ TO SQL----------
            EmployeesDataClasses dc = new EmployeesDataClasses();
            var data = from emp in dc.employees
                       where emp.first_name == "Steve"
                       select emp;

            //DataSource = data
            dc.SubmitChanges();
        }

        private void LoadJobs()
        {
            dgvJobs.DataSource = DalJobs.Select();
        }

        private void btnInsertJob_Click(object sender, EventArgs e)
        {
            string jobTitle = txtJobTitle.Text;
            decimal minSalary = numMinimumSalary.Value;
            decimal maxSalary = numMaximumSalary.Value;

            Jobs j = new Jobs(jobTitle, minSalary, maxSalary);

            DalJobs.Insert(j);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void dgvJobs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Jobs job = (Jobs)dgvJobs.Rows[e.RowIndex].DataBoundItem;
            DalJobs.Update(job);
            LoadJobs();
        }
    }
}
