﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using Newtonsoft.Json;

namespace GitHiredApi
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
            services.AddMvc(options =>
                {
                // Prevents infinite reference loops when we serialize objects linked to one another with navigation properties.
                //   solution found at: 
                // https://stackoverflow.com/questions/19467673/entity-framework-self-referencing-loop-detected/30203455
                    options.OutputFormatters.Clear();
                    options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    }, ArrayPool<char>.Shared));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddDbContext<GitHiredApiDbContext>( options => 
                  options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));


            

            services.AddSwaggerDocument();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();

            // Swagger UI middleware - facilitates using Swagger to generate documentation for our API as a GUI
            app.UseSwagger();
            app.UseSwaggerUi3();


        }
    }
}
