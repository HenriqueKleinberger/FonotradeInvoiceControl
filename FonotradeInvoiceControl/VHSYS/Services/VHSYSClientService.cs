using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using RestSharp;
using System.Linq;
using FonotradeInvoiceControl.Mappers;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
using FonotradeInvoiceControl.Constants.VHSYS;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class VHSYSClientService : BaseVHSYSService, IVHSYSClientService
    {
        public VHSYSClientService(IConfiguration config, IVHSYSService vhsysService) : base(config, vhsysService)
        {
        }

        public ClientDTO getClientByCnpj(string cpfCnpj)
        {
            IRestResponse response = ExecuteVHSYSClientSearch(cpfCnpj);
            VHSYSClientResponse clientResponse = ParseResponse<VHSYSClientResponse>(response);
            return clientResponse.data.FirstOrDefault().ToClientDTO();
        }

        private IRestResponse ExecuteVHSYSClientSearch(string cpfCnpj)
        {
            int environment = _config.GetValue<int>(VHSYSConfiguration.ENVIRONMENT);
            IRestResponse response = _vhsysService.Get($"clientes?ambiente={environment}&cnpj_cliente={cpfCnpj}");

            return response;
        }
    }
}
