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

        [HttpPost("single-file")]
        public IEnumerable<InvoiceDTO> Get(IFormFile file)
        {
            _invoiceBLL.IssueInvoicesFromFile(file);
            return new List<InvoiceDTO>();
        }
    }
}
