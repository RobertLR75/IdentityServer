var builder = DistributedApplication.CreateBuilder(args);

var identityservice = builder.AddProject<Projects.IdentityService>("identityservice");

builder.Build().Run();