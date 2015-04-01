using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DiscoBase
{
    class DiscoDAO
    {
        public DiscoDAO()
        {
            createConnection();
        }

        // Muss ich denn bei jeder Anfrage mit try-catch prüfen, ob die connection steht ?
        // Duplizierter Code!!!
        //
        public List<Customer> GetCustomerList()
        {
            string stmt = "SELECT * FROM Customer";
            List<Customer> cl = new List<Customer>();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(stmt, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Customer c = new Customer();
                    c.Name = reader[1].ToString();
                    c.Vorname = reader[2].ToString();

                    cl.Add(c);
                }

                return cl;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        private void createConnection()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["disco"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);
            //connection = factory.CreateConnection();
            connection = new SqlConnection(settings.ConnectionString);
           // connection.ConnectionString = settings.ConnectionString;
        }

        private SqlConnection connection;
    }
}
