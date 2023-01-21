using AutoMapper;

using System.Configuration;

using Microsoft.OpenApi.Models;
using Library.Data.DataDBContext;
using Microsoft.EntityFrameworkCore;
using Library.Service.Interfaces.IServ;
using Library.Service.Services.Serv;
using MatriculasIglesia.Mapper;
using Library.Repository.Interfaces;
using Library.Data.Repositories;
using Library.Data.Interfaces;
using FluentValidation.AspNetCore;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace MatriculasIglesia.IoC
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            AddRegisterDataContext(services, configuration);
            AddRegisterServices(services, configuration);
            AddRegisterRepositories(services);
            AddRegisterDomainServices(services);
            AddRegisterPolicies(services);
            AddServices(services);

            //Add services to validation
            services.AddFluentValidation(s =>
            {
                s.RegisterValidatorsFromAssemblyContaining<Program>();
            });

            return services;
        }

        public static IServiceCollection AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(MappingProfile.GetProfiles());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }

        public static IApplicationBuilder AddRegistration(WebApplication app, IWebHostEnvironment env)
        {
           
            
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseSwagger();
            //app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            return app;
        }

        public static IServiceCollection AddRegisterDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringSection = configuration.GetSection("ConnectionStrings:DataContext");

            services.Configure<ConnectionStringSettings>(connectionStringSection);
            var connectionString = connectionStringSection.Value;

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString: connectionString));

            return services;
        }

        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRegisterDomainServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            return services;
        }

        public static IServiceCollection AddRegisterPolicies(this IServiceCollection services)
        {
            // Agregando las Politicas para la autorizacion           
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Agregando services
            services.AddTransient<IIglesiaService, IglesiaService>();
            // Add services to the container. For use for PDF
            services.AddSingleton(typeof(IConverter),
                new SynchronizedConverter(new PdfTools()));
            return services;
        }
    }
}