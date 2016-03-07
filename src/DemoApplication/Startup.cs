using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoApplication.Middleware;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {


            app.UseIISPlatformHandler();

            //app.Map("/timed/show", (builder) =>
            //{
            //    builder.UseMiddleware<AddResponseTimingHeader>();
            //    // or 
            //    // builder.UseResponseTimeHeader();

            //    builder.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Hello timed World!");
            //    });
            //});


            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("X-MyCustomHeader", new[] { "someText" });

            //    await next();
            //});



            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
