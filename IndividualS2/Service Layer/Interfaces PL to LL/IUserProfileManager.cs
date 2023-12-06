using ModelLibrary.BaseClasses;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface IUserProfileManager
    {
        public UserProfileDTO GetActualProfileByID(int id);
    }
}
