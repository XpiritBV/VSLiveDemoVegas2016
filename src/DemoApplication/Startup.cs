using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApplication
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

                   
            app.UseIISPlatformHandler();
            
            
            // Set up configuration providers.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("MyConfiguration.json")
                .AddJsonFile($"MyConfiguration.{_env.EnvironmentName}.json", optional: true);
            
            builder.AddEnvironmentVariables();
            var config = builder.Build();
        
            
            var connectionString = config["Data:DefaultConnection:ConnectionString"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"ConnectionString: {connectionString}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
