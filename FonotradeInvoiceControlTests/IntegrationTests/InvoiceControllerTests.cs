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

namespace FonotradeInvoiceControlTest.IntegrationTests
{
    public class InvoiceControllerTests : IntegrationTest
    {
        private string _filePath;
        private VHSYSClient _client;
        private HttpResponseMessage _response;

        [Fact]
        public async Task WhenFileIsNotFormatted_ShouldReturnErrorAsync()
        {
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/one_person_to_register.xlsx";
            string cpf = "001.477.870-09";

            MockGetClientByCpfResponseSuccess(cpf);
            MockPostInvoiceResponseSuccess();
            await CallRegisterInvoiceByFile();

            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);

            _vhsysServiceMock.Verify(m => m.Get($"clientes?ambiente=2&cnpj_cliente={_client.TaxIdNumber}"), Times.Once);
            _vhsysServiceMock.Verify(m => m.Post("notas-servico", It.IsAny<String>()), Times.Once);
        }
        
        private void MockGetClientByCpfResponseSuccess(string cpf)
        {
            _client = CreateClient(cpf);
            VHSYSClientResponse mockResponse = CreateClientResponse();

            _vhsysServiceMock.Setup(s => s.Get(It.IsAny<String>())).Returns(new RestResponse<ClientDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(mockResponse),
                Data = new ClientDTO() { ExternalSystemId = 1, Name = _client.Name, TaxIdNumber = _client.TaxIdNumber }
            });
        }

        private void MockPostInvoiceResponseSuccess()
        {
            VHSYSRegisterInvoiceResponse mockResponse = new VHSYSRegisterInvoiceResponseBuilder()
                .WithData(new VHSYSInvoiceBuilder().WithClient(_client).Build())
                .Build();
            _vhsysServiceMock.Setup(s => s.Post(It.IsAny<String>(), It.IsAny<String>())).Returns(new RestResponse<ClientDTO>
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(mockResponse)
            });
        }

        private VHSYSClientResponse CreateClientResponse() => new VHSYSClientResponseBuilder()
            .WithData(new List<VHSYSClient>()
            {
                _client
            })
            .Build();

        private VHSYSClient CreateClient(string cpf) => new VHSYSClientBuilder()
                            .WithTaxIdNumber(cpf)
                            .Build();

        private async Task CallRegisterInvoiceByFile()
        {
            using (var multipartFormContent = new MultipartFormDataContent())
            {
                //Load the file and set the file's Content-Type header
                StreamContent streamContent = new StreamContent(File.OpenRead(_filePath));
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                //Add the file
                multipartFormContent.Add(streamContent, name: "file", fileName: "file.xlsx");

                //Send it
                _response = await _httpClient.PostAsync("/invoice/register/VHSYS", multipartFormContent);
            }
        }
    }
}
