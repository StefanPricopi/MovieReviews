using LogicLayerClassLibrary.Classes;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface IUserManager
    {
        public bool AddCreateAccount(UserDTO userDTO);

        public User GetCurrentUserByUsername(string username);
        public List<UserDTO> GetAllAccounts();

        public User Login(string username, string password);
        public bool IsLoginValid(string username, string password);

        public bool IsLoginValidVisitorCase(string username, string password);

    }
}
