using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
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
                Feedback = RegisterInvoiceFeedback.REGISTERED,
                RegisteredId = vhsysInvoice.RegisterId,
                Id = vhsysInvoice.ServiceId,
                InvoiceDTO = invoiceDTO
            };

            return invoiceFeedbackDTO;
        }
    }
}
