using Microsoft.Extensions.DependencyInjection;
using FonotradeInvoiceControl.BLL;
using FonotradeInvoiceControl.BLL.Interfaces;
using FonotradeInvoiceControl.VHSYS.Services;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;

namespace FonotradeInvoiceControl.Utils
{
    public static class DependencyInjector
    {
        public static void InjectCommonDependencies(IServiceCollection services)
        {
            services.AddScoped<IVHSYSService, VHSYSService>();
            services.AddScoped<IVHSYSClientService, VHSYSClientService>();
            services.AddScoped<IInvoiceBLL, InvoiceBLL>();
            services.AddScoped<IVHSYSInvoiceService, VHSYSInvoiceService>();
        }
    }
}
