﻿using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository;

namespace LAS_BACKEND_MAIN.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureCor(this IServiceCollection services)
        {
            services.AddCors(
                options => options.AddPolicy("CorsPolicy", builder => 
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
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
                option.Password.RequiredLength = 12;
                option.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
        }
    }
}
