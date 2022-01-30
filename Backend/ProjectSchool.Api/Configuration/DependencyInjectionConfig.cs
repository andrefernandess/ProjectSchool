using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectSchool.Application.Helpers;
using ProjectSchool.Application.Interfaces;
using ProjectSchool.Application.Services;
using ProjectSchool.Persistence.Context;
using ProjectSchool.Persistence.Interfaces;
using ProjectSchool.Persistence.Repository;

namespace ProjectSchool.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new ProjectSchoolProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

        }
    }
}