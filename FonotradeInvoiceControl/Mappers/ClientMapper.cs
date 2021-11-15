using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Models.Response;
using FonotradeInvoiceControl.VHSYS.Models.Responses;
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
    public static class ClientMapper
    {
        public static ClientDTO ToClientDTO(this VHSYSClient vhsysClient)
        {
            ClientDTO clientDTO = new ClientDTO()
            {
                ExternalSystemId = vhsysClient.Id,
                Name = vhsysClient.Name,
                TaxIdNumber = vhsysClient.TaxIdNumber
            };

            return clientDTO;
        }
    }
}
