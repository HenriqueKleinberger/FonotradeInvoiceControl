using FonotradeInvoiceControl.DTO;
using System;
using Xunit;
using FonotradeInvoiceControl.Constants;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.Mappers;
using FonotradeInvoiceControl.Constants.Excel.RegisterInvoice;

namespace FonotradeInvoiceControlTest.UnitTests.Mappers
{
    public class InvoiceMapperTests
    {
        [Fact]
        public void WhenVHSYSInvoiceIsMappedToInvoiceFeedbackDTO_ShouldReturnInvoiceFeedbackDTOWithRightInfos()
        {
            //Arrange
            VHSYSRegisterInvoice vhsysInvoice = new VHSYSRegisterInvoice()
            {
                ClientId = 1234,
                ClientName = "Matheus Prates",
                RegisterId = 12,
                SellerName = "Seller Name",
                ServiceDescription = "Service Description",
                Value = new Decimal(123.25)
            };

            InvoiceDTO invoiceDTO = new InvoiceDTO()
            {
                 Description = "Description",
                 TaxIdNumber = "XXX.XXX.XXX-XX",
                 Technician = "Technician",
                 Value = new Decimal(123.56)
            };

            InvoiceFeedbackDTO invoiceFeedbackDTO = vhsysInvoice.ToInvoiceFeedbackDTO(invoiceDTO);

            Assert.Equal(RegisterInvoiceFeedback.REGISTERED, invoiceFeedbackDTO.Feedback);
            Assert.Equal(vhsysInvoice.RegisterId, invoiceFeedbackDTO.RegisteredId);
            Assert.Equal(vhsysInvoice.ServiceId, invoiceFeedbackDTO.Id);
            Assert.Equal(invoiceDTO.Description, invoiceFeedbackDTO.InvoiceDTO.Description);
            Assert.Equal(invoiceDTO.TaxIdNumber, invoiceFeedbackDTO.InvoiceDTO.TaxIdNumber);
            Assert.Equal(invoiceDTO.Technician, invoiceFeedbackDTO.InvoiceDTO.Technician);
            Assert.Equal(invoiceDTO.Value, invoiceFeedbackDTO.InvoiceDTO.Value);

        }
    }
}
