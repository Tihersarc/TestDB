using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestDB.ScriptsTables;

namespace TestDB
{
    internal class DAL_Jobs
    {
        private SocketManager socketManager;
        private EmployeesDataClasses db;

        public DAL_Jobs()
        {
            socketManager = new SocketManager();
            db = new EmployeesDataClasses();
        }

        public BindingList<Jobs> Select()
        {
            var data = db.jobs.ToList();
                
            return new BindingList<Jobs>((IList<Jobs>)data); //Problems
        }

        public void Update(Jobs job)
        {
            var data = db.jobs.FirstOrDefault(j => j.job_id == job.JobId);

            if (data != null)
            {
                data.job_title = job.JobTitle;
                data.min_salary = job.MinSalary;
                data.max_salary = job.MaxSalary;
                
                db.SubmitChanges();
            }
        }

        public int Insert(Jobs job)
        {
            jobs newJob = new jobs
            {
                job_title = job.JobTitle,
                min_salary = job.MinSalary,
                max_salary = job.MaxSalary
            };

            db.jobs.InsertOnSubmit(newJob);

            db.SubmitChanges();

            return newJob.job_id;
        }

        public Jobs GetById(int id)
        {
            return (Jobs)db.jobs.Where(j => j.job_id == id);
        }
    }
}
