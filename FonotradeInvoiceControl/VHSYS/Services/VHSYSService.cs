using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using RestSharp;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSService : IVHSYSService
    {
        protected readonly IConfiguration _config;

        public VHSYSService(IConfiguration config)
        {
            _config = config;
        }

        public IRestResponse Get(string url)
        {
            var client = new RestClient("https://api.vhsys.com/v2/");

            var request = new RestRequest(url, DataFormat.Json);
            request.AddHeader("access-token", _config.GetValue<string>("VHSYS:ApiConfig:access-token"));
            request.AddHeader("secret-access-token", _config.GetValue<string>("VHSYS:ApiConfig:secret-access-token"));

            var response = client.Get(request);
            return response;
        }

        public IRestResponse Post(string url, string body)
        {
            var client = new RestClient("https://api.vhsys.com/v2/");

            var request = new RestRequest(url, DataFormat.Json);
            request.AddHeader("access-token", _config.GetValue<string>("VHSYS:ApiConfig:access-token"));
            request.AddHeader("secret-access-token", _config.GetValue<string>("VHSYS:ApiConfig:secret-access-token"));
            request.AddJsonBody(body);

            var response = client.Post(request);
            return response;
        }
    }
}
