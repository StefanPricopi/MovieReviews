using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class UserProfileManager: IUserProfileManager
    {

        private readonly IUserProfileDAL userProfile;
        public UserProfileManager(IUserProfileDAL userProfile)
        {
            this.userProfile = userProfile ?? throw new ArgumentNullException(nameof(userProfile));
        }
        public UserProfileDTO GetActualProfileByID(int id)
        {
            return userProfile.GetActualProfileByID(id);
        }
    }
}
