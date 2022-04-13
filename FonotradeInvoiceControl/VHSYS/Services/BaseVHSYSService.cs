using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using RestSharp;
using FonotradeInvoiceControl.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public class BaseVHSYSService
    {

        protected readonly IConfiguration _config;
        protected readonly IVHSYSService _vhsysService;

        public BaseVHSYSService(IConfiguration config, IVHSYSService vhsysService)
        {
            _config = config;
            _vhsysService = vhsysService;
        }
        public void ValidateResponse(IRestResponse response)
        {
            JObject jObject = JObject.Parse(response.Content);
            if (jObject["code"].ToString() == "403")
            {
                throw new VHSYSServiceException(jObject["data"].ToString());
            }
        }

        public T ParseResponse<T>(IRestResponse response)
        {
            ValidateResponse(response);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
