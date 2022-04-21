using System;

namespace FonotradeInvoiceControl.Exceptions
{
    public class ParseInvoiceFileException : Exception
    {
        public ParseInvoiceFileException(string message)
            : base(message)
        {
        }
    }
}
