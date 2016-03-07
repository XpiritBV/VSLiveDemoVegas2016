using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoApplication.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApplication.Middleware
{
    public class TestDIScopes
    {
        private RequestDelegate _next;

        public TestDIScopes(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var counter = context.RequestServices.GetService<ICounter>();
            counter.Count("Called in DI Scope Tester");
            var count = counter.GetCounterValue();
            await context.Response.WriteAsync($"DI Scope Counter = {count}\n");
            await _next(context);
            count = counter.GetCounterValue();
            await context.Response.WriteAsync($"DI Scope Counter on return = {count}\n");


        }

    }

    public static class TestDIScopesExtension
    {
        public static void UseTestDIScopes(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<TestDIScopes>();
        }
    }
}
