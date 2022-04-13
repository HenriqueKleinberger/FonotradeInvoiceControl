using FonotradeInvoiceControl.DTO;
using Xunit;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.Mappers;
using FonotradeInvoiceControl.VHSYS.Models.Requests;
using System;
using FonotradeInvoiceControl.Constants.VHSYS;

namespace FonotradeInvoiceControlTest.UnitTests.Models
{
    public class VHSYSRegisterInvoiceRequestTests
    {
        [Fact]
        public void WhenVHSYSRegisterInvoiceRequestIsCreated_ShouldReturnVHSYSRegisterInvoiceRequestWithRightInfos()
        {
            //Arrange

            InvoiceDTO invoiceDTO = new InvoiceDTO()
            {
                Description = "Description",
                TaxIdNumber = "XXX.XXX.XXX-XX",
                Technician = "Technician",
                Value = new Decimal(123.56)
            };

            ClientDTO clientDTO = new ClientDTO()
            {
                ExternalSystemId = 1,
                Name = "Matheus Prates",
                TaxIdNumber = "XXX.XXX.XXX-XX"
            };
            int environment = 2;


            VHSYSRegisterInvoiceRequest request =
                new VHSYSRegisterInvoiceRequest(invoiceDTO, clientDTO, environment);;

            Assert.Equal(environment, request.Environment);
            Assert.Equal(clientDTO.ExternalSystemId, request.ClientId);
            Assert.Equal(clientDTO.Name, request.ClientName);
            Assert.Equal(invoiceDTO.Description, request.ServiceDescription);
            Assert.Equal(invoiceDTO.Value, request.ServiceValue);
            Assert.Equal(invoiceDTO.Value, request.TotalValue);
            Assert.Equal(invoiceDTO.Value, request.CalculationValue);
            Assert.Equal(RegisterInvoice.DEFAULT_BATCH, request.Batch);
            Assert.Equal(invoiceDTO.Technician, request.SellerName);
            Assert.Equal(RegisterInvoice.DEFAULT_TAX_POLICY, request.TaxPolicy);
            Assert.Equal(RegisterInvoice.DEFAULT_SERVICE_NATURE, request.ServiceNature);
            Assert.Equal(RegisterInvoice.DEFAULT_PLACE, request.Place);
            Assert.Equal(RegisterInvoice.DEFAULT_CITY, request.City);
            Assert.Equal(RegisterInvoice.DEFAULT_STATUS, request.Status);
            Assert.Equal(RegisterInvoice.DEFAULT_BUSINESS_CODE, request.BusinessCode);
        }
    }
}
