using ChecksumManager.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChecksumManager.Attributes
{
    public class ChecksumAttribute : AuthorizeAttribute
    {
        private ChecksumCalculator _checksumCalculator;

        public ChecksumAttribute()
        {
            _checksumCalculator = new ChecksumCalculator();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;

            ushort checksum    = Convert.ToUInt16(httpContext.Request.Headers["Checksum"]);
             
            if (checksum > 0 && httpContext.Request.InputStream != null)
            {
                string jsonText = new StreamReader(httpContext.Request.InputStream).ReadToEnd();

                result = Compare(jsonText, checksum);
            } 

            return result;
        }

        private bool Compare(string jsonText, ushort checksum)
        {
            bool result = false;

            try
            {
                result = _checksumCalculator.Compare(jsonText, checksum);
            } 
            catch 
            {
                result = false;
            }

            return result;
        }
    }
}
