using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.ViewModels;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class SampleCodeSQL : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomPagination()
        {
            ViewData["Title"] = "Custom Pagination";

            SampleCodeSQLViewModel oSQLVM = new SampleCodeSQLViewModel();

            return View(oSQLVM);
        }

        public IActionResult AdvancedQuery()
        {
            ViewData["Title"] = "Advanced Query";

            SampleCodeSQLViewModel oSQLVM = new SampleCodeSQLViewModel();

            return View(oSQLVM);
        }

    }
}
