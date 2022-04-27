using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.DTO;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace FonotradeInvoiceControl.ExcelUtils.GenerateFeedback
{
    public abstract class InvoiceFeedbackFileGenerator
    {
        private Stream _stream;
        protected ExcelPackage _package;
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
                int rowEnd = _package.Workbook.Worksheets[0].Dimension.End.Row;

                _invoicesFeedback.ForEach(invoiceFeedback =>
                {
                    for (int row = 1; row <= rowEnd; row++)
                    {
                        if (FeedbackIsForThisLine(invoiceFeedback, row))
                        {
                            GenerateFeedback(row, invoiceFeedback);
                            break;
                        }
                    }
                });

                return GetGeneratedPackage();
            }
        }

        protected abstract void GenerateFeedback(int row, InvoiceFeedbackDTO invoiceFeedback);

        private bool FeedbackIsForThisLine(InvoiceFeedbackDTO invoiceFeedback, int row)
        {
            bool isTheSamePerson = _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.TAX_ID_NUMBER].Value.ToString() == invoiceFeedback.InvoiceDTO.TaxIdNumber;
            bool isTheSameTechnician = _package.Workbook.Worksheets[0].Cells[row, RegisterInvoiceCollumns.TECHNICIAN].Value.ToString() == invoiceFeedback.InvoiceDTO.Technician;
            return isTheSamePerson && isTheSameTechnician;
        }

        private Stream GetGeneratedPackage()
        {
            _package.Save();
            _package.Stream.Position = 0;
            return _package.Stream;
        }
    }
}
