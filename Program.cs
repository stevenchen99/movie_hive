using System.Net;
using dotenv.net;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using MovieHive.Data;
using MovieHive.Repositories;
using MovieHive.Repositories.Interfaces;
using MovieHive.Services.HealthChecks;

/* .ENV Loading */
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

/*** Add Configurations to the Container ***/
builder.Configuration.AddEnvironmentVariables();

/*** Configure Kestrel Endpoints ***/
builder.WebHost.UseKestrel(options =>
{
    int httpPort;
    if (builder.Environment.IsDevelopment())
    {
        httpPort = 5001;
        options.Listen(IPAddress.Loopback, httpPort); // Bind to localhost in development
    }
    else
    {
        httpPort = 8080;
        options.Listen(IPAddress.Any, httpPort); // Bind to any IP in production
    }
});

// Add services to the container.
builder
    .Services.AddHealthChecks()
    .AddDbContextCheck<AppDbContext>("MSSQL Health Check", HealthStatus.Unhealthy)
    .AddCheck<DbHealthCheck>("MSSQL Custom Health Check", HealthStatus.Unhealthy);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsProduction())
    {
        var server = Environment.GetEnvironmentVariable("MSSQL_DATABASE_SERVER");
        var port = Environment.GetEnvironmentVariable("MSSQL_DATABASE_PORT");
        var database = Environment.GetEnvironmentVariable("MSSQL_DATABASE_DATABASE");
        var username = Environment.GetEnvironmentVariable("MSSQL_DATABASE_USERNAME");
        var password = Environment.GetEnvironmentVariable("MSSQL_DATABASE_PASSWORD");

        var connectionString =
            $"Server={server},{port};Database={database};User ID={username};Password={password};Trusted_Connection=False;TrustServerCertificate=True";

        options.UseLazyLoadingProxies().UseSqlServer(connectionString);
    }

    if (builder.Environment.IsDevelopment())
    {
        options.UseLazyLoadingProxies().UseInMemoryDatabase("InMem");
    }
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieHive API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieHive API v1");
    });
}

// app.UseHttpsRedirection();

app.MapHealthChecks(
    "/health",
    new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }
);

app.UseAuthorization();

app.UseRouting();
app.UseCors("AllowAll");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

/*** Initial Data Seeding ***/
InitDB.Initialize(app, app.Environment.IsProduction());

app.Run();
