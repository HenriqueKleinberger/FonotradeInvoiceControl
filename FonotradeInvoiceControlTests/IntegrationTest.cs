using FonotradeInvoiceControl.VHSYS.Services;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using FonotradeInvoiceControlTest.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;

namespace FonotradeInvoiceControlTest
{
    public abstract class IntegrationTest
    {
        protected HttpClient _httpClient { get; set; }
        protected Mock<IVHSYSService> _vhsysServiceMock { get; set; }

    public IntegrationTest()
        {
            InitEnvironmentVariable();
            InitDependencyMocks();
            InitServerClient();
        }

        private void InitDependencyMocks()
        {
            _vhsysServiceMock = new Mock<IVHSYSService>();
        }

        private void InitServerClient()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<StartupMock>()
                .ConfigureServices(services =>
                {

                    services.AddSingleton(_vhsysServiceMock.Object);
                }));
            _httpClient = server.CreateClient();
        }

        private void InitEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("VHSYS:ApiConfig:environment", "2");
        }

        [TestCleanup]
        public void BaseTearDown()
        {
            _vhsysServiceMock.Reset();
        }
    }
}
