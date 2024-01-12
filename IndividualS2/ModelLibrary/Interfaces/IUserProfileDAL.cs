using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface IUserProfileDAL
    {
        public UserProfileDTO GetActualProfileByID(int id);
        public List<string> GetUserNewsletterPreferences(int userId);
        public void UpdateUserNewsletterPreferences(int userId, bool prefers60s, bool prefersDaily, bool prefersWeekly);
    }
}
