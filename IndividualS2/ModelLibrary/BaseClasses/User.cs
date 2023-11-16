using ModelLibrary.DTO;
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
        public int UserID { get; set; }
        public string Username {  get; set; }
        public string PasswordHash { get; set; }
        public string Salt {  get; set; }
        public int RoleID { get; set; }
        public User()
        {

        }
        public User(int userID,string username, string passwordHash, string salt, int  roleID)
        {
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
            RoleID = roleID;
        }
        public User(UserDTO userDTO)
        {
            this.UserID = userDTO.UserId;
            this.Username = userDTO.Username;
            this.PasswordHash = userDTO.PasswordHash;           
            this.Salt = userDTO.Salt;
            this.RoleID = userDTO.RoleID;
        }
    }
}
