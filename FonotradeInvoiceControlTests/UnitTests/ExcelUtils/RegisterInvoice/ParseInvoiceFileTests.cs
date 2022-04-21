using FonotradeInvoiceControl.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using System.Linq;
using FonotradeInvoiceControl.ExcelUtils.RegisterInvoice;
using FonotradeInvoiceControl.Exceptions;

namespace FonotradeInvoiceControlTest.UnitTests.ExcelUtils.RegisterInvoice
{
    public class ParseInvoiceFileTests
    {
        private string _filePath;

        [Fact]
        public void WhenParseStreamWithOnePerson_ShouldReturnOneInvoice()
        {
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDto = Files.Constants.OnePersonToRegister.getInvoiceDTO();

            //Arrange
            FileStream fileStream = File.OpenRead(_filePath);

            //act
            List<InvoiceDTO> invoices = new ParseInvoiceFile(fileStream).Parse().ToList();

            //Assert.
            InvoiceDTO invoice = invoices[0];

            Assert.Single(invoices);
            Assert.Equal(expectedInvoiceDto.TaxIdNumber, invoice.TaxIdNumber);
            Assert.Equal(expectedInvoiceDto.Description, invoice.Description);
            Assert.Equal(expectedInvoiceDto.Technician, invoice.Technician);
            Assert.Equal(expectedInvoiceDto.Value, invoice.Value);
        }

        [Fact]
        public void WhenParseStreamWithInvalidInfo_ShouldThrowError()
        {
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/second_person_error_to_register.xlsx";

            //Arrange
            FileStream fileStream = File.OpenRead(_filePath);

            //act
            var exception = Assert.Throws<ParseInvoiceFileException>(() => new ParseInvoiceFile(fileStream).Parse());

            //Assert.
            Assert.Equal("Não foi possivel analisar a planilha Excel. Erro planilha excel na linha: 3. Object reference not set to an instance of an object.", exception.Message);
        }

        [Fact]
        public void WhenPersonIsAlreadyRegistered_ShouldNotReturnPerson()
        {
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_registered.xlsx";

            //Arrange
            FileStream fileStream = File.OpenRead(_filePath);

            //act
            List<InvoiceDTO> invoices = new ParseInvoiceFile(fileStream).Parse().ToList();

            //Assert.
            Assert.Empty(invoices);
        }
    }
}
