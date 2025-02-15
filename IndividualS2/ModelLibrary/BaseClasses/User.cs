﻿using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string Username {  get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Salt {  get; set; }
        public int RoleID { get; set; }
        public string Status {  get; set; }
        public User()
        {

        }
        public User(int userID,string username, string passwordHash, string salt, int  roleID,string status)
        {
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
            RoleID = roleID;
            Status = status;
        }
        public User(UserDTO userDTO)
        {
            this.UserID = userDTO.UserId;
            this.Username = userDTO.Username;
            this.PasswordHash = userDTO.PasswordHash;           
            this.Salt = userDTO.Salt;
            this.RoleID = userDTO.RoleID;
            this.Status = userDTO.Status;
        }
    }
}
