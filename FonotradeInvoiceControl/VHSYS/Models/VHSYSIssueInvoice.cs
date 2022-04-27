using Newtonsoft.Json;

namespace FonotradeInvoiceControl.VHSYS.Models
{
    public class VHSYSIssueInvoice
    {
        [JsonProperty("NumeroNFS")]
        public string InvoiceNumber { get; set; }
    }
}
