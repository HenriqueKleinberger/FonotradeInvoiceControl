using FonotradeInvoiceControl;
using FonotradeInvoiceControl.VHSYS.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace FonotradeInvoiceControlTest.Utils
{
	public class StartupMock : Startup
	{
		private IVHSYSService _vhsysService { get; set; }

		public StartupMock(IVHSYSService vhsysClientService)
		{
			_vhsysService = vhsysClientService;

			var configurationBuilder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();

			Configuration = configurationBuilder.Build();
		}

		public override void ConfigureClients(IServiceCollection services)
		{
			services.AddSingleton(_vhsysService);
		}

		public override void SetConfig(IServiceCollection services)
		{
			var configurationBuilder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true);

			Configuration = configurationBuilder.Build();

			services.AddSingleton<IConfiguration>(provider => Configuration);
		}
	}
}