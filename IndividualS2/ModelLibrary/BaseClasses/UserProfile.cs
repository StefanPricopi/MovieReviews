using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.BaseClasses
{
    public class UserProfile
    {
       public int userID { get; set; }
       public string email { get; set; }
       public string firstName {  get; set; }
       public string lastName { get; set; }

        public UserProfile() { }
        public UserProfile(int userID, string email, string firstName, string lastName)
        {
            this.userID = userID;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
