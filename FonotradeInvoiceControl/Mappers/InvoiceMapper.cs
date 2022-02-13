using FonotradeInvoiceControl.Constants;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;

namespace FonotradeInvoiceControl.Mappers
{
    public static class InvoiceMapper
    {

        public static InvoiceFeedbackDTO ToInvoiceFeedbackDTO(this VHSYSInvoice vhsysInvoice, InvoiceDTO invoiceDTO)
        {
            InvoiceFeedbackDTO invoiceFeedbackDTO = new InvoiceFeedbackDTO()
            {
                Feedback = InvoiceFeedback.REGISTERED,
                Id = vhsysInvoice.RegisterId,
                InvoiceDTO = invoiceDTO
            };

            return invoiceFeedbackDTO;
        }
    }
}
