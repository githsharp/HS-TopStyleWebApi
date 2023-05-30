using HS_TopStyleWebApi.Repos.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using HS_TopStyleWebApi.Repos;
using System.Collections.Generic;
using HS_TopStyleWebApi.Controllers;
using HS_TopStyleWebApi.Extensions;


namespace HS_TopStyleWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
            //builder.Services.AddControllers();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProductContext>(
                options => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=TopStyle;Integrated Security=SSPI;TrustServerCertificate=True;")
                );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddSwaggerExtended();

            //builder.Services.AddSwaggerGen(options =>
            //{
            //    // generell konfig av Swagger

            //    options.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "HS_TopStyleWebApi extension method",
            //        Version = "v1"
            //    });
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseAuthorization();

            app.UseRouting();
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

//Att uppdatera eller skapa en databas utifrån en migration
//update-database