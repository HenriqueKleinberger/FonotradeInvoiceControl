using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models.Requests;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using FonotradeInvoiceControl.Mappers;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSRegisterInvoiceService : BaseVHSYSService, IVHSYSRegisterInvoiceService
    {
        public VHSYSRegisterInvoiceService(IConfiguration config, IVHSYSService vhsysService) : base(config, vhsysService)
        {
        }

        public InvoiceFeedbackDTO RegisterInvoice(InvoiceDTO invoice, ClientDTO clientDTO)
        {
            IRestResponse response = Register(invoice, clientDTO);
            VHSYSRegisterInvoiceResponse registerInvoiceResponse = ParseResponse<VHSYSRegisterInvoiceResponse>(response);

            return registerInvoiceResponse.data.ToInvoiceFeedbackDTO(invoice);
        }

        private IRestResponse Register(InvoiceDTO invoice, ClientDTO clientDTO)
        {
            int environment = _config.GetValue<int>("VHSYS:ApiConfig:environment");
            VHSYSRegisterInvoiceRequest invoiceRequest = new VHSYSRegisterInvoiceRequest(invoice, clientDTO, environment);
            IRestResponse response = _vhsysService.Post("notas-servico", JsonConvert.SerializeObject(invoiceRequest));
            return response;
        }
    }
}
