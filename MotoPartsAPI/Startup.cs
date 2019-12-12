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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MotoPartsAPI.Interfaces;
using MotoPartsAPI.Models;

namespace MotoPartsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public readonly string PolicyName = "MotoParts API";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //the dependency injection goes here 
            services.AddControllers();

            //To create this in package manager console in Tools-> NugetPackageMAnager enter in this connection string below or another one  with Output Dir-Models or anyname for an Output Directory or folder
            //Scaffold-DbContext "Server=tcp:cloud22.database.windows.net,1433;Initial Catalog=MotoParts;Persist Security Info=False;User ID=cloud22;Password=Lighthouse44;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


            //so then all you do is right click the controllers folder choose api controller using entity framework select your actual Context class not the one connected to the interface for dependency injection then you need
            //to change it to inject the interface into the controllers constructor
            //entity framework core makes this way easier 
            //but .net framework will require you to use an IOC container like Unity which is the best one because it looks like that service descriptor below a little.



            //the parts controller contains the dependency injection you can set up the rest and try it out. this particular type of DI only is for DB Context classes


            services.AddDbContext<MotoPartsContext>(options =>options.UseSqlServer("Server=tcp:cloud22.database.windows.net,1433;Initial Catalog=MotoParts;Persist Security Info=False;User ID=cloud22;Password=Lighthouse44;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            //The Dependency injection typeof is the partner of generic T says that this interface is the same as this class so there is no need for instantiation check out the controllers injecting
            services.Add(new ServiceDescriptor(typeof(IDbContext), new Interfaces.DbContext()));



            //You need this Cors stuff it gets more specific the more secure you want to make your API but this regulates access to the API 
            //I have just allowed anything its a fake database anyway
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName,
                    builder =>
                    {

                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
