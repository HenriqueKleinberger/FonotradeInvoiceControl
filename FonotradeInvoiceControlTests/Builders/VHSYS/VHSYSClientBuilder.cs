using FonotradeInvoiceControl.VHSYS.Models;
using System;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSClientBuilder
    {
        private VHSYSClient _vhsysClient;

        private string Name = "Matheus Prates";
        private string TaxIdNumber = "055.744.520-57";

        public VHSYSClientBuilder()
        {
            Random random = new Random();

            _vhsysClient = new VHSYSClient();
            _vhsysClient.Id = random.Next(1, 999);
            _vhsysClient.Name = this.Name;
            _vhsysClient.TaxIdNumber = this.TaxIdNumber;
        }
        public VHSYSClientBuilder WithName(string name)
        {
            _vhsysClient.Name = name;
            return this;
        }

        public VHSYSClientBuilder WithTaxIdNumber(string taxIdNumber)
        {
            _vhsysClient.TaxIdNumber = taxIdNumber;
            return this;
        }

        public VHSYSClient Build()
        {
            return _vhsysClient;
        }
    }
}
