using Microsoft.AspNetCore.Http;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.ExcelUtils
{
    public static class ParseInvoiceFile
    {
        private const int FIRST_TABLE_ROW = 2;
        private const int BATCH = 1;
        private const int TAX_ID_NUMBER = 2;
        private const int DESCRIPTION = 3;
        private const int TECHNICIAN = 4;
        private const int VALUE = 5;

        public static IEnumerable<InvoiceDTO> Parse(IFormFile file)
        {
            List<InvoiceDTO> invoices = new List<InvoiceDTO>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = file.OpenReadStream();
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rows = worksheet.Dimension.Rows;
                
                for (int row = FIRST_TABLE_ROW; row <= rows; row++)
                {
                    InvoiceDTO invoice = GetInvoiceByRow(worksheet, row);
                    invoices.Add(invoice);
                }
            }
            return invoices;

            static InvoiceDTO GetInvoiceByRow(ExcelWorksheet worksheet, int row)
            {
                return new InvoiceDTO()
                {
                    Batch = Convert.ToInt32(worksheet.Cells[row, BATCH].Value.ToString()),
                    TaxIdNumber = worksheet.Cells[row, TAX_ID_NUMBER].Value.ToString(),
                    Description = worksheet.Cells[row, DESCRIPTION].Value.ToString(),
                    Technician = worksheet.Cells[row, TECHNICIAN].Value.ToString(),
                    Value = decimal.Parse(worksheet.Cells[row, VALUE].Value.ToString())
                };
            }
        }
    }
}
