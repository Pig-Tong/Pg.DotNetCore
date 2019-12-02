using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppingSettingReadDemo.Models;
using Microsoft.Extensions.Configuration;
using AppingSettingReadDemo.Config;
using Microsoft.Extensions.Options;

namespace AppingSettingReadDemo.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        private IOptionsMonitor<Database> _database;

        public HomeController (IConfiguration configuration, IOptionsMonitor<Database> database)
        {
            this.Configuration = configuration;
            this._database = database;
        }

        public IActionResult Index()
        {
            string str1 = Configuration["option1"];
            string str2 = Configuration["database:Name"];
            string str3 = Configuration["option2:suboption2:subkey2"];
            string str4Name = Configuration["students:0:Name"];
            string str4Age = Configuration["students:0:Age"];
            string str5Name = Configuration["students:1:Name"];

            ViewBag.Value1 = str1;
            ViewBag.Value2 = str2;
            ViewBag.Value3 = str3;
            ViewBag.Name1 = str4Name;
            ViewBag.Age1 = str4Age;
            ViewBag.Name2 = str5Name;

            Database db = _database.CurrentValue;//通过注入对象的 Value属性得到Database实例对象
            ViewBag.Database = $"server:{db.Server},name:{db.Name}";

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
