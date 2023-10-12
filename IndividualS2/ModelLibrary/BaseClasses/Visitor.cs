using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    public class Visitor
    {
        public string Username {  get; set; }
        public string Password { get; set; }
        public string Email {  get; set; }
        public Visitor(string username, string password,string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
