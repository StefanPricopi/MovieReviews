using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface IReviewUtility
    {
        public List<string> GetAllReviewTitles();
        public List<ReviewDTO> DatagridToList(DataTable dataTable);
    }
}
