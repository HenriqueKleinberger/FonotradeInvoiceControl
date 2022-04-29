using FonotradeInvoiceControl.VHSYS.Models;
using System;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSRegisterInvoiceBuilder
    {
        private VHSYSRegisterInvoice _vhsysInvoice;

        private string SellerName = "Seller Name";
        private string ClientName = "Client Name";
        private string ServiceDescription = "Service Description";

        public VHSYSRegisterInvoiceBuilder()
        {
            Random random = new Random();

            _vhsysInvoice = new VHSYSRegisterInvoice();
            _vhsysInvoice.RegisterId = random.Next(1, 999);
            _vhsysInvoice.ClientId = random.Next(1, 999);
            _vhsysInvoice.SellerName = this.SellerName;
            _vhsysInvoice.ClientName = this.ClientName;
            _vhsysInvoice.ServiceDescription = this.ServiceDescription;
        }
        public VHSYSRegisterInvoiceBuilder WithClientId(int clientId)
        {
            _vhsysInvoice.ClientId = clientId;
            return this;
        }

        public VHSYSRegisterInvoiceBuilder WithSellerName(string sellerName)
        {
            _vhsysInvoice.SellerName = sellerName;
            return this;
        }

        public VHSYSRegisterInvoiceBuilder WithClientName(string clientName)
        {
            _vhsysInvoice.ClientName = clientName;
            return this;
        }

        public VHSYSRegisterInvoiceBuilder WithClient(VHSYSClient client)
        {
            _vhsysInvoice.ClientId = client.Id;
            _vhsysInvoice.ClientName = client.Name;
            return this;
        }

        public VHSYSRegisterInvoice Build()
        {
            return _vhsysInvoice;
        }
    }
}
