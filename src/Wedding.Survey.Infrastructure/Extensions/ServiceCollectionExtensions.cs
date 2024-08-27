using Wedding.Survey.Core;
using Wedding.Survey.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		ArgumentNullException.ThrowIfNull(services, nameof(services));

		services.AddDbContext<ISurveyContext, SurveyContext>();

		return services;
	}
}
