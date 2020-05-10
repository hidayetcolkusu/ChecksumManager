using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumManager.Exceptions
{
    [Serializable]
    public class ChecksumException  : Exception
    { 
        public ChecksumException()
        {

        }

        public ChecksumException(string message): base(message)
        { 
        
        }

        public ChecksumException(string message, Exception innerException): base(message, innerException)
        { 
        
        }
    }
}
