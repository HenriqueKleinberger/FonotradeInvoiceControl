using Moq;
using FonotradeInvoiceControl.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;
using System.Net;
using FonotradeInvoiceControlTest.Builder.VHSYS;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using FonotradeInvoiceControl.VHSYS.Models.Response;

namespace FonotradeInvoiceControlTest.IntegrationTests.InvoiceController
{
    public class IssueInvoiceTests : IntegrationTest
    {
        private string _filePath;
        private HttpResponseMessage _response;

        [Fact]
        public async Task WhenVHSYSIssueInvoice_ShouldReturnSuccessStatus()
        {
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_issue.xlsx";
            InvoiceDTO invoiceDTO = Files.Constants.OnePersonToIssue.getInvoiceDTO();

            MockIssueInvoiceResponseSuccess();
            await CallIssueInvoiceByFile();

            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);

            _vhsysServiceMock.Verify(m => m.Post($"notas-servico/{invoiceDTO.ServiceId}/emitir"), Times.Once);
        }

        private void MockIssueInvoiceResponseSuccess()
        {
            VHSYSIssueInvoiceResponse mockResponse = new VHSYSIssueInvoiceResponseBuilder()
                .WithData(new VHSYSIssueInvoiceBuilder().Build())
                .Build();
            _vhsysServiceMock.Setup(s => s.Post(It.IsAny<String>())).Returns(new RestResponse<ClientDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(mockResponse)
            });
        }

        private async Task CallIssueInvoiceByFile()
        {
            using (var multipartFormContent = new MultipartFormDataContent())
            {
                //Load the file and set the file's Content-Type header
                StreamContent streamContent = new StreamContent(File.OpenRead(_filePath));
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                //Add the file
                multipartFormContent.Add(streamContent, name: "file", fileName: "file.xlsx");

                //Send it
                _response = await _httpClient.PostAsync("/invoice/issue/VHSYS", multipartFormContent);
            }
        }
    }
}
