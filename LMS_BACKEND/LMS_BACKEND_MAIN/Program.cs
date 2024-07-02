using LMS_BACKEND_MAIN.Extentions;
using LMS_BACKEND_MAIN.Presentation.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using Repository;
using Servive.Hubs;
using LMS_BACKEND_MAIN.Configurations;
using Contracts.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config")).GetCurrentClassLogger();

var connectionString = builder.Configuration.GetConnectionString("LemaoString") ?? throw new InvalidOperationException("Connection string 'Cnn' not found.");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.ConfigureRepositoryManager();

builder.Services.AddSignalR();

builder.Services.ConfigureAwsS3(builder.Configuration);

builder.Services.ConfigureServiceManager();

builder.Services.ConfigureCor(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSmtpClient();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.ConfigureResponseCaching();

builder.Services.ConfigureHttpCacheHeaders();

builder.Services.AddControllers(
    config =>
        {
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
            config.CacheProfiles.Add("2MinsDuration", new CacheProfile { Duration = 120 });
        }
    ).AddApplicationPart(typeof(LMS_BACKEND_MAIN.Presentation.AssemblyReference).Assembly);

builder.Services.AddTransient<IConfigureOptions<MvcOptions>, MvcOptionsSetup>();

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

var log = app.Services.GetRequiredService<ILoggerManager>();

app.ConfigureExceptionHandler(log);

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

app.UseHttpCacheHeaders();

app.UseResponseCaching();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notifyHub");

app.Run();
