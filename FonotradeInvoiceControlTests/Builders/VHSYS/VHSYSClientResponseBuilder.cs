using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using Microsoft.AspNetCore.Http;
using System;
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
            _vhsysClientResponse.Data = this.Data;
            _vhsysClientResponse.code = this.code;
        }
        public VHSYSClientResponseBuilder WithStatus(string status)
        {
            _vhsysClientResponse.status = status;
            return this;
        }

        public VHSYSClientResponseBuilder WithCode(int code)
        {
            _vhsysClientResponse.code = code;
            return this;
        }

        public VHSYSClientResponseBuilder WithData(List<VHSYSClient> data)
        {
            _vhsysClientResponse.Data = data;
            return this;
        }

        public VHSYSClientResponse Build()
        {
            return _vhsysClientResponse;
        }
    }
}
