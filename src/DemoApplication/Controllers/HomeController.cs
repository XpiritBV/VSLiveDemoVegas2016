using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication8.Controllers
{
//    [Route("pages/[controller]")]
    public class HomeController : Controller
    {
        private string _envName;

        public HomeController(IHostingEnvironment env)
        {
            this._envName = env.EnvironmentName;
        }

        public IActionResult Index([FromServices] ILoggerFactory factory)
        {
            ILogger logger = factory.CreateLogger<HomeController>();
            logger.LogInformation("Information from {0}", ActionContext.ActionDescriptor.Name);
            logger.LogDebug(1000, "Debug from {0}", ActionContext.HttpContext.Request.Path);
            return View();
        }

        public string Get()
        {
            return _envName;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
