using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace FonotradeInvoiceControl.ExcelUtils.RegisterInvoice
{
    public class InvoiceFeedbackFileGenerator
    {
        private Stream _stream;
        private ExcelPackage _package;
        private List<InvoiceFeedbackDTO> _invoicesFeedback;

        public InvoiceFeedbackFileGenerator(Stream stream, List<InvoiceFeedbackDTO> invoicesFeedback)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _stream = stream;
            _invoicesFeedback = invoicesFeedback;
        }

        public Stream Generate()
        {
            using (_package = new ExcelPackage(_stream))
            {
                int rows = _package.Workbook.Worksheets[0].Dimension.Rows;

                //int rowStart = _package.Workbook.Worksheets[0].Dimension.Start.Row;
                int rowEnd = _package.Workbook.Worksheets[0].Dimension.End.Row;

                // string cellRange = rowStart.ToString() + ":" + rowEnd.ToString();
                
                //FillHeaders();

                _invoicesFeedback.ForEach(invoiceFeedback =>
                {
                    for (int row = 1; row <= rowEnd; row++)
                    {
                        if (
                            _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.TAX_ID_NUMBER].Value.ToString() == invoiceFeedback.InvoiceDTO.TaxIdNumber
                            && _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.TECHNICIAN].Value.ToString() == invoiceFeedback.InvoiceDTO.Technician
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
                _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.REGISTERED_ID].Value = invoiceFeedback.RegisteredId.ToString();
                _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.SERVICE_ID].Value = invoiceFeedback.Id.ToString();
                _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.FEEDBACK].Value = invoiceFeedback.Feedback;
            }
        }

        //private void FillHeaders()
        //{
        //    _package.Workbook.Worksheets[0].Cells[1, RegisterInvoiceExcelFile.SERVICE_ID].Value = "ID DO SERVIÇO";
        //    _package.Workbook.Worksheets[0].Cells[1, RegisterInvoiceExcelFile.REGISTERED_ID].Value = "ID DO REGISTRO";
        //    _package.Workbook.Worksheets[0].Cells[1, RegisterInvoiceExcelFile.FEEDBACK].Value = "STATUS ATUAL";
        //}

        private Stream GetGeneratedPackage()
        {
            _package.Save();
            _package.Stream.Position = 0;
            return _package.Stream;
        }
    }
}
