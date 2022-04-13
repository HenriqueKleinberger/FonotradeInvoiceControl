using FonotradeInvoiceControl.DTO;
using Newtonsoft.Json;
using System;

namespace FonotradeInvoiceControl.VHSYS.Models.Requests
{
    public class VHSYSRegisterInvoiceRequest : VHSYSBaseRequest
    {
        [JsonProperty("id_cliente")]
        public int ClientId { get; set; }

        [JsonProperty("nome_cliente")]
        public String ClientName { get; set; }

        [JsonProperty("vendedor_pedido")]
        public String SellerName { get; set; }

        [JsonProperty("desc_servicos")]
        public String ServiceDescription { get; set; }

        [JsonProperty("valor_total_servicos")]
        public Decimal ServiceValue { get; set; }

        [JsonProperty("valor_base_calculo")]
        public Decimal CalculationValue { get; set; }

        [JsonProperty("valor_total_nota")]
        public Decimal TotalValue { get; set; }

        [JsonProperty("serie_nota")]
        public int Batch { get; set; }

        [JsonProperty("regime_pedido")]
        public int TaxPolicy { get; set; }

        [JsonProperty("natureza_pedido")]
        public int ServiceNature { get; set; }

        [JsonProperty("local_prestacao")]
        public int Place { get; set; }

        [JsonProperty("local_prestacao_cidade")]
        public String City { get; set; }

        [JsonProperty("status_pedido")]
        public String Status { get; set; }

        [JsonProperty("itemLista_servico")]
        public int BusinessCode { get; set; }

        public VHSYSRegisterInvoiceRequest(InvoiceDTO invoice, ClientDTO clientDTO, int environment)
        {
            Environment = environment;
            ClientId = clientDTO.ExternalSystemId;
            ClientName = clientDTO.Name;
            ServiceDescription = invoice.Description;
            ServiceValue = invoice.Value;
            TotalValue = invoice.Value;
            CalculationValue = invoice.Value;
            Batch = Constants.VHSYS.RegisterInvoice.DEFAULT_BATCH;
            SellerName = invoice.Technician;
            TaxPolicy = Constants.VHSYS.RegisterInvoice.DEFAULT_TAX_POLICY;
            ServiceNature = Constants.VHSYS.RegisterInvoice.DEFAULT_SERVICE_NATURE;
            Place = Constants.VHSYS.RegisterInvoice.DEFAULT_PLACE;
            City = Constants.VHSYS.RegisterInvoice.DEFAULT_CITY;
            Status = Constants.VHSYS.RegisterInvoice.DEFAULT_STATUS;
            BusinessCode = Constants.VHSYS.RegisterInvoice.DEFAULT_BUSINESS_CODE;
        }
    }
}