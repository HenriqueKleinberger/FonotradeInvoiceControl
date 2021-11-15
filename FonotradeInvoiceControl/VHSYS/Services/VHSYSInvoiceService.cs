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

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSInvoiceService : IVHSYSInvoiceService
    {
        private readonly IVHSYSService _vhsysService;
        private readonly IConfiguration _config;

        public VHSYSInvoiceService(IVHSYSService vhsysService, IConfiguration config)
        {
            _vhsysService = vhsysService;
            _config = config;
        }

        public VHSYSRegisterInvoiceResponse RegisterInvoice(InvoiceDTO invoice, VHSYSClient vhsysClient)
        {
            int environment = _config.GetValue<int>("VHSYS:ApiConfig:environment");
            VHSYSRegisterInvoiceRequest invoiceRequest = new VHSYSRegisterInvoiceRequest(invoice, vhsysClient, environment);
            IRestResponse response = _vhsysService.Post("notas-servico", JsonConvert.SerializeObject(invoiceRequest));
            VHSYSRegisterInvoiceResponse registerInvoiceResponse = JsonConvert.DeserializeObject<VHSYSRegisterInvoiceResponse>(response.Content);
            return registerInvoiceResponse;
        }
    }
}
