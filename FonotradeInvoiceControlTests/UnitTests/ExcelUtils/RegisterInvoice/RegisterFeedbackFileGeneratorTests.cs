using FonotradeInvoiceControl.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using FonotradeInvoiceControlTest.Builder.DTO;
using OfficeOpenXml;
using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;
using FonotradeInvoiceControl.ExcelUtils.GenerateFeedback;

namespace FonotradeInvoiceControlTest.UnitTests.ExcelUtils.RegisterInvoice
{
    public class RegisterFeedbackFileGeneratorTests
    {
        private string _filePath;

        [Fact]
        public void WhenTaxIdNumberAndTechnicianAreEqual_ShouldReturnFeedback()
        {
            //Arrange
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDto = Files.Constants.OnePersonToRegister.getInvoiceDTO();
            FileStream fileStream = File.OpenRead(_filePath);

            List<InvoiceFeedbackDTO> invoiceFeedbackDTOs = new List<InvoiceFeedbackDTO>()
            {
                new InvoiceFeedbackDTOBuilder().WithInvoiceDTO(expectedInvoiceDto).Build()
            };

            //act
            Stream stream = new RegisterFeedbackFileGenerator(fileStream, invoiceFeedbackDTOs).Generate();

            //Assert.
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                Assert.Equal(invoiceFeedbackDTOs[0].RegisteredId.ToString(), worksheet.Cells[2, RegisterInvoiceCollumns.REGISTERED_ID].Value.ToString());
                Assert.Equal(invoiceFeedbackDTOs[0].Id.ToString(), worksheet.Cells[2, RegisterInvoiceCollumns.SERVICE_ID].Value.ToString());
                Assert.Equal(invoiceFeedbackDTOs[0].Feedback.ToString(), worksheet.Cells[2, RegisterInvoiceCollumns.FEEDBACK].Value.ToString());
            }
        }

        [Fact]
        public void WhenTechnicianIsDifferent_ShouldNotReturnFeedback()
        {
            //Arrange
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDto = Files.Constants.OnePersonToRegister.getInvoiceDTO();
            expectedInvoiceDto.Technician = expectedInvoiceDto.Technician + " different";
            FileStream fileStream = File.OpenRead(_filePath);

            List<InvoiceFeedbackDTO> invoiceFeedbackDTOs = new List<InvoiceFeedbackDTO>()
            {
                new InvoiceFeedbackDTOBuilder().WithInvoiceDTO(expectedInvoiceDto).Build()
            };

            //act
            Stream stream = new RegisterFeedbackFileGenerator(fileStream, invoiceFeedbackDTOs).Generate();

            //Assert.
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                Assert.Null(worksheet.Cells[2, RegisterInvoiceCollumns.REGISTERED_ID].Value);
                Assert.Null(worksheet.Cells[2, RegisterInvoiceCollumns.FEEDBACK].Value);
            }
        }

        [Fact]
        public void WhenTaxNumberIdIsDifferent_ShouldNotReturnFeedback()
        {
            //Arrange
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDto = Files.Constants.OnePersonToRegister.getInvoiceDTO();
            expectedInvoiceDto.Technician = expectedInvoiceDto.TaxIdNumber + " different";
            FileStream fileStream = File.OpenRead(_filePath);

            List<InvoiceFeedbackDTO> invoiceFeedbackDTOs = new List<InvoiceFeedbackDTO>()
            {
                new InvoiceFeedbackDTOBuilder().WithInvoiceDTO(expectedInvoiceDto).Build()
            };

            //act
            Stream stream = new RegisterFeedbackFileGenerator(fileStream, invoiceFeedbackDTOs).Generate();

            //Assert.
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                Assert.Null(worksheet.Cells[2, RegisterInvoiceCollumns.REGISTERED_ID].Value);
                Assert.Null(worksheet.Cells[2, RegisterInvoiceCollumns.FEEDBACK].Value);
            }
        }
    }
}
