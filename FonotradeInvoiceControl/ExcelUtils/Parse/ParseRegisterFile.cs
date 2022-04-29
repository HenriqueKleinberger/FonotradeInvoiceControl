using System.IO;
using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.DTO;

namespace FonotradeInvoiceControl.ExcelUtils.Parse
{
    public class ParseRegisterFile : ParseInvoiceFile
    {
        public ParseRegisterFile(Stream stream) : base(stream)
        {
        }

        protected override bool ShouldParseRow(int row)
        {
            bool isAlreadyRegistered = _worksheet.Cells[row, RegisterInvoiceCollumns.FEEDBACK]?.Value?.ToString() == RegisterInvoiceFeedback.REGISTERED;
            bool needsToBeRegistered = _worksheet.Cells[row, RegisterInvoiceCollumns.ACTION]?.Value?.ToString() == RegisterInvoiceActions.REGISTER;
            return !isAlreadyRegistered && needsToBeRegistered;
        }

        protected override InvoiceDTO ParseRow(int row)
        {
            return new InvoiceDTO()
            {
                TaxIdNumber = _worksheet.Cells[row, RegisterInvoiceCollumns.TAX_ID_NUMBER]?.Value?.ToString(),
                Description = _worksheet.Cells[row, RegisterInvoiceCollumns.DESCRIPTION]?.Value?.ToString(),
                Technician = _worksheet.Cells[row, RegisterInvoiceCollumns.TECHNICIAN]?.Value?.ToString(),
                Value = decimal.Parse(_worksheet.Cells[row, RegisterInvoiceCollumns.VALUE]?.Value?.ToString())
            };
        }
    }
}
