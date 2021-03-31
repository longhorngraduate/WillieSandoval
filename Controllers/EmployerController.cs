using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Models;
using WillieSandoval_2_28_2021.ViewModels;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class EmployerController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public EmployerController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        // GET: Projects
        public IActionResult Index()
        {
            ViewData["Title"] = "Previous Employers";

            var viewModel = new EmployersViewModel();
            viewModel.Companies = _repoWrapper.Company.LoadEmployersOnly().AsEnumerable<Company>();

            return View(viewModel);
        }

    }
}
