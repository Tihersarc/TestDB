using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.ScriptsTables
{
    internal class DAL_Employees
    {
        SocketManager socketManager;


        DAL_Employees() {
            socketManager = new SocketManager();

        }

        public BindingList<Employees> Select()
        {
            socketManager.OpenConnection();

            BindingList<Employees> jobList = new BindingList<Employees>();
            string query = @"
                SELECT EmployeeId, FirstName, LastName, Email, PhoneNumber, HireDate, Salary, JobId, ManagerId, DepartmentId
                FROM Employees;";

            try
            {
                using (SqlCommand command = new SqlCommand(query, socketManager.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employees employee = new Employees
                            {
                                EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                Salary = reader.GetDouble(reader.GetOrdinal("Salary")),
                                JobId = reader.GetInt32(reader.GetOrdinal("JobId")),
                                ManagerId = reader.IsDBNull(reader.GetOrdinal("ManagerId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ManagerId")),
                                DepartmentId = reader.IsDBNull(reader.GetOrdinal("DepartmentId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DepartmentId"))
                            };
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

        public void Update(Employees employee)
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

                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@JobId", employee.JobId);
                    command.Parameters.AddWithValue("@ManagerId", employee.ManagerId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error updating job: " + ex);
            }

            socketManager.CloseConnection();
        }

        public int Insert(Employees employee)
        {
            int id = -1;

            socketManager.OpenConnection();

            try
            {
                string query = @"
                    INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary, JobId, ManagerId, DepartmentId)
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @HireDate, @Salary, @JobId, @ManagerId, @DepartmentId)";

                using (SqlCommand command = new SqlCommand(query, socketManager.Connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@JobId", employee.JobId);
                    command.Parameters.AddWithValue("@ManagerId", employee.ManagerId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId ?? (object)DBNull.Value);

                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error inserting:" + ex);
            }

            socketManager.CloseConnection();

            return id;
        }

        public Employees GetById(int id)
        {
            foreach (Employees e in Select())
            {
                if (e.JobId == id) return e;
            }

            return null;
        }
    }
}
