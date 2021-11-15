using FonotradeInvoiceControl.DTO;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSInvoiceService
    {
        public InvoiceFeedbackDTO RegisterInvoice(InvoiceDTO invoice, ClientDTO clientDTO);
    }
}
