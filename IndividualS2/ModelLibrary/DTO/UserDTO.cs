using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public UserDTO()
        {
            
        }
    }
}
