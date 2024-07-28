using FlightAggregatorAPI.Data;
using FlightAggregatorAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Stl.Fusion;
using Stl.Fusion.Extensions;
using ZiggyCreatures.Caching.Fusion;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .Enrich.FromLogContext()
    .WriteTo.Console(new CustomJsonFormatter())
    .WriteTo.File(new CustomJsonFormatter(), "logs/logs.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.File(new CustomJsonFormatter(), "logs/error_.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Services.AddFusionCache()
     .WithDefaultEntryOptions(new FusionCacheEntryOptions
     {
         Duration = TimeSpan.FromMinutes(10)
     })
 ;

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddLogging(loggingBuilder =>
    loggingBuilder.AddSerilog(dispose: true));


builder.Services.AddDbContext<FlightContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var fusion = builder.Services.AddFusion();
fusion.AddFusionTime();

builder.Services.AddTransient<IFlightAggregatorService, FlightAggregatorService>();
builder.Services.AddTransient<ITicketNumberService, TicketNumberService>();
builder.Services.AddTransient<ITicketService, TicketService>();


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
