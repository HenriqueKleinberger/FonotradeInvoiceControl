using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using Microsoft.AspNetCore.Http;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSRegisterInvoiceResponseBuilder
    {
        private VHSYSRegisterInvoiceResponse _vhsysRegisterInvoiceResponse;

        private string status = StatusCodes.Status200OK.ToString();
        private int code = StatusCodes.Status200OK;
        private VHSYSRegisterInvoice Data = new VHSYSRegisterInvoiceBuilder().Build();

        public VHSYSRegisterInvoiceResponseBuilder()
        {
            _vhsysRegisterInvoiceResponse = new VHSYSRegisterInvoiceResponse();
            _vhsysRegisterInvoiceResponse.status = this.status;
            _vhsysRegisterInvoiceResponse.data = this.Data;
            _vhsysRegisterInvoiceResponse.code = this.code;
        }
        public VHSYSRegisterInvoiceResponseBuilder WithStatus(string status)
        {
            _vhsysRegisterInvoiceResponse.status = status;
            return this;
        }

        public VHSYSRegisterInvoiceResponseBuilder WithCode(int code)
        {
            _vhsysRegisterInvoiceResponse.code = code;
            return this;
        }

        public VHSYSRegisterInvoiceResponseBuilder WithData(VHSYSRegisterInvoice data)
        {
            _vhsysRegisterInvoiceResponse.data = data;
            return this;
        }

        public VHSYSRegisterInvoiceResponse Build()
        {
            return _vhsysRegisterInvoiceResponse;
        }
    }
}
