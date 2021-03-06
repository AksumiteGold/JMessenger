namespace Jabber
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string firstname, string lastname, string email, string username, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Username = username;
            Password = password;
        }

    }
}