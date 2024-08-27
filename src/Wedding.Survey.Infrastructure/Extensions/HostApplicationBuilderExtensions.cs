namespace Microsoft.Extensions.Hosting;
public static class HostApplicationBuilderExtensions
{
	public static void AddInfrastructure(this IHostApplicationBuilder builder)
	{
		builder.AddMongoDbClient("survey-answers");
	}
}
