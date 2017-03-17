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
        private static string connString = "Server = 160.153.16.62; Port = 3306; Database = JabberDBA; Uid = JabberUser; Password = root123;";
        public MySqlConnection conn = new MySqlConnection(connString);

        public Register()
        {
            conn.Open();
        }

        public bool ControlEmail(User userE)
        {
            bool exists = false;
            using (conn)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from Users where Emal like @email", conn))
                {
                    sqlCommand.Parameters.AddWithValue("@email", userE.Email);
                    int usernameCount = (int)sqlCommand.ExecuteScalar();
                    if (usernameCount >= 1)
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }

        public bool ControlUsername(User userU)
        {
            bool exists = false;
            using (conn)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from Users where Username like @username", conn))
                {
                    conn.Open();
                    sqlCommand.Parameters.AddWithValue("@username", userU.Username);
                    int usernameCount = (int)sqlCommand.ExecuteScalar();
                    if(usernameCount >= 1)
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }

        public bool ControlPasswordMatch(User userP)
        {
            bool match = false;

            if(userP.Password == userP.ConfirmPassword)
            {
                match = true;
            }
            else
            {
                match = false;
            }
            return match;
        }

        public void RegisterUser(User userR)
        {
            using (conn)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO Users(Firstname, Lastname, Email, Username, Password) VALUES(@Firstname, @Lastname, @Email, @Username, @Password)", conn))
                {
                    //conn.Open();
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