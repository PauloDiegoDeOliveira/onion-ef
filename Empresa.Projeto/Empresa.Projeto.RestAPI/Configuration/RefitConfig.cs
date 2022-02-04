using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using Microsoft.Extensions.Configuration;
using Empresa.Projeto.Application.Interfaces;

namespace Empresa.Projeto.RestAPI.Configuration
{
	public static class RefitConfig
	{
		public static void AddRefitConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddRefitClient<IApplicationCorreios>().ConfigureHttpClient(c =>
			{
				c.BaseAddress = new Uri(configuration.GetSection("ExternalApiUrls:CorreiosUrl").Value);
			});
		}
	}
}
