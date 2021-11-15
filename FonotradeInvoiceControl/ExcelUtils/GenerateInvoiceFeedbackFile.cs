using Microsoft.AspNetCore.Http;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FonotradeInvoiceControl.ExcelUtils
{
    public class InvoiceFeedbackFileGenerator
    {
        private const int FIRST_TABLE_ROW = 2;
        private const int FEEDBACK_COLUMN = 8;
        private IFormFile _file;
        private ExcelPackage _package;
        private List<InvoiceFeedbackDTO> _invoicesFeedback;
        private IFormFile file;

        public InvoiceFeedbackFileGenerator(IFormFile file)
        {
            this.file = file;
        }

        public InvoiceFeedbackFileGenerator(IFormFile file, List<InvoiceFeedbackDTO> invoicesFeedback)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _file = file;
            _invoicesFeedback = invoicesFeedback;
        }

        public Stream Generate()
        {
            var stream = _file.OpenReadStream();

            using (_package = new ExcelPackage(stream))
            {
                int rows = _package.Workbook.Worksheets[0].Dimension.Rows;

                    int rowStart = _package.Workbook.Worksheets[0].Dimension.Start.Row;
                    int rowEnd = _package.Workbook.Worksheets[0].Dimension.End.Row;

                    string cellRange = rowStart.ToString() + ":" + rowEnd.ToString();
                _invoicesFeedback.ForEach(invoiceFeedback => {

                    var searchCell = from cell in _package.Workbook.Worksheets[0].Cells[cellRange] //you can define your own range of cells for lookup
                                     where cell.Value.ToString() == invoiceFeedback.InvoiceDTO.TaxIdNumber
                                     select cell.Start.Row;

                    int rowNum = searchCell.First();
                    GenerateFeedback(rowNum);

                });

                return GetGeneratedPackage();
            }


            void GenerateFeedback(int row)
            {
                _package.Workbook.Worksheets[0].Cells[row, FEEDBACK_COLUMN].Value = "2";
            }
        }

        private Stream GetGeneratedPackage()
        {
            _package.Save();
            _package.Stream.Position = 0;
            return _package.Stream;
        }
    }
}
