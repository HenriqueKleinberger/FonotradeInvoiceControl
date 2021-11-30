using System;

namespace FonotradeInvoiceControl.Exceptions
{
    public class ParseInvoiceFileException : Exception
    {
        public ParseInvoiceFileException()
        {
        }

        public ParseInvoiceFileException(string message)
            : base(message)
        {
        }

        public ParseInvoiceFileException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
