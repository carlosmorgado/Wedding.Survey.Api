using FastEndpoints;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;
using Wedding.Survey.UseCases;
using Wedding.Survey.Web.Converters;
using Wedding.Survey.UseCases.SurveyAnswers.ListAll;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure();

var services = builder.Services;

services.AddInfrastructure();
services.AddHttpLogging(o => { });

services.AddCors();

services.AddFastEndpoints();
services
	.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(ListAllSurveyAnswersQuery))!));

var app = builder.Build();
app.UseHttpLogging();

app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseFastEndpoints(config =>
{
	config.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	config.Serializer.Options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	config.Serializer.Options.Converters.Add(new JsonEnumMemberStringEnumConverter());

    config.Endpoints.RoutePrefix = "api";
});

app.Run();
