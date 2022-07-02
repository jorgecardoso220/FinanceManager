using FinanceManager.Application.Common.Interfaces.Authentication;
using FinanceManager.Application.Common.Interfaces.Persistence;
using FinanceManager.Application.Common.Interfaces.Services;
using FinanceManager.Infrastructure.Authentication;
using FinanceManager.Infrastructure.Persistence;
using FinanceManager.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		ConfigurationManager configuration)
	{
		services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

		services.AddScoped<IUserRepository, UserRepository>();
		return services;
	}
}