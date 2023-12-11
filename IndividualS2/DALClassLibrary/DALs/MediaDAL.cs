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

        public List<MediaDTO> RecommendationsAlgo(int id)
        {
            try
            {


                List<MediaDTO> mediaDTOs = new List<MediaDTO>();

                using (SqlConnection connection = InitializeConection())
                {
                    connection.Open();
                    string selectQuery1 = @"

                WITH RankedGenres AS (
                    SELECT Genre, ROW_NUMBER() OVER (ORDER BY SUM(CountOccurrence) DESC) AS GenreRank
                    FROM (
                        SELECT Genre, COUNT(*) AS CountOccurrence
                        FROM (
                            SELECT Genre
                            FROM DTO_Media M
                            INNER JOIN DTO_LikesDislikes LD ON M.MediaID = LD.MediaID
                            WHERE LD.UserID = @UserID
                            UNION ALL
                            SELECT Genre
                            FROM DTO_Media M
                            INNER JOIN DTO_Reviews R ON M.MediaID = R.MediaID
                            INNER JOIN DTO_Comments C ON R.ReviewID = C.ReviewID
                            WHERE C.UserID = @UserID
                        ) AS UserGenres
                        GROUP BY Genre
                    ) AS GenreCount
                    GROUP BY Genre
                ),
                RankedDirectors AS (
                    SELECT Director, ROW_NUMBER() OVER (ORDER BY SUM(CountOccurrence) DESC) AS DirectorRank
                    FROM (
                        SELECT Director, COUNT(*) AS CountOccurrence
                        FROM (
                            SELECT Director
                            FROM DTO_Media M
                            INNER JOIN DTO_LikesDislikes LD ON M.MediaID = LD.MediaID
                            WHERE LD.UserID = @UserID
                            UNION ALL
                            SELECT Director
                            FROM DTO_Media M
                            INNER JOIN DTO_Reviews R ON M.MediaID = R.MediaID
                            INNER JOIN DTO_Comments C ON R.ReviewID = C.ReviewID
                            WHERE C.UserID = @UserID
                        ) AS UserDirectors
                        GROUP BY Director
                    ) AS DirectorCount
                    GROUP BY Director
                ),
                RankedMedia AS (
                    -- Create a rank of all movies and TV series based on the score
                    SELECT 
                        M.MediaID,
                        M.Title,
                        M.Actor,
                        M.Genre,
                        M.Director,
                        (((SUM(CASE WHEN LD.LikeStatus = 'like' THEN 1 ELSE 0 END) * 0.6) - (SUM(CASE WHEN LD.LikeStatus = 'dislike' THEN 1 ELSE 0 END) * 0.4)) / NULLIF(COUNT(DISTINCT LD.UserID), 0)) +
                        ((COUNT(DISTINCT C.CommentID) / NULLIF(COUNT(DISTINCT LD.UserID), 0)) * 0.3) AS Score
                    FROM 
                        DTO_Media M
                    LEFT JOIN 
                        DTO_LikesDislikes LD ON M.MediaID = LD.MediaID
                    LEFT JOIN 
                        DTO_Reviews R ON M.MediaID = R.MediaID
                    LEFT JOIN 
                        DTO_Comments C ON R.ReviewID = C.ReviewID
                    GROUP BY 
                        M.MediaID, M.Title, M.Actor, M.Genre, M.Director
                ),
                FilteredMedia AS (
                    SELECT 
                        RM.MediaID,
                        RM.Title,
                        RM.Actor,
                        RM.Genre,
                        RM.Director,
                        RM.Score,
                        RG.Genre AS PreferredGenre,
                        RD.Director AS PreferredDirector,
                        ROW_NUMBER() OVER (PARTITION BY RG.Genre, RD.Director ORDER BY RM.Score DESC) AS RankWithinPreference
                    FROM 
                        RankedMedia RM
                    LEFT JOIN 
                        RankedGenres RG ON RM.Genre = RG.Genre
                    LEFT JOIN 
                        RankedDirectors RD ON RM.Director = RD.Director
                    LEFT JOIN 
                        DTO_LikesDislikes LD ON RM.MediaID = LD.MediaID
                    WHERE 
                        LD.UserID = @UserID
                        AND LD.LikeStatus = 'like'
                        AND NOT EXISTS (
                            SELECT 1
                            FROM DTO_LikesDislikes
                            WHERE MediaID = RM.MediaID AND UserID = @UserID AND LikeStatus = 'dislike'
                        )
                ),
                RankedWithoutPrefs AS (
                    SELECT 
                        MediaID,
                        Title,
                        Actor,
                        Genre,
                        Director,
                        Score,
                        ROW_NUMBER() OVER (ORDER BY Score DESC) AS RankWithoutPrefs
                    FROM RankedMedia
                    WHERE MediaID NOT IN (SELECT MediaID FROM FilteredMedia)
                )
                SELECT TOP 15 
                    MediaID,
                    Title,
                    Actor,
                    Genre,
                    Director,
                    Score
                FROM FilteredMedia
                WHERE RankWithinPreference <= 3 
                UNION ALL
                SELECT TOP 15 
                    MediaID,
                    Title,
                    Actor,
                    Genre,
                    Director,
                    Score
                FROM RankedWithoutPrefs
                WHERE MediaID NOT IN (SELECT MediaID FROM FilteredMedia)
                ORDER BY Score DESC; 
                            ";
                    using (SqlCommand command1 = new SqlCommand(selectQuery1, connection))
                    {
                        command1.Parameters.Add(new SqlParameter("@UserID", id));
                        using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
                        {
                            DataTable combinedDataTable = new DataTable();
                            adapter1.Fill(combinedDataTable);

                            // Populate mediaDTOs from the DataTable
                            foreach (DataRow row in combinedDataTable.Rows)
                            {
                                if (Enum.TryParse(row["Genre"].ToString(), out Genre parsedGenre))
                                {
                                    MediaDTO mediaDTO = new MediaDTO
                                    {
                                        Id = Convert.ToInt32(row["MediaID"]),
                                        Title = row["Title"].ToString(),
                                        Director = row["Director"].ToString(),
                                        Actor = row["Actor"].ToString(),
                                        Genre = parsedGenre
                                    };
                                    mediaDTOs.Add(mediaDTO);
                                }
                            }
                        }
                    }

                    return mediaDTOs;
                }
            }
            catch (Exception EX)
            {
                return new List<MediaDTO>();
            }
        }
        
    }

}
    

