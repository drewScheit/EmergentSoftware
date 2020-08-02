using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmergentSoftware.Models;

namespace EmergentSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                string newVersion = SoftwareManager.FillSoftwareVersion(SearchString);
                IEnumerable<Software> softwares = SoftwareManager.GreaterSoftwareVersion(SoftwareManager.GetAllSoftware(), newVersion);

                return View(new SoftwareList { softwares = softwares });
            }

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
