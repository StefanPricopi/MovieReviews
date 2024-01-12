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
    public class UserProfileDAL : Connection, IUserProfileDAL
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
        public List<string> GetUserNewsletterPreferences(int userId)
        {
            List<string> preferences = new List<string>();
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string query = "SELECT prefers_60s, prefers_daily, prefers_weekly FROM DTO_UserProfile WHERE UserID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check boolean columns for user preferences
                            if ((bool)reader["prefers_60s"])
                            {
                                preferences.Add("60s");
                            }

                            if ((bool)reader["prefers_daily"])
                            {
                                preferences.Add("daily");
                            }

                            if ((bool)reader["prefers_weekly"])
                            {
                                preferences.Add("weekly");
                            }
                        }
                    }
                }
            }

            return preferences;
        }
        public void UpdateUserNewsletterPreferences(int userId, bool prefers60s, bool prefersDaily, bool prefersWeekly)
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string query = @"
            UPDATE DTO_UserProfile
            SET prefers_60s = @Prefers60s, prefers_daily = @PrefersDaily, prefers_weekly = @PrefersWeekly
            WHERE UserID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Prefers60s", prefers60s);
                    command.Parameters.AddWithValue("@PrefersDaily", prefersDaily);
                    command.Parameters.AddWithValue("@PrefersWeekly", prefersWeekly);

                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
