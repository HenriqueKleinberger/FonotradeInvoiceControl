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
using FonotradeInvoiceControl.Clients.Interface;

namespace FonotradeInvoiceControlTest.UnitTests.VHSYS.Services
{
    public class VHSYSServiceTests
    {
        private IConfiguration _configuration;
        private readonly Mock<IVHSYSClient> _vhsysClientMock;
        private VHSYSService _vhsysService;

        public VHSYSServiceTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {VHSYSConfiguration.ENVIRONMENT, "2"},
                {VHSYSConfiguration.SECRET_ACCESS_TOKEN, "secret-access-token" },
                {VHSYSConfiguration.ACCESS_TOKEN, "access-token" }
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _vhsysClientMock = new Mock<IVHSYSClient>();
        }

        [Fact]
        public void WhenGetIsCalled_ThenShouldCallGetFromClient()
        {
            //Arrange
            _vhsysClientMock.Setup(c => c.Get(It.IsAny<RestRequest>())).Verifiable();
            _vhsysService = new VHSYSService(_configuration, _vhsysClientMock.Object);

            //act
            _vhsysService.Get("");

            // Assert
            _vhsysClientMock.Verify(c => c.Get(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void WhenPostIsCalled_ThenShouldCallPostFromClient()
        {
            //Arrange
            _vhsysClientMock.Setup(c => c.Post(It.IsAny<RestRequest>())).Verifiable();
            _vhsysService = new VHSYSService(_configuration, _vhsysClientMock.Object);

            //act
            _vhsysService.Post("", "");

            // Assert
            _vhsysClientMock.Verify(c => c.Post(It.IsAny<RestRequest>()), Times.Once());
        }
    }
}
