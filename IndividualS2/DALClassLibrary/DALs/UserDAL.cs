using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;

namespace DALClassLibrary.DALs
{
    public class UserDAL:Connection, IUserManagerDAL
    {
        public User Login(string username, string password)
        {
            User currentUser = GetCurrentUserByUsername(username);//all the method via IUser
            var userhashedpass = UserManager.HashedPassword($"{password}{currentUser.Salt.Trim()}");

            if (username == currentUser.Username && userhashedpass == currentUser.PasswordHash)
            {
                return currentUser;

            }

            return null;
        }
        public bool AddUserAccount(UserDTO userDTO)
        {
            try
            {
                
                var salt = DateTime.Now.ToString();
                var hashedPW = UserManager.HashedPassword($"{userDTO.PasswordHash}{salt.Trim()}");
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "INSERT INTO DTO_Users (Username, PasswordHash, Salt,RoleID) VALUES (@Username, @PasswordHash,  @Salt,@RoleID)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Username", userDTO.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPW);
                    cmd.Parameters.AddWithValue("@Salt", salt);
                    cmd.Parameters.AddWithValue("@RoleID", userDTO.RoleID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public User GetCurrentUserByUsername(string username)

        {

            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM DTO_Users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        var userDTO = new UserDTO
                        {
                            UserId = Convert.ToInt32(dr["UserID"]),
                            Username = dr["Username"].ToString().Trim(),
                            PasswordHash = dr["PasswordHash"].ToString(),
                            Salt = dr["Salt"].ToString(),
                            RoleID =Convert.ToInt32( dr["RoleID"])

                        };
                        return new User(userDTO); // Create a User object from the UserDTO
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

            return null; 
        }

        public UserDTO GetCurrentUserForVisitor(string username)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserAccount(UserDTO v)
        {
            throw new NotImplementedException();
        }

        
    }
}
