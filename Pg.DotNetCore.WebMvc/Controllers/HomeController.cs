using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pg.DotNetCore.WebMvc.Models;
using Pg.DotNetCore.WebMvc.Services;
using Microsoft.Extensions.DependencyInjection; 

namespace Pg.DotNetCore.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private IServiceProvider _provider;

        private ICount _count;

        public HomeController(ICount count, IServiceProvider provider)
        {
            this._count = count;
            this._provider = provider;
        }

        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }



        public IActionResult Index()
        {
            ICount count1 = _provider.GetService<ICount>();
            ICount count2 = _provider.GetService<ICount>();
            int c1 = count1.MyCount();
            int c2 = count2.MyCount();

            ViewBag.c1 = c1;
            ViewBag.c2 = c2;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
