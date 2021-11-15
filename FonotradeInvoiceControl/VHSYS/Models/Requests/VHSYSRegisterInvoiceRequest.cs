using FonotradeInvoiceControl.DTO;
using Newtonsoft.Json;
using System;

namespace FonotradeInvoiceControl.VHSYS.Models.Requests
{
    public class VHSYSRegisterInvoiceRequest : VHSYSBaseRequest
    {
        private const int DEFAULT_BATCH = 1;
        private const int DEFAULT_TAX_POLICY = 1;
        private const int DEFAULT_SERVICE_NATURE = 1;
        private const int ISSUER_ADDRESS = 0;
        private const string RIO_DE_JANEIRO = "Rio de Janeiro";
        private const string DEFAULT_STATUS = "Em aberto";
        private const int DEFAULT_BUSINESS_CODE = 6359;

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

        [JsonProperty("atividade")]
        public int BusinessCode { get; set; }

        public VHSYSRegisterInvoiceRequest(InvoiceDTO invoice, VHSYSClient vhsysClient, int environment)
        {
            Environment = environment;
            ClientId = vhsysClient.Id;
            ClientName = vhsysClient.Name;
            ServiceDescription = invoice.Description;
            ServiceValue = invoice.Value;
            TotalValue = invoice.Value;
            CalculationValue = invoice.Value;
            Batch = DEFAULT_BATCH;
            SellerName = invoice.Technician;
            TaxPolicy = DEFAULT_TAX_POLICY;
            ServiceNature = DEFAULT_SERVICE_NATURE;
            Place = ISSUER_ADDRESS;
            City = RIO_DE_JANEIRO;
            Status = DEFAULT_STATUS;
            BusinessCode = DEFAULT_BUSINESS_CODE;
        }
    }
}