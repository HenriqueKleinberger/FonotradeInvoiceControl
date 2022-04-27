using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using FonotradeInvoiceControl.Exceptions;
using System.IO;
using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;

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

                    for (int row = RegisterInvoiceCollumns.FIRST_TABLE_ROW; row <= rows; row++) AddInvoiceByRow(worksheet, row);
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
                        TaxIdNumber = worksheet.Cells[row, RegisterInvoiceCollumns.TAX_ID_NUMBER].Value.ToString(),
                        Description = worksheet.Cells[row, RegisterInvoiceCollumns.DESCRIPTION].Value.ToString(),
                        Technician = worksheet.Cells[row, RegisterInvoiceCollumns.TECHNICIAN].Value.ToString(),
                        Value = decimal.Parse(worksheet.Cells[row, RegisterInvoiceCollumns.VALUE].Value.ToString())
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
            return worksheet.Cells[row, RegisterInvoiceCollumns.FEEDBACK]?.Value?.ToString() != RegisterInvoiceFeedback.REGISTERED
                && worksheet.Cells[row, RegisterInvoiceCollumns.ACTION].Value.ToString() == RegisterInvoiceActions.REGISTER;
        }
    }
}
