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
            services.AddScoped<IRegisterInvoiceBLL, RegisterInvoiceBLL>();
            services.AddScoped<IVHSYSInvoiceService, VHSYSInvoiceService>();
            services.AddScoped<IVHSYSClientService, VHSYSClientService>();
        }
    }
}
