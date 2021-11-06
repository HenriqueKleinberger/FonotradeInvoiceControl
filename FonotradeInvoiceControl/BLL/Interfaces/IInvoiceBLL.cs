using Microsoft.AspNetCore.Http;

namespace FonotradeInvoiceControl.BLL.Interfaces
{
    public interface IInvoiceBLL
    {
        public void IssueInvoicesFromFile(IFormFile file);
    }
}
