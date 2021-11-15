using Microsoft.AspNetCore.Http;

namespace FonotradeInvoiceControl.BLL.Interfaces
{
    public interface IInvoiceBLL
    {
        public void RegisterInvoicesFromFile(IFormFile file);
    }
}
