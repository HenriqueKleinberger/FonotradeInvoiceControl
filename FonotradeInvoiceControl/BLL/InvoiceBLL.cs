using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.ExcelUtils;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using FonotradeInvoiceControl.Exceptions;

namespace FonotradeInvoiceControl.BLL
{
    public class InvoiceBLL : IInvoiceBLL
    {
        private readonly ILogger<InvoiceBLL> _logger;
        private readonly IVHSYSClientService _vhsysClientService;
        private readonly IVHSYSInvoiceService _vhsysInvoiceService;


        public InvoiceBLL(ILogger<InvoiceBLL> logger, IVHSYSClientService vhsysClientService, IVHSYSInvoiceService vhsysInvoiceService)
        {
            _logger = logger;
            _vhsysClientService = vhsysClientService;
            _vhsysInvoiceService = vhsysInvoiceService;
        }


        public List<InvoiceFeedbackDTO> RegisterInvoicesFromFile(IFormFile file)
        {
            IEnumerable<InvoiceDTO> invoicesDto = ParseInvoiceFile.Parse(file);
            List<InvoiceFeedbackDTO> invoicesFeedbacksDTO = RegisterInvoices(invoicesDto);
            return invoicesFeedbacksDTO;
        }

        private List<InvoiceFeedbackDTO> RegisterInvoices(IEnumerable<InvoiceDTO> invoicesDto)
        {
            List<InvoiceFeedbackDTO> invoicesFeedbacksDTO = new List<InvoiceFeedbackDTO>();
            foreach (InvoiceDTO invoice in invoicesDto)
            {
                try
                {
                    ClientDTO clientDTO = _vhsysClientService.getClientByCnpj(invoice.TaxIdNumber);
                    InvoiceFeedbackDTO invoiceFeedbackDTO = _vhsysInvoiceService.RegisterInvoice(invoice, clientDTO);
                    invoicesFeedbacksDTO.Add(invoiceFeedbackDTO);
                }
                catch (VHSYSServiceException exception)
                {
                    invoicesFeedbacksDTO.Add(new InvoiceFeedbackDTO() { Feedback = exception.Message, InvoiceDTO = invoice });
                }

            }

            return invoicesFeedbacksDTO;
        }
    }
}
