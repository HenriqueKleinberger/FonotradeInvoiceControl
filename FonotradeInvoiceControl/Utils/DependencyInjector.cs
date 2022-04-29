using Microsoft.Extensions.DependencyInjection;
using FonotradeInvoiceControl.BLL;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.VHSYS.Services;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using FonotradeInvoiceControl.Clients;
using FonotradeInvoiceControl.Clients.Interface;

namespace FonotradeInvoiceControl.Utils
{
    public static class DependencyInjector
    {
        public static void InjectCommonDependencies(IServiceCollection services)
        {
            services.AddScoped<IRegisterInvoiceBLL, RegisterInvoiceBLL>();
            services.AddScoped<IIssueInvoiceBLL, IssueInvoiceBLL>();
            services.AddScoped<IVHSYSRegisterInvoiceService, VHSYSRegisterInvoiceService>();
            services.AddScoped<IVHSYSIssueInvoiceService, VHSYSIssueInvoiceService>();
            services.AddScoped<IVHSYSClientService, VHSYSClientService>();
            services.AddTransient<IVHSYSClient, VHSYSClient>();
        }
    }
}
