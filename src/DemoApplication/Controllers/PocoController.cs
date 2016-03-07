using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.Net.Http.Headers;


namespace DemoApplication.Controllers
{
    public class PocoController
    {
        
        public IActionResult Index2()
        {
            ContentResult result = new ContentResult
            {
                ContentType = MediaTypeHeaderValue.Parse("text/html"),
                Content =
                    "<html><head><title>Poco</title></head><body><h2>This is plain text we return from a poco controller....</h2></body>,<html>"
            };
            return result;
        }

        [Route("api/[controller]")]
        public IActionResult IndexJson()
        {

            var resultJson = new JsonHelper(new JsonOutputFormatter()).Serialize(
                new Customer() {Name = "Marcel", Address = "Kerkhofweg 12", Age = "44", PostalCode = "7231RJ"});

            ContentResult result = new ContentResult
            {
                ContentType = MediaTypeHeaderValue.Parse("application/json"),
                Content = resultJson.ToString()
            };

            return result;
        }

    }

    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Age { get; set; }

    }
}
