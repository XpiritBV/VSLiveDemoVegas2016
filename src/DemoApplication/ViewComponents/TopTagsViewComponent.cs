using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApplication.Services;
using Microsoft.AspNet.Mvc;

namespace DemoApplication
{
   

    public class TopSessionsViewComponent : ViewComponent
    {
        private ISessionListService service;

        public TopSessionsViewComponent(ISessionListService service)
        {
            this.service = service;
        }

        public IViewComponentResult Invoke()
        {
            return View(service.GetTop20Sessions());
        }
    }

    
}
