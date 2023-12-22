using Microsoft.OpenApi.Models;
using SuperSimpleSchedulingSystem.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

// Add CORS properties

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithExposedHeaders("Authorization")
    );
});

// Add services to the container.

builder.Services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Super Simple Scheduling System - API",
        Description = "An ASP.NET Core Web API for Super Simple Scheduling System challenge",
        Contact = new OpenApiContact
        {
            Name = "Rodrigo Heredia",
            Url = new Uri("https://github.com/RodrigoH12")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
