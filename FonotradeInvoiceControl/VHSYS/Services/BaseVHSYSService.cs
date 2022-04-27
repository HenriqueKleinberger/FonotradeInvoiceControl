using Microsoft.Extensions.Configuration;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using RestSharp;
using FonotradeInvoiceControl.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FonotradeInvoiceControl.Constants.VHSYS;

namespace FonotradeInvoiceControl.VHSYS.Services
{
    public abstract class BaseVHSYSService
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
            if (jObject["code"].ToString() == BaseResponse.ERROR_CODE.ToString())
            {
                throw new VHSYSServiceException(jObject["data"].ToString());
            }
        }

        protected T ParseResponse<T>(IRestResponse response)
        {
            ValidateResponse(response);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
