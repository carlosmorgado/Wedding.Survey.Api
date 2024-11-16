FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet nuget update source CarlosMorgado --username carlosmorgado --password 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

RUN dotnet workload restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Wedding.Survey.Web.dll"]
