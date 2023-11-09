using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class ReviewDTO
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public decimal Score { get; set; }
        public string Description { get; set; }
        public int MediaID { get; set; }
        public int UserID {  get; set; }

        public ReviewDTO()
        {

        }
        public ReviewDTO(ReviewDTO r)
        {
           
        }
    }
}
