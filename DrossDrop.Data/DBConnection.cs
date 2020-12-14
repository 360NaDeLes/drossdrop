using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using DrossDrop.DTOs;
using DrossDrop.DataInterface;
using Renci.SshNet;

namespace DrossDrop.Data
{
    public class DBConnection
    {
        private MySqlConnection connection;

        //Constructor
        public DBConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            AppConfiguration config = new AppConfiguration();

            connection = new MySqlConnection(config.sqlConnectionString);
        }

        //Insert
        public void ExecuteNonResponsiveQuery(string querystring)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                connection.Open();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                connection.Close();
            }
        }

        // Select query (users only)
        public IEnumerable<User> ExecuteSelectUserQuery(string querystring)
        {
            List<User> users = new List<User>();

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                connection.Open();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.userId = Convert.ToInt32(reader["userId"]);
                    user.roleId = Convert.ToInt32(reader["roleId"]);
                    user.email = reader["email"].ToString();
                    user.password = reader["password"].ToString();
                    user.firstName = reader["firstName"].ToString();
                    user.lastName = reader["lastName"].ToString();
                    user.salt = reader["salt"].ToString();

                    users.Add(user);
                }

                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                connection.Close();
            }

            return users;
        }

        // Select query (products only)
        public IEnumerable<Product> ExecuteSelectProductQuery(string querystring)
        {
            List<Product> products = new List<Product>();

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                connection.Open();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    
                    product.productId = Convert.ToInt32(reader["productId"]);
                    product.productName = reader["productName"].ToString();
                    product.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    product.productImage = reader["productImage"].ToString();

                    products.Add(product);
                }

                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                connection.Close();
            }

            return products;
        }

        // Select query (roles only)
        public IEnumerable<Role> ExecuteSelectRoleQuery(string querystring)
        {
            List<Role> roles = new List<Role>();

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                connection.Open();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Role role = new Role();

                    role.id = Convert.ToInt32(reader["roleId"]);
                    role.name = reader["roleName"].ToString();

                    roles.Add(role);
                }

                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                connection.Close();
            }

            return roles;
        }
        
        // Select query (carts only)
        public IEnumerable<Cart> ExecuteSelectCartQuery(string querystring)
        {
            List<Cart> carts = new List<Cart>();

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                connection.Open();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cart cart = new Cart();

                    cart.cartId = Convert.ToInt32(reader["cartId"]);
                    cart.userId = Convert.ToInt32(reader["userId"]);
                    cart.productId = Convert.ToInt32(reader["productId"]);

                    carts.Add(cart);
                }

                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                connection.Close();
            }

            return carts;
        }

        //Close connection
        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
