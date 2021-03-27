using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.ViewModels;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class SampleCodeFrontEnd : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string contentRootFrontEnd;

        public SampleCodeFrontEnd(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootFrontEnd = _hostingEnvironment.ContentRootPath + @"\wwwroot\SampleCode\FrontEnd\";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JQueryDatatables()
        {
            ViewData["Title"] = "JQuery Datatables";
            return ReturnSimpleView(contentRootFrontEnd + @"JQueryDatatables.txt");
        }

        public IActionResult JQueryDatatablesCustom()
        {
            ViewData["Title"] = "JQuery Datatables - added to existing code";
            return ReturnSimpleView(contentRootFrontEnd + @"JQueryDatatablesCustom.txt");
        }

        public IActionResult ChangeExitToAsyncCall()
        {
            ViewData["Title"] = "Change Existing Exit Code to use Async calls";
            return ReturnSimpleView(contentRootFrontEnd + @"ChangeExitToAsyncCall.js");
        }


        #region Helper Functions
        public IActionResult ReturnSimpleView(string PageName)
        {
            SampleCodeFrontEndViewModel oDPVM = new SampleCodeFrontEndViewModel
            {
                Page = Helpers.Helper.GetFileContents(PageName)
            };

            return View(oDPVM);
        }
        #endregion
    }
}
