using FonotradeInvoiceControl.VHSYS.Models;
using System;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSInvoiceBuilder
    {
        private VHSYSInvoice _vhsysInvoice;

        private string SellerName = "Seller Name";
        private string ClientName = "Client Name";
        private string ServiceDescription = "Service Description";

        public VHSYSInvoiceBuilder()
        {
            Random random = new Random();

            _vhsysInvoice = new VHSYSInvoice();
            _vhsysInvoice.RegisterId = random.Next(1, 999);
            _vhsysInvoice.ClientId = random.Next(1, 999);
            _vhsysInvoice.SellerName = this.SellerName;
            _vhsysInvoice.ClientName = this.ClientName;
            _vhsysInvoice.ServiceDescription = this.ServiceDescription;
        }
        public VHSYSInvoiceBuilder WithClientId(int clientId)
        {
            _vhsysInvoice.ClientId = clientId;
            return this;
        }

        public VHSYSInvoiceBuilder WithSellerName(string sellerName)
        {
            _vhsysInvoice.SellerName = sellerName;
            return this;
        }

        public VHSYSInvoiceBuilder WithClientName(string clientName)
        {
            _vhsysInvoice.ClientName = clientName;
            return this;
        }

        public VHSYSInvoiceBuilder WithClient(VHSYSClient client)
        {
            _vhsysInvoice.ClientId = client.Id;
            _vhsysInvoice.ClientName = client.Name;
            return this;
        }

        public VHSYSInvoice Build()
        {
            return _vhsysInvoice;
        }
    }
}
