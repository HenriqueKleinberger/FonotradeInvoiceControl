using FonotradeInvoiceControl.VHSYS.Models;
using RestSharp;
using System;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSClientService
    {
        public VHSYSClient getClientByCnpj(string cpfCnpj);
    }
}
