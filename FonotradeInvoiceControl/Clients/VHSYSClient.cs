using FonotradeInvoiceControl.Clients.Interface;
using FonotradeInvoiceControl.Constants.VHSYS;
using RestSharp;
using System;

namespace FonotradeInvoiceControl.Clients
{
    public class VHSYSClient : IVHSYSClient
    {
        private IRestClient _vhsysClient;

        public VHSYSClient() => _vhsysClient = new RestClient(VHSYSConfiguration.BASE_URL);

        public IRestResponse Get(RestRequest request) => _vhsysClient.Get(request);

        public IRestResponse Post(RestRequest request) => _vhsysClient.Post(request);
    }
}