using System;

namespace ReportServiceWPF.Model
{
    public class Users
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Users(int id, string username, string name, string password, DateTime birthdate, int age, string email)
        {
            ID = id;
            Username = username;
            Name = name;
            Password = password;
            Birthdate = birthdate;
            Age = age;
            Email = email;
        }
    }
}
