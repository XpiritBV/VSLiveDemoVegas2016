using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApplication.Middleware;
using DemoApplication.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICounter, CounterService>();  // per request a new instance
            //services.AddScoped<ICounter,CounterService>();    // per HttpRequest a new instance
            //services.AddSingleton<ICounter,CounterService>(); // One instance per server
            //services.AddInstance<ICounter>(new CounterService());     // the added instance will be available as singleton...
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseTestDIScopes();
            app.Run(async (context) =>
            {

                var counter = context.RequestServices.GetService<ICounter>();
                counter.Count("request delegate 1st call");
                counter = context.RequestServices.GetService<ICounter>();
                counter.Count("request delegate 2nth call");
                counter = context.RequestServices.GetService<ICounter>();
                counter.Count("request delegate 3th call");
                var count = counter.GetCounterValue();
                var lastCall = counter.GetLastCallerName();

                await context.Response.WriteAsync($"Hello World! count= {count}, lastCall= {lastCall} \n");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
