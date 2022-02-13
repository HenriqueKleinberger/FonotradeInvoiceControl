using Microsoft.AspNetCore.Http;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FonotradeInvoiceControl.ExcelUtils.RegisterInvoice
{
    public class InvoiceFeedbackFileGenerator
    {
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
                    for(int row = 1; row <= rowEnd; row++)
                    {
                        if(
                            _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceExcelFile.TAX_ID_NUMBER].Value.ToString() == invoiceFeedback.InvoiceDTO.TaxIdNumber
                            && _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceExcelFile.TECHNICIAN].Value.ToString() == invoiceFeedback.InvoiceDTO.Technician
                           )
                        {
                            GenerateFeedback(row, invoiceFeedback);
                            break;
                        }
                    }
                });

                return GetGeneratedPackage();
            }


            void GenerateFeedback(int row, InvoiceFeedbackDTO invoiceFeedback)
            {
                _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceExcelFile.REGISTERED_ID].Value = invoiceFeedback.Id.ToString();
                _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceExcelFile.FEEDBACK].Value = invoiceFeedback.Feedback;
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
