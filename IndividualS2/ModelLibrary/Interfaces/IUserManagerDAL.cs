using LogicLayerClassLibrary.Classes;
using Microsoft.Identity.Client;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    public interface IUSERManagerDAL
    {
        public bool AddUserAccount(UserDTO v);
        public bool UpdateUserAccount(UserDTO v);
        
        public User GetCurrentUserByUsername(string username);
        public UserDTO GetCurrentUserForVisitor(string username);
    }
}
