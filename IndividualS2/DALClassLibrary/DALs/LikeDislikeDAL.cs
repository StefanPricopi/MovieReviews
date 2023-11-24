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
        public int AddLike(LikeDislikeDTO likeDTO, SqlTransaction transaction)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO DTO_LikesDislikes (UserID, MediaID, LikeStatus)
                        VALUES (@UserID, @MediaID, 'Like');
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID",likeDTO.UserID);
                        cmd.Parameters.AddWithValue("@MediaID",likeDTO.MediaID);

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
        public int AddDislike (LikeDislikeDTO dislikeDTO,SqlTransaction transaction)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO DTO_LikesDislikes (UserID, MediaID, LikeStatus)
                        VALUES (@UserID, @MediaID, 'Dislike');
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", dislikeDTO.UserID);
                        cmd.Parameters.AddWithValue("@MediaID", dislikeDTO.MediaID);

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
        public void RemoveLike(LikeDislikeDTO c, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;

                command.CommandText = "DELETE FROM DTO_LikesDislikes WHERE UserID = @UserID AND MediaID = @MediaID AND LikeStatus = 'Like';";
                command.Parameters.AddWithValue("@UserID", c.UserID);
                command.Parameters.AddWithValue("@MediaID", c.MediaID);

                command.ExecuteNonQuery();
            }
        }
        public void RemoveDislike(LikeDislikeDTO c, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;

                command.CommandText = "DELETE FROM DTO_LikesDislikes WHERE UserID = @UserID AND MediaID = @MediaID AND LikeStatus = 'Dislike';";
                command.Parameters.AddWithValue("@UserID", c.UserID);
                command.Parameters.AddWithValue("@MediaID", c.MediaID);

                command.ExecuteNonQuery();
            }
        }
        public void ToggleLikeDislike(LikeDislikeDTO c)
        {
            bool userLiked = CheckUserLiked(c);

            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    if (userLiked)
                    {
                        RemoveLike(c, transaction);           
                        AddDislike(c, transaction);
                        
                    }
                    else
                    {
                        RemoveDislike(c, transaction);
                        if (!CheckUserLiked(c)) 
                        {
                            AddDislike(c, transaction);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

    }
}


