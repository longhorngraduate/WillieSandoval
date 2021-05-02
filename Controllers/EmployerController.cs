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
        [Route("Employer/Index")]
        [Route("Employer/Index/{employeerId:int}")]
        public IActionResult Index(int? employeerId)
        {
            ViewData["Title"] = "Previous Employers";
            
            var viewModel = new EmployersViewModel();
            viewModel.Companies = _repoWrapper.Company.LoadEmployersOnly().AsEnumerable<Company>();

            Company myCompany = viewModel.Companies.FirstOrDefault(c => c.CompanyId == employeerId);
            if (myCompany == null)
            {
                myCompany = new Company();
                myCompany.Name = "";
            }
            viewModel.Company = myCompany;

            return View(viewModel);
        }

    }
}
