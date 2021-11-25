using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models.Requests;
using System;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using FonotradeInvoiceControl.Exceptions;
using FonotradeInvoiceControl.Mappers;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSInvoiceService : VHSYSService, IVHSYSInvoiceService
    {
        public VHSYSInvoiceService(IConfiguration config) : base(config) {}

        public InvoiceFeedbackDTO RegisterInvoice(InvoiceDTO invoice, ClientDTO clientDTO)
        {
            IRestResponse response = Register(invoice, clientDTO);
            VHSYSRegisterInvoiceResponse registerInvoiceResponse = ParseResponse<VHSYSRegisterInvoiceResponse>(response);

            return registerInvoiceResponse.Data.ToInvoiceFeedbackDTO(invoice);
        }

        private IRestResponse Register(InvoiceDTO invoice, ClientDTO clientDTO)
        {
            int environment = _config.GetValue<int>("VHSYS:ApiConfig:environment");
            VHSYSRegisterInvoiceRequest invoiceRequest = new VHSYSRegisterInvoiceRequest(invoice, clientDTO, environment);
            IRestResponse response = Post("notas-servico", JsonConvert.SerializeObject(invoiceRequest));
            return response;
        }
    }
}
