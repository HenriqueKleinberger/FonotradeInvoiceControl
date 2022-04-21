using System;

namespace FonotradeInvoiceControl.VHSYS.Models.Response
{
    public abstract class VHSYSBaseResponse<T>
    {
        public int code { get; set; }

        public String status { get; set; }

        public T data { get; set; }
    }
}