using Microsoft.OpenApi.Models;


namespace HS_TopStyleWebApi.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtended(this IServiceCollection Services)
        {
            //här extendar vi swagger med att lägga till en ny metod
            Services.AddSwaggerGen(options =>
            {
                // generell konfig av Swagger

                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "HS_TopStyleWebApi extension method", Version = "v1" 
                });
                //konfiguration av säkerhet i Swagger  -
                // ******* FYLL PÅ SENARE ********
            });

            return Services;
        }
        public static IApplicationBuilder AddSwaggerExtended(this IApplicationBuilder app)
        {
            //här extendar vi swagger med att lägga till en ny metod
            // konfig kopplat till applicationBuilder

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "HS_TopStyleWebApi extension method");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
