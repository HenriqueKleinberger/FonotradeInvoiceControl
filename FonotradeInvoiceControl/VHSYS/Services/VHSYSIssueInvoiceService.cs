using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using RestSharp;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using FonotradeInvoiceControl.Mappers;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSIssueInvoiceService : BaseVHSYSService, IVHSYSIssueInvoiceService
    {
        public VHSYSIssueInvoiceService(IConfiguration config, IVHSYSService vhsysService) : base(config, vhsysService)
        {
        }

        public InvoiceFeedbackDTO IssueInvoice(InvoiceDTO invoice)
        {
            IRestResponse response = _vhsysService.Post($"notas-servico/{invoice.ServiceId}/emitir");
            VHSYSIssueInvoiceResponse issueInvoiceResponse = ParseResponse<VHSYSIssueInvoiceResponse>(response);

            return issueInvoiceResponse.data.ToInvoiceFeedbackDTO(invoice);
        }
    }
}
