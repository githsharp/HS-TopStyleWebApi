using HS_TopStyleWebApi.Repos.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using HS_TopStyleWebApi.Repository.Repos;
//using HS_TopStyleWebApi.Extensions;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HS_TopStyleWebApi.Services.Authentication;
using HS_TopStyleWebApi.Repository.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Configuration;
using HS_TopStyleWebApi.DTOs.OrderDTOs;
using HS_TopStyleWebApi.DTOs.ProductDTOs;
using HS_TopStyleWebApi.DTOs.UserDTOs;
using HS_TopStyleWebApi.Services;
using HS_TopStyleWebApi.Repos;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using HS_TopStyleWebApi.Controllers;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace HS_TopStyleWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //    .AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            //});

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            //builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            //builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            //builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));

            // här sätts tjänsten upp som kan injectas
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ProductContext>()
                .AddDefaultTokenProviders();

            //builder.Services.AddTransient<IProductRepository, ProductRepository>();
            //builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            //builder.Services.AddTransient<IUserRepository, UserRepository>();
            ////builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            //var jwtSettings = new JwtSettings();
            //builder.Services.AddSingleton(Options.Create(jwtSettings));
            //builder.Configuration.Bind(JwtSettings.SectionName, jwtSettings);

            //builder.Services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //});

            //builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        //ValidIssuer = jwtSettings.Issuer,
            //        ValidIssuer = "http://localhost:5111/",
            //        //ValidAudience = jwtSettings.Audience,
            //        ValidAudience = "http://localhost:5111/",
            //        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretKey12345!#"))
            //    });

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Skriv in bearer för att kunna anropa api:et.. Exempel: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey

                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();

            });

            if (builder.Environment.IsProduction())
            {
                var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
                var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
                var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
                var keyVaultDirectoryID = builder.Configuration.GetSection("KeyVault:DirectoryID");

                var credential = new ClientSecretCredential(keyVaultDirectoryID.Value!.ToString(), keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString());

                builder.Configuration.AddAzureKeyVault(keyVaultURL.Value!.ToString(), keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString(), new DefaultKeyVaultSecretManager());

                var client = new SecretClient(new Uri(keyVaultURL.Value!.ToString()), credential);

                builder.Services.AddDbContext<ProductContext>(options =>
                {
                    options.UseSqlServer(client.GetSecret("ProdConnection").Value.Value.ToString());
                });

            }

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<ProductContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(endpoint =>
                {
                    endpoint.SwaggerEndpoint("/swagger/v1/swagger.json", "HS-TopStyleWebApi v1");
                });
            }

            app.UseHttpsRedirection();

            //Detta skall göras innan routingen kopplas på
            app.UseAuthentication();


            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }

}

//Detta kommando lägger en migration i en speciell mapp som vi styr 
//add-migration createHS-TopStyle -o Repos\Migrations
//add-migration update-o Repos\Migrations

//Att uppdatera eller skapa en databas utifrån en migration
//update-database

//add-migration updateHS-TopStyle -o Repos\Migrations
//update-database

//add-migration updateSQLHS-TopStyle -o Repos\Migrations
//update-database

//add-migration updateAuthHS-TopStyle -o Repos\Migrations
//update-database