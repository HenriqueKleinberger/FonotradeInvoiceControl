using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSClientService : IVHSYSClientService
    {
        private readonly IVHSYSService _vhsysService;
        private readonly IConfiguration _config;

        public VHSYSClientService(IVHSYSService vhsysService, IConfiguration config)
        {
            _vhsysService = vhsysService;
            _config = config;
        }

        public VHSYSClient getClientByCnpj(string cpfCnpj)
        {
            int environment = _config.GetValue<int>("VHSYS:ApiConfig:environment");
            IRestResponse response = _vhsysService.Get($"clientes?ambiente={environment}&cnpj_cliente={cpfCnpj}");
            VHSYSClientResponse clientResponse = JsonConvert.DeserializeObject<VHSYSClientResponse>(response.Content);
            VHSYSClient vhsysClient = clientResponse.Clients.FirstOrDefault();
            return vhsysClient;
        }
    }
}
