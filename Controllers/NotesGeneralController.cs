using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class NotesGeneralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DevelopmentLifeCycle()
        {
            ViewData["Title"] = "Development Life Cycle";
            return View();
        }

        public IActionResult APM()
        {
            ViewData["Title"] = "APM (Application Performance Monitoring)";
            return View();
        }
    }
}
