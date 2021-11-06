using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace FonotradeInvoiceControl.VHSYS.Models
{
    public class VHSYSClient
    {
        [JsonProperty("id_cliente")]
        public int Id { get; set; }
        [JsonProperty("razao_cliente")]
        public String Name { get; set; }
        [JsonProperty("cnpj_cliente")]
        public String TaxIdNumber { get; set; }
    }
}
