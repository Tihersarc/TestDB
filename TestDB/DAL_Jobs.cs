using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    internal class DAL_Jobs
    {
        private SocketManager socketManager;

        public DAL_Jobs()
        {
            socketManager = new SocketManager();
        }

        public BindingList<Jobs> GetJobs()
        {
            socketManager.OpenConnection();

            BindingList<Jobs> jobList = new BindingList<Jobs>();
            string query = "SELECT job_id, job_title, min_salary, max_salary FROM jobs" 
                //+ "SELECT Scope_identity()"
                ;
            //SELECT Sciope_Identity; && ExecuteScalar();
            try
            {
                using (SqlCommand command = new SqlCommand(query, socketManager.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Jobs job = new Jobs
                            {
                                JobId = reader.GetInt32(0),
                                JobTitle = reader.GetString(1),
                                MinSalary = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                MaxSalary = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                            };

                            jobList.Add(job);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error Selecting:\n" + ex);
            }

            socketManager.CloseConnection();
            return jobList;
        }

        public void UpdateJob(Jobs job)
        {
            string query = "UPDATE jobs " +
                "SET job_title = @JobTitle, min_salary = @MinSalary, max_salary = @MaxSalary " +
                "WHERE job_id = @JobId";

            socketManager.OpenConnection();

            try
            {
                using (SqlCommand command = new SqlCommand(query, socketManager.Connection))
                {

                    command.Parameters.AddWithValue("@JobId", job.JobId);
                    command.Parameters.AddWithValue("@JobTitle", job.JobTitle);

                    command.Parameters.AddWithValue("@MinSalary", job.MinSalary.HasValue ?
                                                    job.MinSalary.Value : (object)DBNull.Value);

                    command.Parameters.AddWithValue("@MaxSalary", job.MaxSalary.HasValue ?
                                                    job.MaxSalary.Value : (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error updating job: " + ex);
            }

            socketManager.CloseConnection();
        }

        public void InsertJob(Jobs job)
        {
            socketManager.OpenConnection();

            try
            {
                string query =
                    $@"INSERT INTO jobs(job_title, min_salary, max_salary)
                    VALUES ('@JobTitle', @MinSalary, @MaxSalary)";

                using (SqlCommand cmd = new SqlCommand(query, socketManager.Connection))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    cmd.Parameters.AddWithValue("@MinSalary", (object)job.MinSalary.ToString() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaxSalary", (object)job.MaxSalary.ToString() ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error inserting:" + ex);
            }

            socketManager.CloseConnection();
        }
    }
}
