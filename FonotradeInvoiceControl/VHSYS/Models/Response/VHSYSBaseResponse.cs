using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.VHSYS.Models.Response
{
    public abstract class VHSYSBaseResponse
    {
        public String Code { get; set; }

        public String Status { get; set; }

    }
}