using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FonotradeInvoiceControl.Mappers
{
    public static class InvoiceMapper
    {
        private const string REGISTERED = "CADASTRADO";

        public static InvoiceFeedbackDTO ToInvoiceFeedbackDTO(this VHSYSRegisterInvoiceResponse registerInvoiceResponse, InvoiceDTO invoiceDTO)
        {
            InvoiceFeedbackDTO invoiceFeedbackDTO = new InvoiceFeedbackDTO()
            {
                Feedback = REGISTERED,
                Id = registerInvoiceResponse.Data.RegisterId,
                InvoiceDTO = invoiceDTO
            };

            return invoiceFeedbackDTO;
        }
    }
}
