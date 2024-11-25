using FastEndpoints;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;
using Wedding.Survey.UseCases;
using Wedding.Survey.Web.Converters;
using Wedding.Survey.UseCases.SurveyAnswers.ListAll;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure();

var services = builder.Services;

services.AddInfrastructure();

services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

services.AddFastEndpoints();
services
	.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(ListAllSurveyAnswersQuery))!));

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseFastEndpoints(config =>
{
	config.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	config.Serializer.Options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	config.Serializer.Options.Converters.Add(new JsonEnumMemberStringEnumConverter());
});

app.Run();
