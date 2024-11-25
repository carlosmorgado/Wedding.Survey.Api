using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Microsoft.Extensions.Hosting;
public static class HostApplicationBuilderExtensions
{
	public static void AddInfrastructure(this IHostApplicationBuilder builder)
	{
		builder.AddMongoDbClient("MONGO_URL");
	}

    public static void AddMongoDbClient(
        this IHostApplicationBuilder builder,
        string connectionName)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionName, nameof(connectionName));

        if (Environment.GetEnvironmentVariable(connectionName) is not string connectionString)
        {
            throw new InvalidOperationException("No connection string found for non Development run.");
        }

        builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
    }
}
