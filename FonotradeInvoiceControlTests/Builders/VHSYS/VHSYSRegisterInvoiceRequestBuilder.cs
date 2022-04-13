//using FonotradeInvoiceControl.VHSYS.Models;
//using FonotradeInvoiceControl.VHSYS.Models.Requests;
//using FonotradeInvoiceControl.VHSYS.Models.Response;
//using FonotradeInvoiceControl.VHSYS.Models.Responses;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;

//namespace FonotradeInvoiceControlTest.Builder.VHSYS
//{
//    public class VHSYSRegisterInvoiceRequestBuilder
//    {
//        private VHSYSRegisterInvoiceRequest _vhsysRegisterInvoiceRequest;

//        private int Batch = 1;
//        private int Environment = Int32.Parse(Constants.Configuration.ENVIRONMENT);
//        private string City = "Rio de Janeiro";
//        private int ClientId = 1;
//        private int BusinessCode = 1234;
//        private decimal ServiceValue = 350;
//        public int ServiceNature = 1;


//        public VHSYSRegisterInvoiceRequestBuilder()
//        {
//            _vhsysRegisterInvoiceRequest = new VHSYSRegisterInvoiceRequest();
//            _vhsysRegisterInvoiceRequest.Batch = this.Batch;
//            _vhsysRegisterInvoiceRequest.Environment = this.Environment;
//            _vhsysRegisterInvoiceRequest.City = this.City;
//            _vhsysRegisterInvoiceRequest.ClientId = this.ClientId;
//            _vhsysRegisterInvoiceRequest.BusinessCode = this.BusinessCode;
//            _vhsysRegisterInvoiceRequest.ServiceValue = this.ServiceValue;
//            _vhsysRegisterInvoiceRequest.ServiceNature = this.ServiceNature;
//            _vhsysRegisterInvoiceRequest.CalculationValue = this.CalculationValue;
//        }
//        public VHSYSRegisterInvoiceRequestBuilder WithClientId(int clientId)
//        {
//            _vhsysRegisterInvoiceRequest.ClientId = clientId;
//            return this;
//        }

//        public VHSYSRegisterInvoiceRequest Build()
//        {
//            return _vhsysRegisterInvoiceRequest;
//        }
//    }
//}
