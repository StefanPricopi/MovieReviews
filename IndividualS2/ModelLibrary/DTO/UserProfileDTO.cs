using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class UserProfileDTO
    {
        public int userID { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public UserProfileDTO() { }
    }
}
