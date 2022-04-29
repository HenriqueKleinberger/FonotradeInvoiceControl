using FonotradeInvoiceControl.DTO;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSIssueInvoiceService
    {
        public InvoiceFeedbackDTO IssueInvoice(InvoiceDTO invoice);
    }
}
