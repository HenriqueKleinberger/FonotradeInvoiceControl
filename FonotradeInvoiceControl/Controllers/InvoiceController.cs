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
using System.IO;
using System;

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
            return base.File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", GetFeedbackFileName(file));
        }

        private string GetFeedbackFileName(IFormFile file)
        {
            const string FEEDBACK_FILE_STRING = "- ARQUIVO DE RETORNO";

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string rootFileName = fileName.Split(FEEDBACK_FILE_STRING)[0];

            return $"{rootFileName} {FEEDBACK_FILE_STRING} - {DateTime.Now}.xlsx";
        }
    }
}
