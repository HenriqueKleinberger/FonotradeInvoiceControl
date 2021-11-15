using FonotradeInvoiceControl.VHSYS.Models.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.VHSYS.Models.Responses
{
    public class VHSYSClientResponse : VHSYSBaseResponse
    {
        public IEnumerable<VHSYSClient> Data { get; set; }
    }
}
