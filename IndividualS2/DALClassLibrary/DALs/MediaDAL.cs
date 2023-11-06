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

namespace DALClassLibrary.DALs
{
    public class MediaDAL : Connection,IMediaManagerDAL
    {
        public bool AddMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
            try
            {


                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                   
                    using (SqlCommand cmdMedia = new SqlCommand("INSERT INTO DTO_Media (Title, Director, Actor, Description,Genre) VALUES (@Title, @Director, @Actor, @Description,@Genre); SELECT SCOPE_IDENTITY();", connection))
                    {
                        

                        cmdMedia.Parameters.AddWithValue("@Title", mediaDTO.Title);
                        cmdMedia.Parameters.AddWithValue("@Director", mediaDTO.Director);
                        cmdMedia.Parameters.AddWithValue("@Actor", mediaDTO.Actor);
                        cmdMedia.Parameters.AddWithValue("@Description", mediaDTO.Description);
                        cmdMedia.Parameters.AddWithValue("@Genre", mediaDTO.Genre);

                        int mediaID = Convert.ToInt32(cmdMedia.ExecuteScalar()); // Get the auto-generated MediaID

                        // Insert into movie table with the obtained UserID
                        using (SqlCommand cmdMovie = new SqlCommand("INSERT INTO DTO_Movie (Duration, ReleaseDate,MediaID) VALUES (@Duration, @ReleaseDate,@MediaID);", connection))
                        {
                            cmdMovie.Parameters.AddWithValue("@Duration", movieDTO.Duration);
                            cmdMovie.Parameters.AddWithValue("@ReleaseDate", movieDTO.Date);
                            cmdMovie.Parameters.AddWithValue("@MediaID", mediaID); // Use the obtained UserID
                            cmdMovie.ExecuteNonQuery(); // Insert movie record
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

       

        public DataTable GetAllMedia()
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                

                string selectQuery1 = "SELECT DTO_Media.Title,DTO_Media.Director,DTO_Media.Actor,DTO_Media.Description,DTO_Media.Genre, DTO_Movie.duration, DTO_Movie.ReleaseDate " +
                                    "FROM DTO_Media " +
                                    "INNER JOIN DTO_Movie ON DTO_Media.MediaID = DTO_Movie.mediaID";
                

                
                using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                {
                    using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
                    {
                        DataTable combinedDataTable = new DataTable();
                        adapter1.Fill(combinedDataTable);
                        
                        return combinedDataTable;
                    }              
                }
            }
        }

        public Media GetMediaById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(MediaDTO mediaDTO,MovieDTO movieDTO)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();

                    string updateQuery = "UPDATE DTO_Media (Title, Director, Actor, Description,Genre) VALUES (@Title, @Director, @Actor, @Description,@Genre) WHERE MediaID = @MediaID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", mediaDTO.Title);
                        command.Parameters.AddWithValue("@Director", mediaDTO.Director);
                        command.Parameters.AddWithValue("@Actor", mediaDTO.Actor);
                        command.Parameters.AddWithValue("@Description", mediaDTO.Description);
                        command.Parameters.AddWithValue("@Genre", mediaDTO.Genre);
                        command.Parameters.AddWithValue("@MediaID", mediaDTO.Id);
                        int mediaID = Convert.ToInt32(command.ExecuteScalar()); // Get the auto-generated MediaID

                        using (SqlCommand cmdMovie = new SqlCommand("UPDATE DTO_Movie (Duration, ReleaseDate,MediaID) VALUES (@Duration, @ReleaseDate,@MediaID);", connection))
                        {
                            cmdMovie.Parameters.AddWithValue("@Duration", movieDTO.Duration);
                            cmdMovie.Parameters.AddWithValue("@ReleaseDate", movieDTO.Date);
                            cmdMovie.Parameters.AddWithValue("@MediaID", mediaDTO.Id); 
                            cmdMovie.ExecuteNonQuery(); 
                            
                        }
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
