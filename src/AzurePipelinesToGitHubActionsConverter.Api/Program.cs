using Microsoft.AspNetCore.Mvc;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using AzurePipelinesToGitHubActionsConverter.Api;


var builder = WebApplication.CreateBuilder(args);

// Add YAML formatters (using our custom extension)
builder.Services.AddControllers()
    .AddYamlFormatters(); // Simple call without options

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
