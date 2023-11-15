using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;

namespace DALClassLibrary.DALs
{
    public class UserDAL:Connection, IUSERManagerDAL
    {
        
        public bool AddUserAccount(UserDTO userDTO)
        {
            try
            {
                
                var salt = DateTime.Now.ToString();
                var hashedPW = UserManager.HashedPassword($"{userDTO.PasswordHash}{salt.Trim()}");
                using (SqlConnection conn = InitializeConection())
                {
                    string sql = "INSERT INTO users (Username, Password, Salt) VALUES (@Username, @Password, , @Salt)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Username", userDTO.Username);
                    cmd.Parameters.AddWithValue("@Password", hashedPW);
                    cmd.Parameters.AddWithValue("@Salt", salt);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
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
                    string sql = "SELECT * FROM users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        var userDTO = new UserDTO
                        {
                            UserId = Convert.ToInt32(dr["UserID"]),
                            Username = dr["Username"].ToString(),
                            PasswordHash = dr["Password"].ToString(),
                            Salt = dr["Salt"].ToString(),


                        };
                        return new User(userDTO); // Create a User object from the UserDTO
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
            }

            return null; // Return null if no user with the specified email is found
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
