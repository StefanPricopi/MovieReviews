using DALClassLibrary.Interfaces;
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
    public class MovieDAL : Connection,IMovieManagerDAL
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

                        string g = mediaDTO.Genre.ToString();
                        cmdMedia.Parameters.AddWithValue("@Title", mediaDTO.Title.Trim());
                        cmdMedia.Parameters.AddWithValue("@Director", mediaDTO.Director.Trim());
                        cmdMedia.Parameters.AddWithValue("@Actor", mediaDTO.Actor.Trim());
                        cmdMedia.Parameters.AddWithValue("@Description", mediaDTO.Description.Trim());
                        cmdMedia.Parameters.AddWithValue("@Genre", g);

                        int mediaID = Convert.ToInt32(cmdMedia.ExecuteScalar()); // Get the auto-generated MediaID


                        using (SqlCommand cmdMovie = new SqlCommand("INSERT INTO DTO_Movie (Duration, ReleaseDate,MediaID) VALUES (@Duration, @ReleaseDate,@MediaID);", connection))
                        {
                            cmdMovie.Parameters.AddWithValue("@Duration", movieDTO.Duration.ToString().Trim());
                            cmdMovie.Parameters.AddWithValue("@ReleaseDate", movieDTO.Date.ToString().Trim());
                            cmdMovie.Parameters.AddWithValue("@MediaID", mediaID);
                            cmdMovie.ExecuteNonQuery();
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
        public DataTable SearchMovies(int id)
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string selectQuery1 = "SELECT DTO_Media.*, DTO_Movie.Duration, DTO_Movie.ReleaseDate\r\nFROM DTO_Media\r\nINNER JOIN DTO_Movie ON DTO_Media.MediaID = DTO_Movie.MediaID \r\n WHERE DTO_Media.MediaID=@MediaID";
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
        public DataTable GetAllMovies()
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string selectQuery1 = "SELECT DTO_Media.*, DTO_Movie.Duration, DTO_Movie.ReleaseDate\r\nFROM DTO_Media\r\nINNER JOIN DTO_Movie ON DTO_Media.MediaID = DTO_Movie.MediaID;\r\n";
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
        public bool UpdateMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
            int rowsAffectedMedia = 0;
            int rowsAffectedMovie = 0;

            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string updateQueryMedia = "UPDATE DTO_Media SET Title = @Title, Director = @Director, Actor = @Actor, Description = @Description, Genre = @Genre WHERE MediaID = @MediaID";

                        using (SqlCommand commandMedia = new SqlCommand(updateQueryMedia, connection, transaction))
                        {

                            commandMedia.Parameters.Add(new SqlParameter("@Title", mediaDTO.Title));
                            commandMedia.Parameters.Add(new SqlParameter("@Director", mediaDTO.Director));
                            commandMedia.Parameters.Add(new SqlParameter("@Actor", mediaDTO.Actor));
                            commandMedia.Parameters.Add(new SqlParameter("@Description", mediaDTO.Description));
                            commandMedia.Parameters.Add(new SqlParameter("@Genre", mediaDTO.Genre));
                            commandMedia.Parameters.Add(new SqlParameter("@MediaID", mediaDTO.Id));

                            rowsAffectedMedia = commandMedia.ExecuteNonQuery();
                        }

                        string updateQueryMovie = "UPDATE DTO_Movie SET Duration = @Duration, ReleaseDate = @ReleaseDate WHERE MediaID = @MediaID";

                        using (SqlCommand commandMovie = new SqlCommand(updateQueryMovie, connection, transaction))
                        {

                            commandMovie.Parameters.Add(new SqlParameter("@Duration", movieDTO.Duration.ToString().Trim()));
                            commandMovie.Parameters.Add(new SqlParameter("@ReleaseDate", movieDTO.Date.ToString().Trim()));
                            commandMovie.Parameters.Add(new SqlParameter("@MediaID", mediaDTO.Id.ToString().Trim()));

                            rowsAffectedMovie = commandMovie.ExecuteNonQuery();
                        }

                        // If both updates were successful, commit the transaction.
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return (rowsAffectedMedia > 0) && (rowsAffectedMovie > 0);
        }
    }
}
