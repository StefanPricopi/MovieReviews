using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DALClassLibrary.DALs
{
    public class ReviewDAL : Connection, IReviewManagerDAL
    {
        MediaDAL m = new MediaDAL();
        public bool AddReview(ReviewDTO reviewDTO)
        {

            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    
                    using (SqlCommand cmdReview = new SqlCommand("INSERT INTO [DTO_Reviews] (Title, Score, Description,MediaID,UserID) VALUES (@Title, @Score, @Description,@MediaID,@UserID); SELECT SCOPE_IDENTITY();", connection))
                    {

                        int user = 1;
                        cmdReview.Parameters.AddWithValue("@Title",reviewDTO.Title);
                        cmdReview.Parameters.AddWithValue("@Score", reviewDTO.Score);
                        cmdReview.Parameters.AddWithValue("@Description", reviewDTO.Description);
                        cmdReview.Parameters.AddWithValue("@MediaID", reviewDTO.MediaID);
                        cmdReview.Parameters.AddWithValue("@UserID", user);
                        cmdReview.ExecuteNonQuery(); // Insert employee record
                        return true;

                    }

                }
            }


            catch (Exception ex)
            {
                return false;
            }

        }
        

        public DataTable GetAllReview()
        {
   
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    string selectQuery1 = "SELECT ReviewID,Title, Score, Description,MediaID,UserID FROM DTO_Reviews";

                    using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                    {
                        using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
                        {
                            DataTable reviewDataTable = new DataTable();
                            adapter1.Fill(reviewDataTable);
                            

                        return (reviewDataTable);
                        }
                    }
                }
        }
        public DataTable GetAllArchivedReview()
        {

            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();

                string selectQuery1 = "SELECT ArchiveReviewID,Title, Score, Description,MediaID FROM DTO_ReviewArchive";

                using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                {
                    using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
                    {
                        DataTable reviewDataTable = new DataTable();
                        adapter1.Fill(reviewDataTable);


                        return (reviewDataTable);
                    }
                }
            }
        }
        public DataTable GetReviewById(int id)
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string selectQuery1 = "SELECT ReviewID,Title, Score, Description,MediaID FROM DTO_Reviews WHERE ReviewID=@ReviewID";
                using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                {
                    using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
                    {
                        command1.Parameters.Add(new SqlParameter("@ReviewID", id));
                        DataTable combinedDataTable = new DataTable();
                        adapter1.Fill(combinedDataTable);

                        return combinedDataTable;
                    }
                }
            }
        }
        public int GetReviewByTitle(string title)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand("SELECT ReviewID FROM DTO_Reviews WHERE Title = @Title", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Title", title));
                        object result = command.ExecuteScalar();
                        int reviewID = Convert.ToInt32(result);
                        return reviewID;
                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public DataTable GetReviewByMedia(int id)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string selectQuery1 = "SELECT ReviewID,Title, Score, Description,MediaID FROM DTO_Reviews WHERE MediaID=@MediaID";
                    using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                    {
                        using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
                        {
                            command1.Parameters.Add(new SqlParameter("@MediaID", id));
                            DataTable combinedDataTable = new DataTable();
                            adapter1.Fill(combinedDataTable);

                            return combinedDataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }

        }
        public ReviewDTO GetActualReviewByMedia(int id)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string selectQuery1 = "SELECT ReviewID, Title, Score, Description, MediaID, UserID FROM DTO_Reviews WHERE ReviewID=@ReviewID";
                    using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                    {
                       
                        command1.Parameters.AddWithValue("@ReviewID", id);

                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create a ReviewDTO object and populate it with data from the result
                                ReviewDTO r = new ReviewDTO
                                {
                                    Id = Convert.ToInt32(reader["ReviewID"]),
                                    Title = reader["Title"].ToString(),
                                    Score = Convert.ToDecimal(reader["Score"]),
                                    Description = reader["Description"].ToString(),
                                    MediaID = Convert.ToInt32(reader["MediaID"]),
                                    UserID = Convert.ToInt32(reader["UserID"])
                                };

                                return r;
                            }
                            else { throw new Exception("Invalid ID"); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a review");
                return null;
            }

            
        }
        public List<ReviewDTO> DatagridToList(DataTable dataTable)
        {
            List<ReviewDTO> reviewList = new List<ReviewDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ReviewID"] != DBNull.Value &&
                    row["Title"] != DBNull.Value &&
                    row["Score"] != DBNull.Value &&
                    row["Description"] != DBNull.Value &&
                    row["UserID"] != DBNull.Value &&
                    row["MediaID"] != DBNull.Value)
                {
                    
                        ReviewDTO reviewItem = new ReviewDTO
                        {
                            Id = Convert.ToInt32(row["ReviewID"]),
                            Title= row["Title"].ToString(),
                            Score =Convert.ToDecimal( row["Score"]),
                            Description =row["Description"].ToString(),
                            MediaID =Convert.ToInt32( row["MediaID"]),
                            UserID = Convert.ToInt32(row["UserID"]),

                        };

                        reviewList.Add(reviewItem);
                    
                }
            }

            return reviewList;
        }



        public bool UpdateReview(ReviewDTO reviewDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    string updateQuery = "UPDATE DTO_Reviews SET Title = @Title, Score = @Score, Description = @Description,MediaID=@MediaID WHERE ReviewID = @ReviewID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        int user = 1;
                        command.Parameters.AddWithValue("@Title", reviewDTO.Title);
                        command.Parameters.AddWithValue("@Score", reviewDTO.Score);
                        command.Parameters.AddWithValue("@Description", reviewDTO.Description);
                        command.Parameters.AddWithValue("@ReviewID", reviewDTO.Id);
                        command.Parameters.AddWithValue("@MediaID", reviewDTO.MediaID);
                        command.Parameters.AddWithValue("@UserID", user);


                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0; // Return true if at least one row was affected by the update.
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<string> GetAllReviewTitles()
        {
            List<string> reviewTitles = new List<string>();
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string query = "SELECT Title FROM DTO_Reviews";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["Title"].ToString().Trim();
                                reviewTitles.Add(title);
                            }
                        }
                    }
                    return reviewTitles;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool AddArchiveReview(ReviewDTO reviewDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    using (SqlCommand cmdReview = new SqlCommand("INSERT INTO [DTO_ReviewArchive] (Title, Score, Description,MediaID,UserID) VALUES (@Title, @Score, @Description,@MediaID,@UserID); SELECT SCOPE_IDENTITY();", connection))
                    {
                        int user = 1;
                        cmdReview.Parameters.AddWithValue("@Title", reviewDTO.Title);
                        cmdReview.Parameters.AddWithValue("@Score", reviewDTO.Score);
                        cmdReview.Parameters.AddWithValue("@Description", reviewDTO.Description);
                        cmdReview.Parameters.AddWithValue("@MediaID", reviewDTO.MediaID);
                        cmdReview.Parameters.AddWithValue("@UserID", user);
                        cmdReview.ExecuteNonQuery(); // Insert employee record
                        return true;
                    }
                }
            }

            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteReview(int id)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string deleteCommand = "DELETE FROM DTO_Reviews WHERE ReviewID = @ReviewID";
                    using (SqlCommand command = new SqlCommand(deleteCommand, connection))
                    {
                        command.Parameters.AddWithValue("@ReviewID", id);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ReviewDTO GetActualReviewByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
