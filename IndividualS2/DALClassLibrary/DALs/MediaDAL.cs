using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DALClassLibrary.DALs
{
    public class MediaDAL : Connection,IMediaManagerDAL
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
            catch(Exception ex)
            {
                return -1;
            }
           
        }
    
    }
}
