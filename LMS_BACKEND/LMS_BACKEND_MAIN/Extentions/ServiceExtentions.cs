using Contracts.Interfaces;
using Entities.ConfigurationModels;
using Entities.Models;
using LoggerServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service;
using Service.Contracts;
using System.Net.Mail;
using System.Net;
using System.Text;
using Amazon.S3;
using Amazon;
using System.Security.Claims;
using Microsoft.AspNetCore.Diagnostics;
using Shared.DataTransferObjects.ResponseDTO;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using LMS_BACKEND_MAIN.Presentation.Controllers;
using Marvin.Cache.Headers;

namespace LMS_BACKEND_MAIN.Extentions
{
    public class CorsConfig
    {
        public string[]? Origins { get; set; }
    }
    public static class ServiceExtentions
    {
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }
        public static void ConfigureCor(this IServiceCollection services, IConfiguration configuration)
        {
            var corsConfig = new CorsConfig();

            configuration.GetSection("CorsConfig").Bind(corsConfig);

            services.AddCors(
                options => options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins(corsConfig.Origins ?? throw new NullReferenceException("Not found corsConfig"))
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"))
                );
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<Account, IdentityRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequiredLength = 8;
                option.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
            var secretKey = Environment.GetEnvironmentVariable("SECRET") ?? "#";
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    RoleClaimType = ClaimTypes.Role
                };
            });
        }
        public static void ConfigureSmtpClient(this IServiceCollection services)
        {
            services.AddTransient<SmtpClient>(serviceProvider =>
            {
                var hold = Environment.GetEnvironmentVariable("EMAILADMIN") ?? throw new InvalidOperationException("EMAILADMIN environment variable not set.");
                string[] parts = hold.Split('/');
                if (parts.Length != 4)
                {
                    throw new InvalidOperationException("Invalid EMAILADMIN environment variable format.");
                }

                string _gmailsend = parts[0];
                string _gmailpassword = parts[1];
                int _port = Convert.ToInt32(parts[2]);
                string _apppassword = parts[3];

                var client = new SmtpClient("smtp.gmail.com", _port)
                {
                    Credentials = new NetworkCredential(_gmailsend, _apppassword),
                    EnableSsl = true
                };

                return client;
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services) =>
                services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
        public static void ConfigureResponseCaching(this IServiceCollection services) =>
            services.AddResponseCaching();
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services) =>
            services.AddHttpCacheHeaders(
                (expirationOpt) =>
                {
                    expirationOpt.MaxAge = 120;
                    expirationOpt.CacheLocation = CacheLocation.Private;
                },
                    (validationOpt) =>
                    {
                        validationOpt.MustRevalidate = true;
                    });
        public static void ConfigureAwsS3(this IServiceCollection services, IConfiguration configuration)
        {//nho chay app setup truoc khi release phai sua phan encryptionkey vaf iv nay

            //Comment dong code nay lai truoc khi build app

            // tu day

            //var encryptionKey = Environment.GetEnvironmentVariable("EncryptionKey");


            //var iv = Environment.GetEnvironmentVariable("ivKey");

            //var awsOptions = configuration.GetAWSOptions("AWS");

            //var url = Environment.GetEnvironmentVariable("SERVICE_URL");

            //awsOptions.Region = RegionEndpoint.USEast1; // Use auto region

            //var holdAccess = Environment.GetEnvironmentVariable("ENCRYPTED_ACCESS_KEY");

            //var holdSecret = Environment.GetEnvironmentVariable("ENCRYPTED_SECRET_KEY");

            //if (holdAccess == null || holdSecret == null || encryptionKey == null || iv == null || url == null)
            //    throw new InvalidOperationException("environment variable not set.");

            //awsOptions.Credentials = new Amazon.Runtime.BasicAWSCredentials(
            //    Decrypter.DecryptString(holdAccess, encryptionKey, iv),
            //    Decrypter.DecryptString(holdSecret, encryptionKey, iv)
            //);
            //awsOptions.DefaultClientConfig.ServiceURL = Decrypter.DecryptString(url, encryptionKey, iv);

            //services.AddDefaultAWSOptions(awsOptions);

            //Den day

            services.AddAWSService<IAmazonS3>();

            services.AddScoped<IFileService, FileService>();
        }
    }
}