using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Infrastructure;
using WebApi.Validation;

namespace WebApi
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup( IConfiguration config )
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers( ).AddNewtonsoftJson( options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new OpenApiInfo { Title = "WebApi", Version = "v1" } );
            } );

            // IoC 
            services.AddDbContext<MovieApiDbContext>( opt =>
            {
                opt.UseSqlServer( _config.GetConnectionString( "DefaultConnection" ) );
            } );

            services.AddScoped<MovieRepository, MovieRepository>( );
            services.AddScoped<ReviewRepository, ReviewRepository>( );
            services.AddScoped<Repository, Repository>( );
            services.AddScoped<ReviewValidationService, ReviewValidationService>( );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
                app.UseSwagger( );
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "WebApi v1" ) );
            }

            app.UseHttpsRedirection( );

            app.UseRouting( );

            app.UseCors( builder =>
            {
                builder.AllowAnyOrigin( );
                builder.AllowAnyHeader( );
                builder.AllowAnyMethod( );
            } );

            app.UseAuthorization( );

            app.UseEndpoints( endpoints => { endpoints.MapControllers( ); } );
        }
    }
}