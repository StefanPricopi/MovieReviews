using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DALClassLibrary.DALs
{
    public class MediaDAL : Connection, IMediaManagerDAL
    {



        public List<string> GetAllTitles()
        {
            List<string> titles = new List<string>();
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string query = "SELECT Title FROM DTO_Media";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["Title"].ToString().Trim();
                                titles.Add(title);
                            }
                        }
                    }
                    return titles;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public int GetMediaByTitle(string title)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand("SELECT MediaID FROM DTO_Media WHERE Title = @Title", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Title", title));
                        object result = command.ExecuteScalar();
                        int mediaID = Convert.ToInt32(result);
                        return mediaID;
                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public MediaDTO GetActualMediaByID(int id)
        {
            try
            {
                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string selectQuery1 = "SELECT MediaID, Title, Director,Actor, Description,Genre FROM DTO_Media WHERE MediaID=@MediaID";
                    using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                    {
                        // Add parameter for MediaID
                        command1.Parameters.AddWithValue("@MediaID", id);

                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MediaDTO r = new MediaDTO();

                                r.Id = Convert.ToInt32(reader["MediaID"]);
                                r.Title = reader["Title"].ToString();
                                r.Actor = reader["Actor"].ToString();
                                r.Director = reader["Director"].ToString();
                                r.Description = reader["Description"].ToString();

                                if (Enum.TryParse(reader["Genre"].ToString(), out Genre genre))
                                {
                                    r.Genre = genre;
                                }
                                return r;
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
        public List<MediaDTO> DatagridToList(DataTable dataTable)
        {
            List<MediaDTO> mediaList = new List<MediaDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["MediaID"] != DBNull.Value &&
                    row["Title"] != DBNull.Value &&
                    row["Director"] != DBNull.Value &&
                    row["Actor"] != DBNull.Value &&
                    row["Description"] != DBNull.Value &&
                    row["Genre"] != DBNull.Value)
                {
                    if (Enum.TryParse(row["Genre"].ToString(), out Genre parsedGenre))
                    {
                        MediaDTO mediaItem = new MediaDTO
                        {
                            Id = Convert.ToInt32(row["MediaID"]),
                            Title = row["Title"].ToString(),
                            Director = row["Director"].ToString(),
                            Actor = row["Actor"].ToString(),
                            Description = row["Description"].ToString(),
                            Genre = parsedGenre
                        };

                        mediaList.Add(mediaItem);
                    }                    
                }
            }

            return mediaList;
        }
    }
                
}
    

