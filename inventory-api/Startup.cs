using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using AutoMapper;

using inventoryapi.Persistence.Contexts;
using inventoryapi.Domain.Repositories;
using inventoryapi.Domain.Services;
using inventoryapi.Persistence.Repositories;
using inventoryapi.Services;
using inventoryapi.Domain.Models;

namespace quickcommerce_api
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("api-in-memory");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITagService, TagService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
