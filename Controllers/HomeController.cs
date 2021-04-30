using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private IRepositoryWrapper _repoWrapper;

        public HomeController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Me";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }

        public IActionResult PastProjects()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            var projects = _repoWrapper.Project.FindAll();//.FindByCondition(x => x.ProjectType.Equals("Domestic"));

            return projects.AsEnumerable<Project>();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            //return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
