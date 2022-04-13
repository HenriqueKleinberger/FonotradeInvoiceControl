using FonotradeInvoiceControl.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using System.Linq;
using FonotradeInvoiceControl.ExcelUtils.RegisterInvoice;
using FonotradeInvoiceControl.Exceptions;
using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using FonotradeInvoiceControl.BLL;
using Moq;
using FonotradeInvoiceControl.Constants;
using FonotradeInvoiceControlTest.Builder.DTO;

namespace FonotradeInvoiceControlTest.UnitTests.BLL.RegisterInvoice
{
    public class RegisterInvoiceBLLTests
    {
        private string _filePath;

        private readonly Mock<ILogger<RegisterInvoiceBLL>> _loggerMock;
        private readonly Mock<IVHSYSClientService> _vhsysClientServiceMock;
        private readonly Mock<IVHSYSInvoiceService> _vhsysInvoiceServiceMock;
        private RegisterInvoiceBLL _registerInvoiceBLL;

        public RegisterInvoiceBLLTests()
        {
            _loggerMock = new Mock<ILogger<RegisterInvoiceBLL>>();
            _vhsysClientServiceMock = new Mock<IVHSYSClientService>();
            _vhsysInvoiceServiceMock = new Mock<IVHSYSInvoiceService>();
        }

        [Fact]
        public void WhenClientIsFound_ThenShouldReturnOneInvoiceRegistered()
        {
            //Arrange
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDTO = Files.Constants.OnePersonToRegister.getInvoiceDTO();


            ClientDTO clientDTO = new ClientDTOBuilder()
                .WithTaxIdNumber(expectedInvoiceDTO.TaxIdNumber)
                .Build();

            InvoiceFeedbackDTO expectedFeedback = new InvoiceFeedbackDTOBuilder()
                .WithInvoiceDTO(expectedInvoiceDTO)
                .Build();

            _vhsysClientServiceMock
                .Setup(v => v.getClientByCnpj(It.IsAny<String>()))
                .Returns(clientDTO);

            _vhsysInvoiceServiceMock
                .Setup(v => v.RegisterInvoice(It.IsAny<InvoiceDTO>(), It.IsAny<ClientDTO>()))
                .Returns(expectedFeedback);

            FileStream fileStream = File.OpenRead(_filePath);
            _registerInvoiceBLL = new RegisterInvoiceBLL(_loggerMock.Object, _vhsysClientServiceMock.Object, _vhsysInvoiceServiceMock.Object);

            //act
            List<InvoiceFeedbackDTO> invoiceFeedbackDTOs = _registerInvoiceBLL.RegisterInvoicesFromFile(fileStream);

            //Assert.
            InvoiceFeedbackDTO invoiceFeedbackDTO = invoiceFeedbackDTOs[0];

            Assert.Single(invoiceFeedbackDTOs);
            AssertInvoiceFeedback(expectedFeedback, invoiceFeedbackDTO);
        }

        [Fact]
        public void WhenGetClientByCpfThrowsError_ThenShouldReturnInvoiceWithFeedbackError()
        {
            //Arrange
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDTO = Files.Constants.OnePersonToRegister.getInvoiceDTO();
            string errorMessage = "CPF não encontrado";

            ClientDTO clientDTO = new ClientDTOBuilder().WithTaxIdNumber(expectedInvoiceDTO.TaxIdNumber).Build();
            
            InvoiceFeedbackDTO expectedFeedback = new InvoiceFeedbackDTOBuilder()
                .WithErrorFeedback(errorMessage)
                .WithInvoiceDTO(Files.Constants.OnePersonToRegister.getInvoiceDTO())
                .Build();


            _vhsysClientServiceMock
                .Setup(v => v.getClientByCnpj(It.IsAny<String>()))
                .Throws(new VHSYSServiceException(errorMessage));

            FileStream fileStream = File.OpenRead(_filePath);
            _registerInvoiceBLL = new RegisterInvoiceBLL(_loggerMock.Object, _vhsysClientServiceMock.Object, _vhsysInvoiceServiceMock.Object);

            //act
            List<InvoiceFeedbackDTO> invoiceFeedbackDTOs = _registerInvoiceBLL.RegisterInvoicesFromFile(fileStream);

            //Assert.
            InvoiceFeedbackDTO invoiceFeedbackDTO = invoiceFeedbackDTOs[0];

            Assert.Single(invoiceFeedbackDTOs);
            AssertInvoiceFeedback(expectedFeedback, invoiceFeedbackDTO);
        }

        [Fact]
        public void WhenRegisterInvoiceReturnsError_ThenShouldReturnInvoiceWithFeedbackError()
        {
            //Arrange
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            InvoiceDTO expectedInvoiceDTO = Files.Constants.OnePersonToRegister.getInvoiceDTO();
            string errorMessage = "Invoice could not been Registered.";

            ClientDTO clientDTO = new ClientDTOBuilder().WithTaxIdNumber(expectedInvoiceDTO.TaxIdNumber).Build();

            InvoiceFeedbackDTO expectedFeedback = new InvoiceFeedbackDTOBuilder()
                .WithErrorFeedback(errorMessage)
                .WithInvoiceDTO(Files.Constants.OnePersonToRegister.getInvoiceDTO())
                .Build();


            _vhsysClientServiceMock
                .Setup(v => v.getClientByCnpj(It.IsAny<String>()))
                .Returns(clientDTO);

            _vhsysInvoiceServiceMock
                .Setup(v => v.RegisterInvoice(It.IsAny<InvoiceDTO>(), It.IsAny<ClientDTO>()))
                .Throws(new VHSYSServiceException(errorMessage));

            FileStream fileStream = File.OpenRead(_filePath);
            _registerInvoiceBLL = new RegisterInvoiceBLL(_loggerMock.Object, _vhsysClientServiceMock.Object, _vhsysInvoiceServiceMock.Object);

            //act
            List<InvoiceFeedbackDTO> invoiceFeedbackDTOs = _registerInvoiceBLL.RegisterInvoicesFromFile(fileStream);

            //Assert.
            InvoiceFeedbackDTO invoiceFeedbackDTO = invoiceFeedbackDTOs[0];

            Assert.Single(invoiceFeedbackDTOs);
            AssertInvoiceFeedback(expectedFeedback, invoiceFeedbackDTO);
        }

        private void AssertInvoiceFeedback(InvoiceFeedbackDTO expectedFeedback, InvoiceFeedbackDTO actualFeedback)
        {
            Assert.Equal(expectedFeedback.Id, actualFeedback.Id);
            Assert.Equal(expectedFeedback.Feedback, actualFeedback.Feedback);
            Assert.Equal(expectedFeedback.InvoiceDTO.TaxIdNumber, actualFeedback.InvoiceDTO.TaxIdNumber);
            Assert.Equal(expectedFeedback.InvoiceDTO.Value, actualFeedback.InvoiceDTO.Value);
            Assert.Equal(expectedFeedback.InvoiceDTO.Description, actualFeedback.InvoiceDTO.Description);
            Assert.Equal(expectedFeedback.InvoiceDTO.Technician, actualFeedback.InvoiceDTO.Technician);
        }
    }
}
