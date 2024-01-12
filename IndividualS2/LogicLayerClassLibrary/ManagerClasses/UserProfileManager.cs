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
        public List<string> GetUserNewsletterPreferences(int userId)
        {
            return userProfile.GetUserNewsletterPreferences(userId);
        }
        public void UpdateUserNewsletterPreferences(int userId, bool prefers60s, bool prefersDaily, bool prefersWeekly)
        {
            this.userProfile.UpdateUserNewsletterPreferences(userId, prefers60s, prefersDaily, prefersWeekly);
        }
    }
}
