using System;

namespace FonotradeInvoiceControl.Exceptions
{
    public class VHSYSServiceException : Exception
    {
        public VHSYSServiceException()
        {
        }

        public VHSYSServiceException(string message)
            : base(message)
        {
        }

        public VHSYSServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
