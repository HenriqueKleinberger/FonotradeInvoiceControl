using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using FonotradeInvoiceControl.Constants;
using FonotradeInvoiceControl.Exceptions;
using System.IO;

namespace FonotradeInvoiceControl.ExcelUtils.RegisterInvoice
{
    public class ParseInvoiceFile
    {
        private Stream _stream;
        private List<InvoiceDTO> _invoices;

        public ParseInvoiceFile(Stream stream)
        {
            _stream = stream;
            _invoices = new List<InvoiceDTO>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public IEnumerable<InvoiceDTO> Parse()
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(_stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rows = worksheet.Dimension.Rows;

                    for (int row = RegisterInvoiceExcelFile.FIRST_TABLE_ROW; row <= rows; row++) AddInvoiceByRow(worksheet, row);
                }
            } catch (Exception ex)
            {
                throw new ParseInvoiceFileException($"Não foi possivel analisar a planilha Excel. {ex.Message}");
            }
            return _invoices;
        }

        private void AddInvoiceByRow(ExcelWorksheet worksheet, int row)
        {
            try
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
            } catch (Exception ex)
            {
                throw new ParseInvoiceFileException($"Erro planilha excel na linha: {row}. {ex.Message}");
            }
        }
        

        private bool ShouldParseRow(ExcelWorksheet worksheet, int row)
        {
            return worksheet.Cells[row, RegisterInvoiceExcelFile.FEEDBACK].Value == null || worksheet.Cells[row, RegisterInvoiceExcelFile.FEEDBACK].Value.ToString() != InvoiceFeedback.REGISTERED;
        }
    }
}
