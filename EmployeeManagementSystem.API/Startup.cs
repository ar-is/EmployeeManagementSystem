using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagementSystem.API.Helpers.Extension_Methods;
using EmployeeManagementSystem.API.Infrastructure.DbContexts;
using EmployeeManagementSystem.API.Core.Helpers.MappingProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using EmployeeManagementSystem.API.Utils.VendorMediaTypes;
using EmployeeManagementSystem.API.Core.Interfaces.Services;

namespace EmployeeManagementSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(setupAction =>
                {
                    setupAction.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ReferenceLoopHandling =
                                        ReferenceLoopHandling.Ignore;
                    setupAction.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setupAction =>
                {
                    setupAction.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "https://ems.com/modelvalidationproblem",
                            Title = "One or more validation errors occured.",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "See the errors property for details.",
                            Instance = context.HttpContext.Request.Path
                        };

                        problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { MediaTypes.ProblemPlusJson }
                        };
                    };
                });

            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters
                      .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

                newtonsoftJsonOutputFormatter?.SupportedMediaTypes
                    .Add(MediaTypes.HateoasPlusJson);
            });

            services.AddDbContext<EMSDbContext>(options =>
            {
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EMSApiDb;Trusted_Connection=True;");
            });

            services.AddAutoMapper(typeof(SkillsProfile).Assembly);

            services.AddCustomServices(Configuration);

            //services.AddAutoMapper(typeof(Startup));

            //services.AddScoped(provider => new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new JobSkillsProfile(provider.GetService<IUnitOfWork>()));
            //    cfg.AddProfile(new JobsProfile());
            //    cfg.AddProfile(new SkillsProfile());
            //}).CreateMapper());

            //services.AddAutoMapper(typeof(SkillsProfile), typeof(JobsProfile));

            //services.AddScoped(provider => new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new JobsProfile());
            //}).CreateMapper());

            //services.AddScoped(provider => new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new SkillsProfile());
            //}).CreateMapper());

            


            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            services.AddCors(options =>
            {
                options.AddPolicy("LocalHostPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44375")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");

                        // we can also log this fault
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("LocalHostPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
