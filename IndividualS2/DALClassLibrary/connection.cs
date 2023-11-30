using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary
{
    public class Connection
    {
        string conection = "Server=mssqlstud.fhict.local;Database=dbi451040;User Id=dbi451040;Password=Igj3U1KM7h;Encrypt=false;";

        public SqlConnection InitializeConection()
        {
            return new SqlConnection(conection);
        }
    }
}
