using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;

namespace FonotradeInvoiceControl.Mappers
{
    public static class RegisterInvoiceMapper
    {

        public static InvoiceFeedbackDTO ToInvoiceFeedbackDTO(this VHSYSRegisterInvoice vhsysInvoice, InvoiceDTO invoiceDTO)
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
