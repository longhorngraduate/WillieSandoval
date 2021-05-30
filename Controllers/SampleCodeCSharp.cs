using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace WillieSandoval_2_28_2021.Controllers
{

    public class SampleCodeCSharp : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string contentRootCSharp, contentRootRepositoryPattern;

        public SampleCodeCSharp(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootCSharp = _hostingEnvironment.ContentRootPath + @"\wwwroot\SampleCode\CSharp\";
            contentRootRepositoryPattern = _hostingEnvironment.ContentRootPath + @"\wwwroot\SampleCode\RepositoryPattern\";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RepositoryPatternWithGenericsInDotNETCore()
        {
            ViewData["Title"] = "Repository Pattern With Generics In .NET Core";

            SampleCodeCSharpViewModel oDPVM = new SampleCodeCSharpViewModel
            {
                IRepositoryBase = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Contracts\IRepositoryBase.cs"),
                RepositoryBase = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Repository\RepositoryBase.cs"),
                ICompanyRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Contracts\ICompanyRepository.cs"),
                IProjectRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Contracts\IProjectRepository.cs"),
                IProjectTopicsRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Contracts\IProjectsTopicsRepository.cs"),
                ITopicRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Contracts\ITopicRepository.cs"),
                CompanyRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Repository\CompanyRepository.cs"),
                ProjectRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Repository\ProjectRepository.cs"),
                ProjectsTopicsRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Repository\ProjectsTopicsRepository.cs"),
                TopicRepository = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Repository\TopicRepository.cs"),
                IRepositoryWrapper = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Contracts\IRepositoryWrapper.cs"),
                RepositoryWrapper = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Repository\RepositoryWrapper.cs"),
                SampleCodeCSharp = Helpers.Helper.GetFileContents(contentRootRepositoryPattern + @"Controllers\SomeControllers.cs"),
            };

            return View(oDPVM);
        }

    }
}
