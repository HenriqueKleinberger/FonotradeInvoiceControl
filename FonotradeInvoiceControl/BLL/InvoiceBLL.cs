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
        private readonly ILogger<InvoiceBLL> _logger;
        private readonly IVHSYSClientService _vhsysClientService;
        private readonly IVHSYSInvoiceService _vhsysInvoiceService;


        public InvoiceBLL(ILogger<InvoiceBLL> logger, IVHSYSClientService vhsysClientService, IVHSYSInvoiceService vhsysInvoiceService)
        {
            _logger = logger;
            _vhsysClientService = vhsysClientService;
            _vhsysInvoiceService = vhsysInvoiceService;
        }


        public void RegisterInvoicesFromFile(IFormFile file)
        {
            IEnumerable<InvoiceDTO> invoicesDto = ParseInvoiceFile.Parse(file);
            foreach (InvoiceDTO invoice in invoicesDto)
            {
                VHSYSClient vHSYSClient = _vhsysClientService.getClientByCnpj(invoice.TaxIdNumber);
                _vhsysInvoiceService.RegisterInvoice(invoice, vHSYSClient);

            }
        }
    }
}
