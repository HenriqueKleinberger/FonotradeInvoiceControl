using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using FonotradeInvoiceControl.Mappers;
using FonotradeInvoiceControl.DTO;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSClientService : VHSYSService, IVHSYSClientService
    {
        public VHSYSClientService(IConfiguration config) : base(config) {}

        public ClientDTO getClientByCnpj(string cpfCnpj)
        {
            int environment = _config.GetValue<int>("VHSYS:ApiConfig:environment");
            IRestResponse response = Get($"clientes?ambiente={environment}&cnpj_cliente={cpfCnpj}");
            VHSYSClientResponse clientResponse = JsonConvert.DeserializeObject<VHSYSClientResponse>(response.Content);
            
            ValidateResponse(response, clientResponse);

            return clientResponse.Data.FirstOrDefault().ToClientDTO();
        }
    }
}
