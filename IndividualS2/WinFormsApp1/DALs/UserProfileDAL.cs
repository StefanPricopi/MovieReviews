using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class UserProfileDAL:Connection,IUserProfileDAL
    {
        public UserProfileDTO GetActualProfileByID(int id)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string selectQuery1 = "SELECT * FROM DTO_UserProfile WHERE UserID=@UserID";
                    using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                    {
                        // Add parameter for UserID
                        command1.Parameters.AddWithValue("@UserID", id);

                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserProfileDTO u = new UserProfileDTO();

                                u.userID = Convert.ToInt32(reader["UserID"]);
                                u.email = reader["Email"].ToString();
                                u.lastName = reader["LastName"].ToString();
                                u.firstName = reader["FirstName"].ToString();
                                return u;
                            }
                            else
                            {
                                throw new Exception("invalid ID");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid ID");
            }
        }
    }
}
