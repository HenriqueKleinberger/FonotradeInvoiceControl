using FonotradeInvoiceControl.VHSYS.Models;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSIssueInvoiceBuilder
    {
        private VHSYSIssueInvoice _vhsysIssueInvoice;
        private string InvoiceNumber = "4321";

        public VHSYSIssueInvoiceBuilder()
        {
            _vhsysIssueInvoice = new VHSYSIssueInvoice();
            _vhsysIssueInvoice.InvoiceNumber = this.InvoiceNumber;
        }
        public VHSYSIssueInvoiceBuilder WithInvoiceNumber(string invoiceNumber)
        {
            _vhsysIssueInvoice.InvoiceNumber = invoiceNumber;
            return this;
        }

        public VHSYSIssueInvoice Build()
        {
            return _vhsysIssueInvoice;
        }
    }
}
