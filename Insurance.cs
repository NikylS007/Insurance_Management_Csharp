using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Insurance
    {
        // Creates the "Customer" table in the SQL Server database.
        public void Create_Table_Customer()
        {
            // Connection string to connect to the SQL Server database.
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

            try
            {
                // Using statement to open a connection to the database.
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // String containing the SQL query to create the "Customer" table.
                    string conString = "CREATE TABLE Customer(\r\n     CustomerID varchar(50) PRIMARY KEY,\r\n     CustomerName varchar(50) NOT NULL,\r\n     email varchar(50) UNIQUE NOT NULL,\r\n     password varchar(30) NOT NULL,\r\n     Address varchar(100) UNIQUE NOT NULL,\r\n     Contact varchar(50) UNIQUE NOT NULL,\r\n     Nominee varchar(50) NOT NULL,\r\n     Relationship varchar(50) NOT NULL\r\n);";
                    // Using statement to create a new SQL Command with the SQL query and the connection.
                    using (SqlCommand cmd = new SqlCommand(conString, connection))
                    {
                        // Executing the SQL query
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Customer Table Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Creating Policy Table
        public void Create_Table_Policy()
        {
            // Connection string to connect to the SQL Server database
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

            try
            {
                // Creating a SqlConnection object using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Opening the connection to the database
                    connection.Open();

                    // SQL query to create the Policy table
                    string conString = "CREATE TABLE Policy(\r\n     CustomerID varchar(50) ,\r\n     policy_Id varchar(50) ,\r\n     policy_type varchar(50) ,\r\n     start_dates varchar(50)  ,\r\n     sum_assured varchar(50) ,\r\n     premium varchar(50) ,\r\n     paying_term varchar(50) ,\r\n     title varchar(50) ,\r\n     nextdue varchar(50) ,\r\n     FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)\r\n);";

                    // Creating a SqlCommand object using the SQL query and the SqlConnection object
                    using (SqlCommand cmd = new SqlCommand(conString, connection))
                    {
                        // Executing the SQL query
                        cmd.ExecuteNonQuery();
                    }
                }

                // Writing a success message if the Policy table was created successfully
                Console.WriteLine("Policy Table Created Successfully");
            }
            catch (Exception e)
            {
                // Writing the error message if an exception occurred
                Console.WriteLine(e.Message);
            }
        }

        // Adding Customer details to Customer table
        public int AddCustomer(string c_id, string c_na, string e_Ma, string p_a, string c_ad, string n_um, string n_o, string r_e)
        {
            int rows = 0;
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string conString = "INSERT INTO Customer VALUES (@c_id, @c_na, @e_Ma, @p_a, @c_ad, @n_um, @n_o, @r_e)";
                    using (SqlCommand cmd = new SqlCommand(conString, connection))
                    {
                        cmd.Parameters.AddWithValue("@c_id", c_id);
                        cmd.Parameters.AddWithValue("@c_na", c_na);
                        cmd.Parameters.AddWithValue("@e_Ma", e_Ma);
                        cmd.Parameters.AddWithValue("@p_a", p_a);
                        cmd.Parameters.AddWithValue("@c_ad", c_ad);
                        cmd.Parameters.AddWithValue("@n_um", n_um);
                        cmd.Parameters.AddWithValue("@n_o", n_o);
                        cmd.Parameters.AddWithValue("@r_e", r_e);

                        rows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
            }
            return rows;
        }


        // Adding Policy details to Policy table
        public int AddPolicy(string c_id, string p_nu, string p_ty, string d, string s_um, string p_um, string p_t, string t, string nt)
        {
            int rows = 0;
            try
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
                string conString = string.Format("INSERT INTO Policy VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", c_id, p_nu, p_ty, d, s_um, p_um, p_t, t, nt);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(conString, connection);
                    connection.Open();
                    rows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return rows;
        }

        // Reading all customer & policy details 
        public List<Customer> fetchCustomer()
        {
            List<Customer> list = new List<Customer>();
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Customer.CustomerID, Customer.CustomerName, Policy.Policy_type, Policy.title, Policy.Premium, Policy.Sum_assured, \r\nCustomer.Nominee, Customer.email, Customer.Contact, nextdue FROM Policy FULL OUTER JOIN Customer ON Customer.CustomerID = Policy.CustomerID;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Customer c = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToInt32(reader[0]), reader[9].ToString());
                            list.Add(c);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        // Reading specific customer & policy details 
        public List<Customer> fetchCustomer(string cust_id)
        {
            List<Customer> list = new List<Customer>();
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Customer.CustomerID, Customer.CustomerName, Policy.Policy_type, Policy.title, Policy.Premium, Policy.Sum_assured, \r\nCustomer.Nominee, Customer.email, Customer.Contact, nextdue FROM Policy FULL OUTER JOIN Customer ON Customer.CustomerID = Policy.CustomerID WHERE Customer.CustomerID = '" + cust_id + "';";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Customer c = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToInt32(reader[0]), reader[9].ToString());
                            list.Add(c);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        // Reading Specific customer id
        public string fetchCustomerid(string id)
        {
            string i_d = null;
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CustomerID FROM Customer where CustomerID = '" + id + "'";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            i_d = Convert.ToString(reader[0].ToString());
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return i_d;
        }


    }
}