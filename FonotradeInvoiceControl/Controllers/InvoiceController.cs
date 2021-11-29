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
using FonotradeInvoiceControl.ExcelUtils.RegisterInvoice;

namespace FonotradeInvoiceControl.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceBLL _invoiceBLL;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceBLL invoiceBLL)
        {
            _logger = logger;
            _invoiceBLL = invoiceBLL;
        }

        /// <summary>
        /// Registrar notas fiscais na VHSYS
        /// </summary>
        /// <remarks>
        /// Envio de planilha de notas fiscais para serem cadastradas no site da VHSYS, após o envio será criado um arquivo de retorno 
        /// com o status da integração ao lado da linha da nota.
        ///     
        /// </remarks>
        /// <param name="file">Arquivo com os dados das notas fiscais que serão enviadas para a VHSYS</param>
        /// <response code="200">Retorno de sucesso com o arquivo excel de feedback da VHSYS</response>
        [HttpPost("register/VHSYS")]
        [Produces("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
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
