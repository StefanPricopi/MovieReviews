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
    }
}
