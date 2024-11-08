﻿using System;
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

        public DAL_Jobs()
        {
            socketManager = new SocketManager();
        }

        public BindingList<Jobs> Select()
        {
            socketManager.OpenConnection();

            BindingList<Jobs> jobList = new BindingList<Jobs>();
            string query = "SELECT job_id, job_title, min_salary, max_salary " +
                            "FROM jobs";

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

        public void Update(Jobs job)
        {
            string query = @"
                UPDATE Employees
                SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, HireDate = @HireDate,
                    Salary = @Salary, JobId = @JobId, ManagerId = @ManagerId, DepartmentId = @DepartmentId
                WHERE EmployeeId = @EmployeeId";

            socketManager.OpenConnection();

            try
            {
                using (SqlCommand command = new SqlCommand(query, socketManager.Connection))
                {

                    command.Parameters.AddWithValue("@JobId", job.JobId);
                    command.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    command.Parameters.AddWithValue("@MinSalary", job.MinSalary.HasValue ? job.MinSalary.Value : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MaxSalary", job.MaxSalary.HasValue ? job.MaxSalary.Value : (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error updating job: " + ex);
            }

            socketManager.CloseConnection();
        }

        public int Insert(Jobs job)
        {
            int id = -1;

            socketManager.OpenConnection();

            try
            {
                string query =
                    $@"INSERT INTO jobs(job_title, min_salary, max_salary)
                    VALUES ('@JobTitle', @MinSalary, @MaxSalary)
                    SELECT Scope_identity()";

                using (SqlCommand cmd = new SqlCommand(query, socketManager.Connection))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    cmd.Parameters.AddWithValue("@MinSalary", (object)job.MinSalary.ToString() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaxSalary", (object)job.MaxSalary.ToString() ?? DBNull.Value);
                    id = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error inserting:" + ex);
            }

            socketManager.CloseConnection();

            return id;
        }

        public Jobs GetById(int id)
        {
            foreach (Jobs j in Select())
            {
                if (j.JobId == id) return j;
            }

            return null;
        }
    }
}
