using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class ReviewDAL : Connection, IReviewManagerDAL
    {
        public bool AddReview(ReviewDTO reviewDTO)
        {

            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    
                    using (SqlCommand cmdReview = new SqlCommand("INSERT INTO [DTO_Reviews] (Title, Score, Description) VALUES (@Title, @Score, @Description); SELECT SCOPE_IDENTITY();", connection))
                    {
                        

                        cmdReview.Parameters.AddWithValue("@Title",reviewDTO.Title);
                        cmdReview.Parameters.AddWithValue("@Score", reviewDTO.Score);
                        cmdReview.Parameters.AddWithValue("@Description", reviewDTO.Description);
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

                    string selectQuery1 = "SELECT Title, Score, Description FROM DTO_Reviews";

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

        public Review GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReview(ReviewDTO reviewDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    string updateQuery = "UPDATE DTO_Reviews SET Title = @Title, Score = @Score, Description = @Description WHERE ReviewID = @ReviewID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", reviewDTO.Title);
                        command.Parameters.AddWithValue("@Score", reviewDTO.Score);
                        command.Parameters.AddWithValue("@Description", reviewDTO.Description);
                        command.Parameters.AddWithValue("@ReviewID", reviewDTO.Id);


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
    }
}
