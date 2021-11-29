using Microsoft.AspNetCore.Http;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using FonotradeInvoiceControl.Constants;

namespace FonotradeInvoiceControl.ExcelUtils.RegisterInvoice
{
    public class ParseInvoiceFile
    {
        private IFormFile _file;
        private List<InvoiceDTO> _invoices;

        public ParseInvoiceFile(IFormFile file)
        {
            _file = file;
            _invoices = new List<InvoiceDTO>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public IEnumerable<InvoiceDTO> Parse()
        {
            var stream = _file.OpenReadStream();
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rows = worksheet.Dimension.Rows;
                
                for (int row = RegisterInvoiceExcelFile.FIRST_TABLE_ROW; row <= rows; row++) AddInvoiceByRow(worksheet, row);
            }
            return _invoices;

            
        }

        private void AddInvoiceByRow(ExcelWorksheet worksheet, int row)
        {
            if (ShouldParseRow(worksheet, row))
            {
                InvoiceDTO invoice = new InvoiceDTO()
                {
                    TaxIdNumber = worksheet.Cells[row, RegisterInvoiceExcelFile.TAX_ID_NUMBER].Value.ToString(),
                    Description = worksheet.Cells[row, RegisterInvoiceExcelFile.DESCRIPTION].Value.ToString(),
                    Technician = worksheet.Cells[row, RegisterInvoiceExcelFile.TECHNICIAN].Value.ToString(),
                    Value = decimal.Parse(worksheet.Cells[row, RegisterInvoiceExcelFile.VALUE].Value.ToString())
                };

                _invoices.Add(invoice);
            }
        }

        private bool ShouldParseRow(ExcelWorksheet worksheet, int row)
        {
            return worksheet.Cells[row, RegisterInvoiceExcelFile.FEEDBACK].Value == null || worksheet.Cells[row, RegisterInvoiceExcelFile.FEEDBACK].Value.ToString() != InvoiceFeedback.REGISTERED;
        }
    }
}
