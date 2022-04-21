using FonotradeInvoiceControl.DTO;
using System;
using Xunit;
using FonotradeInvoiceControl.Exceptions;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Moq;
using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using FonotradeInvoiceControlTest.Builder.VHSYS;
using System.Collections.Generic;
using FonotradeInvoiceControl.Constants.VHSYS;

namespace FonotradeInvoiceControlTest.UnitTests.VHSYS.Services
{
    public class VHSYSClientServiceTests
    {
        private IConfiguration _configuration;
        private readonly Mock<IVHSYSService> _vhsysServiceMock;
        private VHSYSClientService _vhsysClientService;

        public VHSYSClientServiceTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {VHSYSConfiguration.ENVIRONMENT, "2"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _vhsysServiceMock = new Mock<IVHSYSService>();
        }

        [Fact]
        public void WhenVhsysServiceReturnsCode403_ThenShouldThrowVHSYSServiceException()
        {
            //Arrange
            MockGetClientByCpfResponseError();
            _vhsysClientService = new VHSYSClientService(_configuration, _vhsysServiceMock.Object);

            //act
            Assert.Throws<VHSYSServiceException>(() => _vhsysClientService.getClientByCnpj(""));
        }

        private void MockGetClientByCpfResponseError()
        {
            VHSYSClientResponse mockResponse = new VHSYSClientResponseBuilder()
                .WithError()
                .Build();

            _vhsysServiceMock.Setup(s => s.Get(It.IsAny<String>())).Returns(new RestResponse<ClientDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(mockResponse)
            });
        }
    }
}
