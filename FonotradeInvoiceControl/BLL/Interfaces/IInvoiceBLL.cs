using FonotradeInvoiceControl.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.BLL.Interfaces
{
    public interface IInvoiceBLL
    {
        public List<InvoiceFeedbackDTO> RegisterInvoicesFromFile(IFormFile file);
    }
}
