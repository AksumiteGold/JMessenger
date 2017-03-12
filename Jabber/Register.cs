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
            string connString = "Server = 160.153.16.62; Port = 3306; Database = JabberDBA; Uid = JabberUser; Password = root123;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO Users(Firstname, Lastname, Email, Username, Password) VALUES(@Firstname, @Lastname, @Email, @Username, @Password)";

            comm.Parameters.AddWithValue("@Firstname", user.Firstname);
            comm.Parameters.AddWithValue("@Lastname", user.Lastname);
            comm.Parameters.AddWithValue("@Email", user.Email);
            comm.Parameters.AddWithValue("@Username", user.Username);
            comm.Parameters.AddWithValue("@Password", user.Password);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}