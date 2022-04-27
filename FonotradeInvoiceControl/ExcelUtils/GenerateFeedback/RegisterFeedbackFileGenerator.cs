using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace FonotradeInvoiceControl.ExcelUtils.GenerateFeedback
{
    public class RegisterFeedbackFileGenerator : InvoiceFeedbackFileGenerator
    {
        public RegisterFeedbackFileGenerator(Stream stream, List<InvoiceFeedbackDTO> invoicesFeedback) : base(stream, invoicesFeedback)
        {

        }

        protected override void GenerateFeedback(int row, InvoiceFeedbackDTO invoiceFeedback)
        {
            _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.REGISTERED_ID].Value = invoiceFeedback.RegisteredId.ToString();
            _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.SERVICE_ID].Value = invoiceFeedback.Id.ToString();
            _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.FEEDBACK].Value = invoiceFeedback.Feedback;
        }
    }
}
