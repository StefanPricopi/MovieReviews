using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    public class User
    {
        public string Username {  get; set; }
        public BinaryData PasswordHash { get; set; }
        public BinaryData Salt {  get; set; }
        public int RoleID { get; set; }
        public User(string username, BinaryData passwordHash, BinaryData salt, int roleID)
        {
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
            RoleID = roleID;
        }
    }
}
