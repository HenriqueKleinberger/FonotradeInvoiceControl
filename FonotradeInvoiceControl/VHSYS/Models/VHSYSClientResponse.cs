using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.VHSYS.Models
{
    public class VHSYSClientResponse
    {
        public String code { get; set; }

        [JsonProperty("data")]
        public IEnumerable<VHSYSClient> Clients { get; set; }
    }
}
