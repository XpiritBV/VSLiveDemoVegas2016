using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace DemoApplication.Middleware
{
    public class AddResponseTimingHeader
    {
        private RequestDelegate _next;

        public AddResponseTimingHeader(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using (var memoryBuffer = new MemoryStream())
            {
                var originalBody = context.Response.Body;
                context.Response.Body = memoryBuffer;

                var sw = new Stopwatch();
                sw.Start();

                await _next(context);

                if (context.Response.StatusCode == 200)
                {
                    {
                        memoryBuffer.Seek(0, SeekOrigin.Begin);
                        context.Response.Headers.Add("X-ElapsedTime", new[] { sw.ElapsedMilliseconds.ToString() });
                        await memoryBuffer.CopyToAsync(originalBody);
                    }
                }
            }
        }

    }

    public static class AddResponseTimeHeaderExtension
    {
        public static void UseResponseTimeHeader(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<AddResponseTimingHeader>();
        }
    }
}
