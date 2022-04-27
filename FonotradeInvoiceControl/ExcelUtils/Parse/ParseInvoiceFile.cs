using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using FonotradeInvoiceControl.Exceptions;
using System.IO;
using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;

namespace FonotradeInvoiceControl.ExcelUtils.Parse
{
    public abstract class ParseInvoiceFile
    {
        private Stream _stream;
        private List<InvoiceDTO> _invoices;
        protected ExcelWorksheet _worksheet;

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
                    _worksheet = package.Workbook.Worksheets[0];

                    int rows = _worksheet.Dimension.Rows;

                    for (int row = RegisterInvoiceCollumns.FIRST_TABLE_ROW; row <= rows; row++) AddInvoiceByRow(row);
                }
            } catch (Exception ex)
            {
                throw new ParseInvoiceFileException($"Não foi possivel analisar a planilha Excel. {ex.Message}");
            }
            return _invoices;
        }

        private void AddInvoiceByRow(int row)
        {
            try
            {
                if (ShouldParseRow(row))
                {
                    InvoiceDTO invoice = ParseRow(row);

                    _invoices.Add(invoice);
                }
            } catch (Exception ex)
            {
                throw new ParseInvoiceFileException($"Erro planilha excel na linha: {row}. {ex.Message}");
            }
        }

        protected abstract InvoiceDTO ParseRow(int row);

        protected abstract bool ShouldParseRow(int row);
    }
}
