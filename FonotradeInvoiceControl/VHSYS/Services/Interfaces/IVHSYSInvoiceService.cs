using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using RestSharp;
using System;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSInvoiceService
    {
        public VHSYSRegisterInvoiceResponse RegisterInvoice(InvoiceDTO invoice, VHSYSClient vHSYSClient);
    }
}
