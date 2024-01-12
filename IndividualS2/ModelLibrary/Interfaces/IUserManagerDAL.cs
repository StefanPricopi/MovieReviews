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
    public interface IUserManagerDAL
    {
        public bool AddUserAccount(UserDTO v);
        public bool UpdateUserAccount(UserDTO v);
        
        public List<UserDTO> GetAllAccounts();
        public User GetCurrentUserByUsername(string username);
        public void UpdateUserStatus(int userId);


    }
}
