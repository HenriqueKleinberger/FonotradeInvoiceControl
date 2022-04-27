using System.IO;
using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.Constants.Excel.IssueInvoice;
using FonotradeInvoiceControl.DTO;
using System;

namespace FonotradeInvoiceControl.ExcelUtils.Parse
{
    public class ParseIssueFile : ParseInvoiceFile
    {
        public ParseIssueFile(Stream stream) : base(stream)
        {
        }

        protected override bool ShouldParseRow(int row)
        {
            bool isValidInvoiceId = _worksheet.Cells[row, RegisterInvoiceCollumns.SERVICE_ID]?.Value?.ToString() != null;
            bool isAlreadyIssued = _worksheet.Cells[row, RegisterInvoiceCollumns.FEEDBACK]?.Value?.ToString() == IssueInvoiceFeedback.ISSUED;
            bool needsToBeIssued = _worksheet.Cells[row, RegisterInvoiceCollumns.ACTION].Value.ToString() == IssueInvoiceActions.ISSUE;
            return !isAlreadyIssued && needsToBeIssued && isValidInvoiceId;
        }

        protected override InvoiceDTO ParseRow(int row)
        {
            return new InvoiceDTO()
            {
                TaxIdNumber = _worksheet.Cells[row, RegisterInvoiceCollumns.TAX_ID_NUMBER].Value.ToString(),
                Description = _worksheet.Cells[row, RegisterInvoiceCollumns.DESCRIPTION].Value.ToString(),
                Technician = _worksheet.Cells[row, RegisterInvoiceCollumns.TECHNICIAN].Value.ToString(),
                Value = decimal.Parse(_worksheet.Cells[row, RegisterInvoiceCollumns.VALUE].Value.ToString()),
                RegisteredId = Int32.Parse(_worksheet.Cells[row, RegisterInvoiceCollumns.REGISTERED_ID].Value.ToString()),
                ServiceId = Int32.Parse(_worksheet.Cells[row, RegisterInvoiceCollumns.SERVICE_ID].Value.ToString())
            };
        }
    }
}
