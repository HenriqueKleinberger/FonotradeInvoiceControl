using Newtonsoft.Json;
using System;

namespace FonotradeInvoiceControl.VHSYS.Models
{
    public class VHSYSRegisterInvoice
    {
        [JsonProperty("id_servico")]
        public int ServiceId { get; set; }

        [JsonProperty("id_pedido")]
        public int RegisterId { get; set; }

        [JsonProperty("id_cliente")]
        public int ClientId { get; set; }

        [JsonProperty("nome_cliente")]
        public String ClientName { get; set; }

        [JsonProperty("vendedor_pedido")]
        public String SellerName { get; set; }

        [JsonProperty("desc_servicos")]
        public String ServiceDescription { get; set; }

        [JsonProperty("valor_total_servicos")]
        public Decimal Value { get; set; }
    }
}
