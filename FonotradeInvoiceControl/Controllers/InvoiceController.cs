using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.ExcelUtils;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FonotradeInvoiceControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceBLL _invoiceBLL;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceBLL invoiceBLL)
        {
            _logger = logger;
            _invoiceBLL = invoiceBLL;
        }

        [HttpPost("register-invoice")]
        public IActionResult RegisterInvoice(IFormFile file)
        {
            List<InvoiceFeedbackDTO> invoicesFeedbackDTO = _invoiceBLL.RegisterInvoicesFromFile(file);
            var stream = new InvoiceFeedbackFileGenerator(file, invoicesFeedbackDTO).Generate();
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", file.Name);
        }
    }
}
