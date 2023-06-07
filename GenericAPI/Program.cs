using System.ComponentModel.DataAnnotations;
using GenericApplication;
using GenericApplication.Features.Requests.Commands;
using GenericDomain.Services;
using GenericPersistence;
using GenericPersistence.DataAccess;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

var builder = WebApplication.CreateBuilder(args);

GlobalContext.Properties["webAppName"] = "http://localhost:5054";
builder.Logging.AddLog4Net();

builder.Services.ConfigureAppServices();
builder.Services.InitializeAutomapper();
builder.Services.PersistenceServices(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(CreateGuitarCommand).Assembly);
});

var connectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<GenericDbContext>(o =>
    o.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );

builder.Services.AddHostedService<TimedHostedService>();
foreach (var type in typeof(Program).Assembly.GetTypes().Where(x => 
             (x.Name.EndsWith("Handler") || x.Name.EndsWith("Pipeline")) 
             && !x.IsAbstract && !x.IsInterface))
{
    builder.Services.AddTransient(type);
}

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (ctx, next) =>
{
    try
    {
        await next();
    }
    catch(ValidationException ex)
    {
        await ctx.Response.WriteAsJsonAsync(ex);
    }
});

app.MapControllers();

app.Run();