using FonotradeInvoiceControl.Constants;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;
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

        public static InvoiceFeedbackDTO ToInvoiceFeedbackDTO(this VHSYSInvoice vhsysInvoice, InvoiceDTO invoiceDTO)
        {
            InvoiceFeedbackDTO invoiceFeedbackDTO = new InvoiceFeedbackDTO()
            {
                Feedback = InvoiceFeedback.REGISTERED,
                Id = vhsysInvoice.RegisterId,
                InvoiceDTO = invoiceDTO
            };

            return invoiceFeedbackDTO;
        }
    }
}
