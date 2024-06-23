using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Entities.Models;
using LMS_BACKEND_MAIN.Extentions;
using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using Repository;
using Servive.Hubs;

var builder = WebApplication.CreateBuilder(args);
var logger = NLog.LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

var connectionString = builder.Configuration.GetConnectionString("LemaoString") ?? throw new InvalidOperationException("Connection string 'Cnn' not found.");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.ConfigureRepositoryManager();

builder.Services.AddSignalR();

builder.Services.ConfigureAwsS3(builder.Configuration);

builder.Services.ConfigureServiceManager();

builder.Services.ConfigureCor();

builder.Services.AddMemoryCache();

builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSmtpClient();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddControllers().AddApplicationPart(typeof(LMS_BACKEND_MAIN.Presentation.AssemblyReference).Assembly);

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminorsupervisor", policy => policy.RequireRole("labadmin", "supervisor"));
    options.AddPolicy("admin", policy => policy.RequireRole("labadmin"));
    options.AddPolicy("supervisor", policy => policy.RequireRole("supervisor"));
});

builder.Services.ConfigureIdentity();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

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

app.MapHub<NotificationHub>("/notifyHub");

app.Run();
