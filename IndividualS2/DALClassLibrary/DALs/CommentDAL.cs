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

                    using (SqlCommand cmdReview = new SqlCommand("INSERT INTO [DTO_Comments] (ReviewID, CommentDescription) VALUES (@ReviewID, @CommentDescription); SELECT SCOPE_IDENTITY();", connection))
                    {
                        cmdReview.Parameters.AddWithValue("@ReviewID", commentDTO.ReviewID);
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
              
            }        
            return false;
        }

        public List<CommentDTO> GetAllComments()
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();

                string selectQuery1 = "SELECT CommentDescription, ReviewID FROM DTO_Comments";

                using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                {
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CommentDTO comment = new CommentDTO
                            {
                                CommentDescription = reader["CommentDescription"].ToString(),
                                ReviewID = Convert.ToInt32(reader["ReviewID"])
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
