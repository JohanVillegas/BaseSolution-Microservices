using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Item.API.Infrastructure;
using Item.Application.Commands;
using Item.Application.Validations;
using Item.Domain.AggregatesModel.ItemAggregate;
using Item.Infrastructure;
using Item.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
namespace Item.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add MediatR
            var assembly = AppDomain.CurrentDomain.Load("Item.Application");
            services.AddMediatR(assembly);

            // Add FluentValidation
            services.AddMvc().AddFluentValidation();

            // Add DbContext using SQL Server Provider
            services.AddDbContext<ItemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NowDatabase")));

            // Add Repositories
            services.AddScoped<IItemRepository, ItemRepository>();

            // Add Validations
            services.AddTransient<IValidator<CreateItemMasterCommand>, CreateItemMasterCommandValidator>();

            // Add Exception Control Filter.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                            //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });


            app.UseMvc();
        }

    }
}
