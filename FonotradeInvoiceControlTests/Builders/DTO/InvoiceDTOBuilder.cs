using FonotradeInvoiceControl.DTO;
using System;

namespace FonotradeInvoiceControlTest.Builder.DTO
{
    public class InvoiceDTOBuilder
    {
        private InvoiceDTO _invoiceDTO;

        private int ServiceId;
        private string TaxIdNumber = "001.477.870-09";
        private string Description = "Description";
        private string Technician = "Technician";
        private Decimal Value = new Decimal(350.22);

        public InvoiceDTOBuilder()
        {
            _invoiceDTO = new InvoiceDTO();
            _invoiceDTO.ServiceId = this.ServiceId;
            _invoiceDTO.TaxIdNumber = this.TaxIdNumber;
            _invoiceDTO.Description = this.Description;
            _invoiceDTO.Technician = this.Technician;
            _invoiceDTO.Value = this.Value;
        }
        public InvoiceDTOBuilder WithServiceId(int serviceInvoice)
        {
            _invoiceDTO.ServiceId = serviceInvoice;
            return this;
        }

        public InvoiceDTOBuilder WithTaxIdNumber(string taxIdNumber)
        {
            _invoiceDTO.TaxIdNumber = taxIdNumber;
            return this;
        }

        public InvoiceDTOBuilder WithDescription(string description)
        {
            _invoiceDTO.Description = description;
            return this;
        }

        public InvoiceDTOBuilder WithTechnician(string technician)
        {
            _invoiceDTO.Technician = technician;
            return this;
        }

        public InvoiceDTOBuilder WithValue(Decimal value)
        {
            _invoiceDTO.Value = value;
            return this;
        }

        public InvoiceDTO Build()
        {
            return _invoiceDTO;
        }
    }
}
