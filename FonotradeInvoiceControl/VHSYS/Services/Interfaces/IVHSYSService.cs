using RestSharp;
using System;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSService
    {
        public IRestResponse Get(string url);
    }
}
