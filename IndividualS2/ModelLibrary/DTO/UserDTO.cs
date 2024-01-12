using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public int VisitorID { get; set; }
        public int EmployeeID { get; set; }
        public string Status { get; set; }
        public UserDTO()
        {
            
        }
    }
}
