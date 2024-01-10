using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Exceptions
{
    
    
        public class MediaException : Exception
        {
            public MediaException()
            {
            }

            public MediaException(string message)
                : base(message)
            {
            }

            public MediaException(string message, Exception innerException)
                : base(message, innerException)
            {

            }
        }
    
}
