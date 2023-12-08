using Microsoft.Data.SqlClient;
using ModelLibrary.BaseClasses;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class CommentDAL : Connection, ICommentDAL
    {
        public bool AddComment(CommentDTO commentDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    using (SqlCommand cmdReview = new SqlCommand("INSERT INTO DTO_Comments (ReviewID,UserID, CommentDescription) VALUES (@ReviewID,@UserID,@CommentDescription); SELECT SCOPE_IDENTITY();", connection))
                    {
                        cmdReview.Parameters.AddWithValue("@ReviewID", commentDTO.ReviewID);
                        cmdReview.Parameters.AddWithValue("@UserID", commentDTO.UserID);
                        cmdReview.Parameters.AddWithValue("@CommentDescription", commentDTO.CommentDescription);
                        int insertedId = Convert.ToInt32(cmdReview.ExecuteScalar());

                        if (insertedId > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);        
            }
            return false;
        }

        public List<CommentDTO> GetAllComments(int reviewID)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();

                string selectQuery1 = "SELECT CommentDescription,UserID, ReviewID FROM DTO_Comments WHERE ReviewID=@ReviewID";

                using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                {
                    command1.Parameters.AddWithValue("@ReviewID", reviewID); // Set the parameter value

                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CommentDTO comment = new CommentDTO
                            {
                                CommentDescription = reader["CommentDescription"].ToString(),
                                ReviewID = Convert.ToInt32(reader["ReviewID"]),
                                UserID = Convert.ToInt32(reader["UserID"])
                            };

                            comments.Add(comment);
                        }
                    }
                }
            }

            return comments;
        }

        public List<CommentDTO> GetAllCommentsByUser(int userID)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();

                string selectQuery1 = "SELECT CommentDescription,UserID, ReviewID FROM DTO_Comments WHERE UserID=@UserID";

                using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                {
                    command1.Parameters.AddWithValue("@UserID", userID); // Set the parameter value

                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CommentDTO comment = new CommentDTO
                            {
                                CommentDescription = reader["CommentDescription"].ToString(),
                                ReviewID = Convert.ToInt32(reader["ReviewID"]),
                                UserID = Convert.ToInt32(reader["UserID"])
                            };

                            comments.Add(comment);
                        }
                    }
                }
            }

            return comments;
        }
    }
}
