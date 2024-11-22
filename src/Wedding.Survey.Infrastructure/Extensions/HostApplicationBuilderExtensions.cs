using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Microsoft.Extensions.Hosting;
public static class HostApplicationBuilderExtensions
{
	public static void AddInfrastructure(this IHostApplicationBuilder builder)
	{
		builder.AddMongoDbClient("survey-answers");
	}

    public static void AddMongoDbClient(
        this IHostApplicationBuilder builder,
        string connectionName)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionName, nameof(connectionName));

        if (Environment.GetEnvironmentVariable(connectionName) is not string connectionString)
        {
            connectionString = "mongodb+srv://carlos:PZVLpOL3mwrcyCJZ@weddingsurveyanswers.tg9of.mongodb.net/?retryWrites=true&w=majority&appName=weddingSurveyAnswers";
            //throw new InvalidOperationException("No connection string found for non Development run.");
        }

        builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
    }
}
