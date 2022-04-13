using FonotradeInvoiceControl.DTO;
using System.Collections.Generic;
using System.IO;

namespace FonotradeInvoiceControl.BLL.Interfaces
{
    public interface IRegisterInvoiceBLL
    {
        public List<InvoiceFeedbackDTO> RegisterInvoicesFromFile(Stream stream);
    }
}
