using FonotradeInvoiceControl.DTO;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSRegisterInvoiceService
    {
        public InvoiceFeedbackDTO RegisterInvoice(InvoiceDTO invoice, ClientDTO clientDTO);
    }
}
