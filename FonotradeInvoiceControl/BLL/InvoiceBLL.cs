using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.ExcelUtils;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FonotradeInvoiceControl.BLL
{
    public class InvoiceBLL : IInvoiceBLL
    {
        private readonly IVHSYSClientService _vhsysClientService;

        private readonly ILogger<InvoiceBLL> _logger;

        public InvoiceBLL(ILogger<InvoiceBLL> logger, IVHSYSClientService vhsysClientService)
        {
            _logger = logger;
            _vhsysClientService = vhsysClientService;
        }


        public void IssueInvoicesFromFile(IFormFile file)
        {
            IEnumerable<InvoiceDTO> invoicesDto = ParseInvoiceFile.Parse(file);
            foreach (InvoiceDTO invoice in invoicesDto)
            {
                VHSYSClient vHSYSClient = _vhsysClientService.getClientByCnpj(invoice.TaxIdNumber);
            }
        }
    }
}
