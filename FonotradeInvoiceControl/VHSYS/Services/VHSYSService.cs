using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using RestSharp;
using FonotradeInvoiceControl.Constants.VHSYS;
using FonotradeInvoiceControl.Clients.Interface;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSService : IVHSYSService
    {
        protected readonly IConfiguration _config;

        private IVHSYSClient _vhsysClient;
        private RestRequest _request;
        private string _url;

        public VHSYSService(IConfiguration config, IVHSYSClient restClient)
        {
            _config = config;
            _vhsysClient = restClient;
        }

        public IRestResponse Get(string url)
        {
            _url = url;

            ConfigRequest();

            return _vhsysClient.Get(_request);
        }

        public IRestResponse Post(string url, string body)
        {
            _url = url;

            ConfigRequest();
            
            _request.AddJsonBody(body);

            return _vhsysClient.Post(_request);
        }

        public IRestResponse Post(string url)
        {
            _url = url;

            ConfigRequest();

            return _vhsysClient.Post(_request);
        }

        private void ConfigRequest()
        {
            _request = new RestRequest(_url, DataFormat.Json);
            _request.AddHeader("access-token", _config.GetValue<string>(VHSYSConfiguration.ACCESS_TOKEN));
            _request.AddHeader("secret-access-token", _config.GetValue<string>(VHSYSConfiguration.SECRET_ACCESS_TOKEN));
        }
    }
}
