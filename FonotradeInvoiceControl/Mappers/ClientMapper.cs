using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;

namespace FonotradeInvoiceControl.Mappers
{
    public static class ClientMapper
    {
        public static ClientDTO ToClientDTO(this VHSYSClient vhsysClient)
        {
            ClientDTO clientDTO = new ClientDTO()
            {
                ExternalSystemId = vhsysClient.Id,
                Name = vhsysClient.Name,
                TaxIdNumber = vhsysClient.TaxIdNumber
            };

            return clientDTO;
        }
    }
}
