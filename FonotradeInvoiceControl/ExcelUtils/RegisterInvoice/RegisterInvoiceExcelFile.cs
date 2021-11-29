using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControl.ExcelUtils;
using FonotradeInvoiceControl.VHSYS.Models;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FonotradeInvoiceControl.ExcelUtils.RegisterInvoice
{
    public static class RegisterInvoiceExcelFile
    {
        public static readonly int FIRST_TABLE_ROW = 2;
        public static readonly int TAX_ID_NUMBER = 4;
        public static readonly int DESCRIPTION = 5;
        public static readonly int TECHNICIAN = 6;
        public static readonly int VALUE = 7;
        public static readonly int FEEDBACK = 8;
    }
}
