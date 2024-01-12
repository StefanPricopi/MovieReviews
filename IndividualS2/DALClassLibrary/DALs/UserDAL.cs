using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;

namespace DALClassLibrary.DALs
{
    public class UserDAL:Connection, IUserManagerDAL
    {
        
        public bool AddUserAccount(UserDTO userDTO)
        {
            try
            {

                var salt = DateTime.Now.ToString();
                var hashedPW = UserManager.HashedPassword($"{userDTO.PasswordHash}{salt.Trim()}");

                using (SqlConnection conn = InitializeConection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insert into DTO_Users table
                        string userSql = "INSERT INTO DTO_Users (Username, PasswordHash, Salt, RoleID) VALUES (@Username, @PasswordHash, @Salt, @RoleID); SELECT SCOPE_IDENTITY();";
                        SqlCommand userCmd = new SqlCommand(userSql, conn, transaction);
                        userCmd.Parameters.AddWithValue("@Username", userDTO.Username);
                        userCmd.Parameters.AddWithValue("@PasswordHash", hashedPW);
                        userCmd.Parameters.AddWithValue("@Salt", salt);
                        userCmd.Parameters.AddWithValue("@RoleID", userDTO.RoleID);

                        // ExecuteScalar to get the generated identity value
                        int userId = Convert.ToInt32(userCmd.ExecuteScalar());

                        // Insert into DTO_UserProfile table
                        string profileSql = "INSERT INTO DTO_UserProfile (UserID, FirstName, LastName, Email, prefers_60s, prefers_daily, prefers_weekly) " +
                                            "VALUES (@UserID, 'J', 'M', 'j.m@gmail.com', 0, 0, 0)";
                        SqlCommand profileCmd = new SqlCommand(profileSql, conn, transaction);
                        profileCmd.Parameters.AddWithValue("@UserID", userId);
                        profileCmd.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an exception
                        transaction.Rollback();
                        // Handle exception
                        return false;
                    }
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

        public List<UserDTO> GetAllAccounts()
        {
            bool passed;
            List<UserDTO> accounts = new List<UserDTO>();
            try
            {
                using (SqlConnection conn = InitializeConection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM DTO_Users";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var userDTO = new UserDTO
                        {
                            UserId = Convert.ToInt32(dr["UserID"]),
                            Username = dr["Username"].ToString(),
                        };
                        accounts.Add(userDTO);
                    }
                    passed = true;
                }
            }
            catch (Exception ex)
            {
                passed = false;
                // Handle the exception (e.g., log the error)
            }

            if (passed == true)
            {
                return accounts;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateUserAccount(UserDTO v)
        {
            throw new NotImplementedException();
        }

        
    }
}
