using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public int VisitorID { get; set; }
        public int EmployeeID { get; set; }
        public UserDTO()
        {
            
        }
    }
}
