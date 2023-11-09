using DALClassLibrary.Interfaces;
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
    public class TvSeriesDAL:Connection,ITvSeriesManagerDAL
    {
        public bool AddTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvseriesDTO)
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


                        using (SqlCommand cmdMovie = new SqlCommand("INSERT INTO DTO_TvSeries (MediaID,NrOfSeasons, PilotDate,EndDate,Status) VALUES (@MediaID,@NrOfSeasons, @PilotDate,@EndDate,@Status);", connection))
                        {
                            string t = tvseriesDTO.Status.ToString();
                            cmdMovie.Parameters.AddWithValue("@NrOfSeasons", tvseriesDTO.NrOfSeasons);
                            cmdMovie.Parameters.AddWithValue("@PilotDate", tvseriesDTO.PilotDate);
                            cmdMovie.Parameters.AddWithValue("@EndDate", tvseriesDTO.LastEpisodeDate);
                            cmdMovie.Parameters.AddWithValue("@Status", t);
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
        public DataTable SearchTvSeries(int id)
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string selectQuery1 = "SELECT DTO_Media.*, DTO_TvSeries.NrOfSeasons, DTO_TvSeries.Status,DTO_TvSeries.PilotDate,DTO_TvSeries.EndDate\r\nFROM DTO_Media\r\nINNER JOIN DTO_TvSeries ON DTO_Media.MediaID = DTO_TvSeries.MediaID \r\n WHERE DTO_TvSeries.MediaID=@MediaID";
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
        public DataTable GetAllTvSeries()
        {
            using (SqlConnection connection = InitializeConection())
            {
                connection.Open();
                string selectQuery1 = "SELECT DTO_Media.*, DTO_TvSeries.NrOfSeasons, DTO_TvSeries.Status,DTO_TvSeries.PilotDate,DTO_TvSeries.EndDate\r\nFROM DTO_Media\r\nINNER JOIN DTO_TvSeries ON DTO_Media.MediaID = DTO_TvSeries.MediaID;\r\n";
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
        public bool UpdateTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvseriesDTO)
        {
            int rowsAffectedMedia = 0;
            int rowsAffectedTvSeries = 0;

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
                            string g = mediaDTO.Genre.ToString();
                            commandMedia.Parameters.Add(new SqlParameter("@Title", mediaDTO.Title));
                            commandMedia.Parameters.Add(new SqlParameter("@Director", mediaDTO.Director));
                            commandMedia.Parameters.Add(new SqlParameter("@Actor", mediaDTO.Actor));
                            commandMedia.Parameters.Add(new SqlParameter("@Description", mediaDTO.Description));
                            commandMedia.Parameters.Add(new SqlParameter("@Genre", g));
                            commandMedia.Parameters.Add(new SqlParameter("@MediaID", mediaDTO.Id));

                            rowsAffectedMedia = commandMedia.ExecuteNonQuery();
                        }

                        string updateQueryMovie = "UPDATE DTO_TvSeries SET NrOfSeasons = @NrOfSeasons, PilotDate = @PilotDate,EndDate=@EndDate,Status=@Status WHERE MediaID = @MediaID";

                        using (SqlCommand commandMovie = new SqlCommand(updateQueryMovie, connection, transaction))
                        {
                            string s = tvseriesDTO.Status.ToString();
                            commandMovie.Parameters.Add(new SqlParameter("@NrOfSeasons", tvseriesDTO.NrOfSeasons));
                            commandMovie.Parameters.Add(new SqlParameter("@PilotDate", tvseriesDTO.PilotDate));
                            commandMovie.Parameters.Add(new SqlParameter("@EndDate", tvseriesDTO.LastEpisodeDate));
                            commandMovie.Parameters.Add(new SqlParameter("@Status", s));
                            commandMovie.Parameters.Add(new SqlParameter("@MediaID", mediaDTO.Id));

                            rowsAffectedTvSeries = commandMovie.ExecuteNonQuery();
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
            return (rowsAffectedMedia > 0) && (rowsAffectedTvSeries > 0);
        }

    }
}
