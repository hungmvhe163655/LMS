using Entities.Models;
using LAS_BACKEND_MAIN.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using Repository;

var builder = WebApplication.CreateBuilder(args);

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));


var connectionString = builder.Configuration.GetConnectionString("LemaoString") ?? throw new InvalidOperationException("Connection string 'LemaoString' not found.");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity services
/*
builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();
*/
// Custom services config

builder.Services.ConfigureCor();

builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();


builder.Services.AddControllers();

builder.Services.AddAuthentication();

builder.Services.ConfigureIdentity();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
