using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using Microsoft.AspNetCore.Http;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSIssueInvoiceResponseBuilder
    {
        private VHSYSIssueInvoiceResponse _vhsysIssueInvoiceResponse;

        private string status = StatusCodes.Status200OK.ToString();
        private int code = StatusCodes.Status200OK;
        private VHSYSIssueInvoice Data = new VHSYSIssueInvoiceBuilder().Build();

        public VHSYSIssueInvoiceResponseBuilder()
        {
            _vhsysIssueInvoiceResponse = new VHSYSIssueInvoiceResponse();
            _vhsysIssueInvoiceResponse.status = this.status;
            _vhsysIssueInvoiceResponse.data = this.Data;
            _vhsysIssueInvoiceResponse.code = this.code;
        }
        public VHSYSIssueInvoiceResponseBuilder WithStatus(string status)
        {
            _vhsysIssueInvoiceResponse.status = status;
            return this;
        }

        public VHSYSIssueInvoiceResponseBuilder WithCode(int code)
        {
            _vhsysIssueInvoiceResponse.code = code;
            return this;
        }

        public VHSYSIssueInvoiceResponseBuilder WithData(VHSYSIssueInvoice data)
        {
            _vhsysIssueInvoiceResponse.data = data;
            return this;
        }

        public VHSYSIssueInvoiceResponse Build() => _vhsysIssueInvoiceResponse;
    }
}
