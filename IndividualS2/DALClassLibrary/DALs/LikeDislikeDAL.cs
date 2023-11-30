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
    public class LikeDislikeDAL:Connection,ILikeDislike
    {
        public int AddLike(LikeDislikeDTO likeDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO DTO_LikesDislikes (UserID, MediaID, LikeStatus)
                        VALUES (@UserID, @MediaID,@LikeStatus);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID",likeDTO.UserID);
                        cmd.Parameters.AddWithValue("@MediaID",likeDTO.MediaID);
                        cmd.Parameters.AddWithValue("@LikeStatus","Like");

                        int insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                        if (insertedId > 0)
                        {
                            return insertedId; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return -1;
        }
        public int AddDislike (LikeDislikeDTO dislikeDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO DTO_LikesDislikes (UserID, MediaID, LikeStatus)
                        VALUES (@UserID, @MediaID, @LikeStatus);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", dislikeDTO.UserID);
                        cmd.Parameters.AddWithValue("@MediaID", dislikeDTO.MediaID);
                        cmd.Parameters.AddWithValue("@LikeStatus", "Dislike");

                        int insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                        if (insertedId > 0)
                        {
                            return insertedId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return -1;
        }
        public bool CheckUserLiked(LikeDislikeDTO c) 
        {
            bool userLiked = false;

            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM DTO_LikesDislikes WHERE UserID = @UserID AND MediaID = @MediaID AND LikeStatus = 'Like';";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", c.UserID);
                    command.Parameters.AddWithValue("@MediaID", c.MediaID);

                    int likeCount = Convert.ToInt32(command.ExecuteScalar());

                    userLiked = likeCount > 0;
                }
            }

            return userLiked;
        }
        public void RemoveLike(LikeDislikeDTO c)
        {
            using (SqlConnection connection = InitializeConection())
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM DTO_LikesDislikes WHERE UserID = @UserID AND MediaID = @MediaID AND LikeStatus = @LikeStatus;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", c.UserID);
                        command.Parameters.AddWithValue("@MediaID", c.MediaID);
                        command.Parameters.AddWithValue("@LikeStatus", "Like");

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error removing like: " + ex.Message);
                }
            }
        }

        public void RemoveDislike(LikeDislikeDTO c)
        {
            using (SqlConnection connection = InitializeConection())
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM DTO_LikesDislikes WHERE UserID = @UserID AND MediaID = @MediaID AND LikeStatus = @LikeStatus;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", c.UserID);
                        command.Parameters.AddWithValue("@MediaID", c.MediaID);
                        command.Parameters.AddWithValue("@LikeStatus", "Dislike");

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error removing dislike: " + ex.Message);
                }
            }
        }

        public void ToggleLikeDislike(LikeDislikeDTO c)
        {
            bool userLiked = CheckUserLiked(c);

            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                

                try
                {
                    if (userLiked)
                    {
                        RemoveLike(c);           
                        AddDislike(c);
                        
                    }
                    else
                    {
                        RemoveDislike(c);
                        if (!CheckUserLiked(c)) 
                        {
                            AddDislike(c);
                        }
                    }

                 
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public LikeDislikeDTO GetLikeDislike(int id)
        {
            
            
                LikeDislikeDTO likeDTO = null;

            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string selectQuery = "SELECT UserID, MediaID, LikeStatus FROM DTO_LikesDislikes WHERE MediaID=@MediaID";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameter for MediaID
                        command.Parameters.AddWithValue("@MediaID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                likeDTO = new LikeDislikeDTO();

                                likeDTO.UserID = Convert.ToInt32(reader["UserID"]);
                                likeDTO.MediaID = Convert.ToInt32(reader["MediaID"]);
                                likeDTO.LikeStatus = reader["LikeStatus"].ToString();

                                return likeDTO;
                            }
                            else
                            {
                                // Handle when no like/dislike info is found for the provided ID
                                throw new Exception("No like/dislike information found for the provided ID.");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or return null/throw a specific exception based on your needs
                throw new Exception("Error fetching like/dislike information: " + ex.Message);
            }
            }

        }
    }



