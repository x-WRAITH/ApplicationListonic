using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationListonic.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (this.Username == "admin" && this.Password == "admin") { return true; }
            else { return false; }
        }
    }
}
