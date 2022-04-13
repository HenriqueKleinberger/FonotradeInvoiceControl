//using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
//using FonotradeInvoiceControlTest.Utils;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using FonotradeInvoiceControl.VHSYS.Models;
//using FonotradeInvoiceControl.VHSYS.Models.Response;
//using FonotradeInvoiceControlTest.Builder.VHSYS;
//using System.Net;
//using Newtonsoft.Json;
//using RestSharp;

//namespace FonotradeInvoiceControlTest
//{
//    public abstract class BaseTests
//    {
//        protected string _filePath;
//        protected VHSYSClient _client;

//        protected Mock<IVHSYSService> _vhsysServiceMock { get; set; }

//        private void MockPostInvoiceResponseSuccess()
//        {
//            VHSYSRegisterInvoiceResponse mockResponse = new VHSYSRegisterInvoiceResponseBuilder()
//                .WithData(new VHSYSInvoiceBuilder().WithClient(_client).Build())
//                .Build();
//            _vhsysServiceMock.Setup(s => s.Post(It.IsAny<String>(), It.IsAny<String>())).Returns(new RestResponse<ClientDTO>
//            {
//                StatusCode = HttpStatusCode.OK,
//                Content = JsonConvert.SerializeObject(mockResponse)
//            });
//        }

//    }
//}
