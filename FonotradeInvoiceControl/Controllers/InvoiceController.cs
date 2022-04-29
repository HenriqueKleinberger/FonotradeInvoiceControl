using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using System.Collections.Generic;
using System.IO;
using System;
using FonotradeInvoiceControl.ExcelUtils.GenerateFeedback;

namespace FonotradeInvoiceControl.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {

        private readonly ILogger<InvoiceController> _logger;
        private readonly IRegisterInvoiceBLL _registerInvoiceBLL;
        private readonly IIssueInvoiceBLL _issueInvoiceBLL;

        public InvoiceController(
            ILogger<InvoiceController> logger,
            IRegisterInvoiceBLL invoiceBLL,
            IIssueInvoiceBLL issueInvoiceBLL)
        {
            _logger = logger;
            _registerInvoiceBLL = invoiceBLL;
            _issueInvoiceBLL = issueInvoiceBLL;
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
            Stream stream = file.OpenReadStream();
            List<InvoiceFeedbackDTO> invoicesFeedbackDTO = _registerInvoiceBLL.RegisterInvoicesFromFile(stream);
            var responseStream = new RegisterFeedbackFileGenerator(stream, invoicesFeedbackDTO).Generate();
            return base.File(responseStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", GetFeedbackFileName(file));
        }

        private string GetFeedbackFileName(IFormFile file)
        {
            const string FEEDBACK_FILE_STRING = "- ARQUIVO DE RETORNO";

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string rootFileName = fileName.Split(FEEDBACK_FILE_STRING)[0];

            return $"{rootFileName} {FEEDBACK_FILE_STRING} - {DateTime.Now}.xlsx";
        }

        /// <summary>
        /// Emitir notas fiscais na VHSYS
        /// </summary>
        /// <remarks>
        /// Envio de planilha de notas fiscais para serem emitidas no site da VHSYS, após o envio será criado um arquivo de retorno 
        /// com o status da integração ao lado da linha da nota.
        ///     
        /// </remarks>
        /// <param name="file">Arquivo com os dados das notas fiscais que serão enviadas para a VHSYS</param>
        /// <response code="200">Retorno de sucesso com o arquivo excel de feedback da VHSYS</response>
        [HttpPost("issue/VHSYS")]
        [Produces("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        public IActionResult IssueInvoice(IFormFile file)
        {
            Stream stream = file.OpenReadStream();
            List<InvoiceFeedbackDTO> invoicesFeedbackDTO = _issueInvoiceBLL.IssueInvoicesFromFile(stream);
            var responseStream = new IssueFeedbackFileGenerator(stream, invoicesFeedbackDTO).Generate();
            return base.File(responseStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", GetFeedbackFileName(file));
        }
    }
}
