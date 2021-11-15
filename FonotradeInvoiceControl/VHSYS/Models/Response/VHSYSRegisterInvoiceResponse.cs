using Newtonsoft.Json;
using System;

namespace FonotradeInvoiceControl.VHSYS.Models.Response
{
    public class VHSYSRegisterInvoiceResponse : VHSYSBaseResponse
    {
        public VHSYSInvoice Data { get; set; }
    }
}