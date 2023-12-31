using Microsoft.OpenApi.Models;
using SuperSimpleSchedulingSystem.Configuration;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Logic.Managers;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Presentation.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

// Add Cross-Origin Resource Sharing configuration

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

// Add Database and Configuration settings

builder.Services.AddDbContext<DBContext>();
builder.Services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();

// Add Managers and UnitOfWork

builder.Services.AddTransient<IClassManager, ClassManager>();
builder.Services.AddTransient<IStudentManager, StudentManager>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<ILoginManager, LoginManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add AutoMapper configuration

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Controller and JSON serialization configuration

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Add Swagger/OpenAPI configuration

builder.Services.AddEndpointsApiExplorer();
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

    var file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, file);
    options.IncludeXmlComments(filePath);

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
