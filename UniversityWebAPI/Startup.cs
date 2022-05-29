using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Interfaces;
using University.Infrastructure.Data;
using University.Services.Interfaces;
using University.Services.Interfaces.University.Services;

namespace UniversityWebAPI
{
    public class Startup
    {
       
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<UniversityContext>();
                services.AddTransient<IStudentServices, StudentServices>();
                services.AddTransient<IStudentRepository, StudentRepository>();
                services.AddTransient<ILectionRepository, LectionRepository>();
                services.AddTransient<ILectionServices, LectionServices>();
                services.AddTransient<ILectorServices, LectorServices>();
                services.AddTransient<ILectorRepository, LectorRepository>();
                services.AddTransient<ILectionLectorsServices, LectionLectorsServices>();
                services.AddTransient<ILectionLectorsRepository, LectionLectorsRepository>();
                services.AddTransient<IAttendanceServices, AttendanceServices>();
                services.AddTransient<IAttendanceRepository, AttendanceRepository>();
                services.AddControllers(); // используем контроллеры без представлений
            }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();



            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
                });
        }




        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{

        //    services.AddControllers();
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversityWebAPI", Version = "v1" });
        //    });
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityWebAPI v1"));
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });
        //}
    }
}
