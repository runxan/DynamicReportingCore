using DynaimcReporting.Context;
using DynaimcReporting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DynaimcReporting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ReportContext db ;
        public HomeController(ILogger<HomeController> logger,ReportContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            var catList = db.Categories.ToList();
            return View(catList);
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
