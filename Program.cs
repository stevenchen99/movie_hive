using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MovieHive.Data;
using dotenv.net;

/* .ENV Loading */
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>{

    var server = Environment.GetEnvironmentVariable("MSSQL_DATABASE_SERVER");
    var port = Environment.GetEnvironmentVariable("MSSQL_DATABASE_PORT");
    var database = Environment.GetEnvironmentVariable("MSSQL_DATABASE_DATABASE");
    var username = Environment.GetEnvironmentVariable("MSSQL_DATABASE_USERNAME");
    var password = Environment.GetEnvironmentVariable("MSSQL_DATABASE_PASSWORD");

    options.UseSqlServer(
        $"Server={server},{port};Database={database};User ID={username};Password={password};Trusted_Connection=False;TrustServerCertificate=True"
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

app.UseAuthorization();

app.MapControllers();

app.Run();
