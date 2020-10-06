using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using DrossDrop.DTOs;
using Renci.SshNet;

namespace DrossDrop.Data
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "drossdrop";
            uid = "root";
            password = "";
            string connectionString = "Server=" + server + ";" + "Database=" +
                                      database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //Insert
        public async Task ExecuteNonResponsiveQuery(string querystring)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                await connection.OpenAsync();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                await cmd.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                await connection.CloseAsync();
            }
        }

        public async Task<IEnumerable<UserDTO>> ExecuteSelectQuery(string querystring)
        {
            List<UserDTO> users = new List<UserDTO>();

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                await connection.OpenAsync();
                
                MySqlCommand cmd = new MySqlCommand(querystring, connection);
                DbDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    UserDTO user = new UserDTO();

                    user.userId = Convert.ToInt32(reader["userId"]);
                    user.roleId = Convert.ToInt32(reader["roleId"]);
                    user.email = reader["email"].ToString();
                    user.password = reader["password"].ToString();
                    user.firstName = reader["firstName"].ToString();
                    user.lastName = reader["lastName"].ToString();

                    users.Add(user);
                }

                await connection.CloseAsync();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                await connection.CloseAsync();
            }

            return users;
        }

        //Close connection
        private async Task CloseConnection()
        {
            try
            {
                await connection.CloseAsync();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
