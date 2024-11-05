using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    internal static class SocketManager
    {
        static public bool IsConnected {
            get {
                return connection != null && connection.State == System.Data.ConnectionState.Open; 
            } 
        }

        static private SqlConnection connection;
        static private readonly string connectionString =
            "Data Source=85.208.21.117,54321;" +
            "Initial Catalog=PolRodriguezEmployees;" +
            "User ID=sa;" +
            "Password=Sql#123456789;" +
            "TrustServerCertificate=True;";

        public static void CreateConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error Creating Connection:\n" + ex);
            }
        }

        public static void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Opening Connection:\n" + ex);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Closing Connection:\n" + ex);
            }
        }

        public static List<Jobs> GetJobs()
        {
            OpenConnection();

            List<Jobs> jobList = new List<Jobs>();
            string query = "SELECT job_id, job_title, min_salary, max_salary FROM jobs";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
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
            catch (Exception)
            {

                throw;
            }

            return jobList;
        }

        public static void InsertJob(Jobs job)
        {
            SocketManager.OpenConnection();

            try
            {
                //string minSal = job.MinSalary.ToString() ?? ;

                string query = 
                    $@"INSERT INTO jobs(job_title, min_salary, max_salary)
                    VALUES ('{job.JobTitle}', {job.MinSalary.ToString() ?? "NULL"},
                             {job.MaxSalary.ToString() ?? "NULL"})";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error inserting:" + ex);
            }

            SocketManager.CloseConnection();
        }
    }
}
