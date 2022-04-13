using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using System.Collections.Generic;

using FonotradeInvoiceControl.Exceptions;
using FonotradeInvoiceControl.ExcelUtils.RegisterInvoice;
using System.IO;

namespace FonotradeInvoiceControl.BLL
{
    public class RegisterInvoiceBLL : IRegisterInvoiceBLL
    {
        private readonly ILogger<RegisterInvoiceBLL> _logger;
        private readonly IVHSYSClientService _vhsysClientService;
        private readonly IVHSYSInvoiceService _vhsysInvoiceService;

        private Stream _stream;

        public RegisterInvoiceBLL(ILogger<RegisterInvoiceBLL> logger, IVHSYSClientService vhsysClientService, IVHSYSInvoiceService vhsysInvoiceService)
        {
            _logger = logger;
            _vhsysClientService = vhsysClientService;
            _vhsysInvoiceService = vhsysInvoiceService;
        }


        public List<InvoiceFeedbackDTO> RegisterInvoicesFromFile(Stream stream)
        {
            _stream = stream;
            IEnumerable<InvoiceDTO> invoicesDto = GetInvoicesFromFile();
            List<InvoiceFeedbackDTO> invoicesFeedbacksDTO = RegisterInvoices(invoicesDto);
            return invoicesFeedbacksDTO;
        }

        private IEnumerable<InvoiceDTO> GetInvoicesFromFile() => new ParseInvoiceFile(_stream).Parse();

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
