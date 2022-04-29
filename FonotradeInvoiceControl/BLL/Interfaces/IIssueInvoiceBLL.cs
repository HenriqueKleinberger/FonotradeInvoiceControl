using FonotradeInvoiceControl.DTO;
using System.Collections.Generic;
using System.IO;

namespace FonotradeInvoiceControl.BLL.Interfaces
{
    public interface IIssueInvoiceBLL
    {
        public List<InvoiceFeedbackDTO> IssueInvoicesFromFile(Stream stream);
    }
}
