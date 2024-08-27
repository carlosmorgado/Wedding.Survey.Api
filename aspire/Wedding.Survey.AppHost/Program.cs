var builder = DistributedApplication.CreateBuilder(args);

var mongodb = builder
	.AddMongoDB("wedding-survey", 52108)
	.AddDatabase("survey-answers");

builder.AddProject<Projects.Wedding_Survey_Web>("wedding-survey-web")
    .WithReference(mongodb);

builder.Build().Run();
