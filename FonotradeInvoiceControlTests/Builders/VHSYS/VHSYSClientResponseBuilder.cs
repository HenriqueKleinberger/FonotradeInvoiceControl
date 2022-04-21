using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using Microsoft.AspNetCore.Http;
using FonotradeInvoiceControl.Constants.VHSYS;
using System.Collections.Generic;

namespace FonotradeInvoiceControlTest.Builder.VHSYS
{
    public class VHSYSClientResponseBuilder
    {
        private VHSYSClientResponse _vhsysClientResponse;

        private string status = StatusCodes.Status200OK.ToString();
        private int code = StatusCodes.Status200OK;
        private List<VHSYSClient> Data = new List<VHSYSClient>()
        {
            new VHSYSClientBuilder().Build()
        };

        public VHSYSClientResponseBuilder()
        {
            _vhsysClientResponse = new VHSYSClientResponse();
            _vhsysClientResponse.status = this.status;
            _vhsysClientResponse.data = this.Data;
            _vhsysClientResponse.code = this.code;
        }
        public VHSYSClientResponseBuilder WithStatus(string status)
        {
            _vhsysClientResponse.status = status;
            return this;
        }

        public VHSYSClientResponseBuilder WithError()
        {
            _vhsysClientResponse.code = BaseResponse.ERROR_CODE;
            _vhsysClientResponse.data = new List<VHSYSClient>();
            return this;
        }

        public VHSYSClientResponseBuilder WithData(List<VHSYSClient> data)
        {
            _vhsysClientResponse.data = data;
            return this;
        }

        public VHSYSClientResponse Build()
        {
            return _vhsysClientResponse;
        }
    }
}
