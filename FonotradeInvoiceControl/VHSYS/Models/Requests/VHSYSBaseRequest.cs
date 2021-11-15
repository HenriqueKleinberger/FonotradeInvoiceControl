using Newtonsoft.Json;
using System;

namespace FonotradeInvoiceControl.VHSYS.Models.Requests
{
    public abstract class VHSYSBaseRequest
    {
        [JsonProperty("ambiente")]
        public int Environment { get; set; }
    }
}