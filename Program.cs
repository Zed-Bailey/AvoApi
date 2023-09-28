using AvoApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<AvocadoContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString(nameof(AvocadoContext)));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Avo Api",
            Version = "v1"
        }
    );
    
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await using var context = scope.ServiceProvider.GetRequiredService<AvocadoContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var dataFilePath = configuration.GetValue<string>("DataFilePath");
    
    try
    {
        if (dataFilePath == null) throw new Exception("Could not find data file path in appsettings.json");
     
        await DbSeeder.SeedDb(context, dataFilePath);
    }
    catch (Exception e)
    {
        logger.LogCritical("An error occured while trying to seed the DB, {Exception}",e);
        return;
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
