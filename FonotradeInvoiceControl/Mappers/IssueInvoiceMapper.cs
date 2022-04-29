using FonotradeInvoiceControl.Constants.Excel.IssueInvoice;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;
using System;

namespace FonotradeInvoiceControl.Mappers
{
    public static class IssueInvoiceMapper
    {
        public static InvoiceFeedbackDTO ToInvoiceFeedbackDTO(
            this VHSYSIssueInvoice issueVHSYSInvoice,
            InvoiceDTO invoiceDTO
        )
        {
            InvoiceFeedbackDTO invoiceFeedbackDTO = new InvoiceFeedbackDTO()
            {
                Feedback = IssueInvoiceFeedback.ISSUED,
                InvoiceNumber = Int32.Parse(issueVHSYSInvoice.InvoiceNumber),
                InvoiceDTO = invoiceDTO
            };

            return invoiceFeedbackDTO;
        }
    }
}
