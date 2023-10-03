using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    internal class Visitor
    {
        private string Username {  get; set; }
        private string Password { get; set; }
        private string Email {  get; set; }
        public Visitor(string username, string password,string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
