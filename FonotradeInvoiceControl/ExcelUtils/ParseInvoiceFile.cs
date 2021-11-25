using Microsoft.AspNetCore.Http;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using FonotradeInvoiceControl.Constants;

namespace FonotradeInvoiceControl.ExcelUtils
{
    public class ParseInvoiceFile
    {
        private const int FIRST_TABLE_ROW = 2;
        private const int BATCH = 1;
        private const int TAX_ID_NUMBER = 4;
        private const int DESCRIPTION = 5;
        private const int TECHNICIAN = 6;
        private const int VALUE = 7;
        private const int FEEDBACK = 8;

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
                
                for (int row = FIRST_TABLE_ROW; row <= rows; row++) AddInvoiceByRow(worksheet, row);
            }
            return _invoices;

            
        }

        private void AddInvoiceByRow(ExcelWorksheet worksheet, int row)
        {
            if (ShouldParseRow(worksheet, row))
            {
                InvoiceDTO invoice = new InvoiceDTO()
                {
                    TaxIdNumber = worksheet.Cells[row, TAX_ID_NUMBER].Value.ToString(),
                    Description = worksheet.Cells[row, DESCRIPTION].Value.ToString(),
                    Technician = worksheet.Cells[row, TECHNICIAN].Value.ToString(),
                    Value = decimal.Parse(worksheet.Cells[row, VALUE].Value.ToString())
                };

                _invoices.Add(invoice);
            }
        }

        private bool ShouldParseRow(ExcelWorksheet worksheet, int row)
        {
            return worksheet.Cells[row, FEEDBACK].Value == null || worksheet.Cells[row, FEEDBACK].Value.ToString() != InvoiceFeedback.REGISTERED;
        }
    }
}
