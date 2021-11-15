using Microsoft.AspNetCore.Http;
using Moq;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.ExcelUtils;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using System.Linq;
using Newtonsoft.Json;

namespace FonotradeInvoiceControlTest.UnitTests.ExcelUtils
{
    public class VHSYSClientService
    {
        [Fact]
        public void ShouldParseInvoiceFileCorrectly()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            FileStream stream = File.OpenRead($"{AppDomain.CurrentDomain.BaseDirectory}/files/invoice_file_template.xlsx");
            fileMock.Setup(_ => _.OpenReadStream()).Returns(stream);

            // Act.
            List<InvoiceDTO> result = ParseInvoiceFile.Parse(fileMock.Object).ToList();

            //Assert.
            Assert.Equal(4, result.Count);
            Assert.Equal(JsonConvert.SerializeObject(new InvoiceDTO()
            {
                Description = "Curso On-Line - Transtornos Motores de Fala - Dra 1 - ministrado em setembro/2021",
                TaxIdNumber = "603.322.530-90",
                Technician = "Tec1-Set/2021",
                Value = new decimal(250.00)
            }), JsonConvert.SerializeObject(result[0]));
            Assert.Equal(JsonConvert.SerializeObject(new InvoiceDTO()
            {
                Description = "Curso On-Line - Transtornos Motores de Fala � Dra 2 - ministrado em setembro/2021",
                TaxIdNumber = "635.129.990-00",
                Technician = "Tec2-Set/2021",
                Value = new decimal(237.50)
            }), JsonConvert.SerializeObject(result[1]));
            Assert.Equal(JsonConvert.SerializeObject(new InvoiceDTO()
            {
                Description = "Curso On-Line - Transtornos Motores de Fala - Dra 3 - ministrado em setembro/2021",
                TaxIdNumber = "631.485.600-00",
                Technician = "Tec3-Set/2021",
                Value = new decimal(175.00)
            }), JsonConvert.SerializeObject(result[2]));
            Assert.Equal(JsonConvert.SerializeObject(new InvoiceDTO()
            {
                Description = "Curso On-Line - Transtornos Motores de Fala - Dra 4 - ministrado em setembro/2021",
                TaxIdNumber = "626.536.040-00",
                Technician = "Tec4-Set/2021",
                Value = new decimal(176.86)
            }), JsonConvert.SerializeObject(result[3]));
        }
    }
}
