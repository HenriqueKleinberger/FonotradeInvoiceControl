using FonotradeInvoiceControl.DTO;
using Xunit;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.Mappers;

namespace FonotradeInvoiceControlTest.UnitTests.Mappers
{
    public class ClientMapperTests
    {
        [Fact]
        public void WhenVHSYSClientIsMappedToClientDTO_ShouldReturnClientDTOWithRightInfos()
        {
            //Arrange
            VHSYSClient vhsysClient = new VHSYSClient()
            {
                Id = 1,
                Name = "Matheus Prates",
                TaxIdNumber = "XXX-XXXXX"
            };

            ClientDTO clientDTO = vhsysClient.ToClientDTO();

            Assert.Equal(vhsysClient.Id, clientDTO.ExternalSystemId);
            Assert.Equal(vhsysClient.Name, clientDTO.Name);
            Assert.Equal(vhsysClient.TaxIdNumber, clientDTO.TaxIdNumber);
        }
    }
}
