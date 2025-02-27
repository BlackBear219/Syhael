var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Syhael>("syhael");

builder.Build().Run();
