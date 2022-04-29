using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using FonotradeInvoiceControl.ExcelUtils;
using FonotradeInvoiceControl.Exceptions;
using FonotradeInvoiceControl.ExcelUtils.Parse;

namespace FonotradeInvoiceControl.BLL
{
    public class IssueInvoiceBLL : IIssueInvoiceBLL
    {
        private readonly ILogger<IssueInvoiceBLL> _logger;
        private readonly IVHSYSIssueInvoiceService _vhsysIssueInvoiceService;

        private Stream _stream;

        public IssueInvoiceBLL(ILogger<IssueInvoiceBLL> logger, IVHSYSIssueInvoiceService vhsysInvoiceService)
        {
            _logger = logger;
            _vhsysIssueInvoiceService = vhsysInvoiceService;
        }

        public List<InvoiceFeedbackDTO> IssueInvoicesFromFile(Stream stream)
        {
            _stream = stream;
            IEnumerable<InvoiceDTO> invoicesDto = GetInvoicesFromFile();
            List<InvoiceFeedbackDTO> invoicesFeedbacksDTO = IssueInvoices(invoicesDto);
            return invoicesFeedbacksDTO;
        }

        private IEnumerable<InvoiceDTO> GetInvoicesFromFile() => new ParseIssueFile(_stream).Parse();

        private List<InvoiceFeedbackDTO> IssueInvoices(IEnumerable<InvoiceDTO> invoicesDto)
        {
            List<InvoiceFeedbackDTO> invoicesFeedbacksDTO = new List<InvoiceFeedbackDTO>();
            foreach (InvoiceDTO invoice in invoicesDto)
            {
                try
                {
                    InvoiceFeedbackDTO invoiceFeedbackDTO = _vhsysIssueInvoiceService.IssueInvoice(invoice);
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
