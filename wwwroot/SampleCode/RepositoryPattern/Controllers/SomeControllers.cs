using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class HomeController : Controller
    {
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
        public IEnumerable&lt;Project> Get()
        {
            var projects = _repoWrapper.Project.FindAll();//.FindByCondition(x => x.ProjectType.Equals("Domestic"));

            return projects.AsEnumerable&lt;Project>();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Models;
using WillieSandoval_2_28_2021.ViewModels;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class ProjectsController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public ProjectsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        // GET: Projects
        [Route("Projects/Index")]
        [Route("Projects/Index/{projectId:int}")]
        public IActionResult Index(int? projectId)
        {
            ViewData["Title"] = "Projects";

            var viewModel = new ProjectsIndexDataViewModel();
            viewModel.Projects = _repoWrapper.Project.LoadEverything();

            Project myProject = viewModel.Projects.FirstOrDefault(c => c.ProjectId == projectId);
            if (myProject == null)
            {
                myProject = new Project();
                myProject.Description = "";
            }
            viewModel.Project = myProject;

            return View(viewModel);
        }

        // GET: Projects
        public IActionResult ListOfProjectsCompactView()
        {
            ViewData["Title"] = "Projects";

            var viewModel = new ProjectsIndexDataViewModel();
            viewModel.Projects = _repoWrapper.Project.LoadEverything();

            return View(viewModel);
        }


    }
}

using System.Linq;
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
            viewModel.Companies = _repoWrapper.Company.LoadEmployersOnly().AsEnumerable&lt;Company>();

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
