using FonotradeInvoiceControl.DTO;
using System;

namespace FonotradeInvoiceControlTest.Builder.DTO
{
    public class ClientDTOBuilder
    {
        private ClientDTO _clientDTO;

        private int ExternalSystemId;
        private string TaxIdNumber = "055.744.520-57";
        private string Name = "Matheus Prates";

        public ClientDTOBuilder()
        {
            Random random = new Random();

            _clientDTO = new ClientDTO();
            _clientDTO.ExternalSystemId = random.Next(1, 999);
            _clientDTO.TaxIdNumber = this.TaxIdNumber;
            _clientDTO.Name = this.Name;
        }
        public ClientDTOBuilder WithExternalSystemId(int externalSystemId)
        {
            _clientDTO.ExternalSystemId = externalSystemId;
            return this;
        }

        public ClientDTOBuilder WithName(string name)
        {
            _clientDTO.Name = name;
            return this;
        }

        public ClientDTOBuilder WithTaxIdNumber(string taxIdNumber)
        {
            _clientDTO.TaxIdNumber = taxIdNumber;
            return this;
        }

        public ClientDTO Build()
        {
            return _clientDTO;
        }
    }
}
