using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    internal class SocketManager
    {
        public bool IsConnected {
            get {
                return Connection != null && 
                       Connection.State == System.Data.ConnectionState.Open; 
            } 
        }

        public SqlConnection Connection { get; private set; }
        private string ConnectionString
        {
            get {
            return "Data Source=85.208.21.117,54321;" +
            "Initial Catalog=PolRodriguezEmployees;" +
            "User ID=sa;" +
            "Password=Sql#123456789;" +
            "TrustServerCertificate=True;";
            }
        }
        
        public SocketManager()
        {
            CreateConnection();
        }

        public void CreateConnection()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Creating Connection:\n" + ex);
            }
        }

        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Opening Connection:\n" + ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Closing Connection:\n" + ex);
            }
        }
    }
}
