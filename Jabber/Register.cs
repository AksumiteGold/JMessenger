using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Jabber
{
    public class Register
    {
        public Register(User user)
        {
            //ControlEmail(user); 
            //ControlUsername(user);
            RegisterUser(user);        
        }
            

        public bool ControlUsername(User userU)
        {
            string connString = "Server = 160.153.16.62; Port = 3306; Database = JabberDBA; Uid = JabberUser; Password = root123;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from users where user_name like @username AND password like @password", conn))
                {
                    conn.Open();
                    sqlCommand.Parameters.AddWithValue("@username", userU.Username);
                    sqlCommand.Parameters.AddWithValue("@password", userU.Password);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                }
            }

            return true;
        }

        public bool ControlEmail(User userE)
        {
            string connString = "Server = 160.153.16.62; Port = 3306; Database = JabberDBA; Uid = JabberUser; Password = root123;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from users where user_name like @username AND password like @password", conn))
                {
                    conn.Open();
                    sqlCommand.Parameters.AddWithValue("@username", userE.Username);
                    sqlCommand.Parameters.AddWithValue("@password", userE.Password);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                }
            }

            return true;
        }

        public void RegisterUser(User userR)
        {
            string connString = "Server = 160.153.16.62; Port = 3306; Database = JabberDBA; Uid = JabberUser; Password = root123;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO Users(Firstname, Lastname, Email, Username, Password) VALUES(@Firstname, @Lastname, @Email, @Username, @Password)", conn))
                {
                    conn.Open();
                    sqlCommand.Parameters.AddWithValue("@Firstname", userR.Firstname);
                    sqlCommand.Parameters.AddWithValue("@Lastname", userR.Lastname);
                    sqlCommand.Parameters.AddWithValue("@Email", userR.Email);
                    sqlCommand.Parameters.AddWithValue("@Username", userR.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", userR.Password);
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}