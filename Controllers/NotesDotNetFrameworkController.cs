using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class NotesDotNetFrameworkController : Controller
    {
        public IActionResult DifferencesBetweenFrameworks()
        {
            ViewData["Title"] = "Differences Between Frameworks";
            return View();
        }

        public IActionResult CommandLineInterface()
        {
            ViewData["Title"] = "Command Line Interface";
            return View();
        }

        public IActionResult DotNETMVCsFolderAndFiles()
        {
            ViewData["Title"] = "ASP.NET MVC's Folder and Files";
            return View();
        }

        public IActionResult UnitTesting()
        {
            ViewData["Title"] = "Unit Testing";
            return View();
        }

        public IActionResult CSharp()
        {
            ViewData["Title"] = "C#";
            return View();
        }

        public IActionResult DataStructures()
        {
            ViewData["Title"] = "Data Structures";
            return View();
        }

        public IActionResult Inheritance()
        {
            ViewData["Title"] = "Inheritance";
            return View();
        }

        public IActionResult DesignPatterns()
        {
            ViewData["Title"] = "Design Patterns";
            return View();
        }
    }
}
