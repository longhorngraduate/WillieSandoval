using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WillieSandoval_2_28_2021.ViewModels;

namespace WillieSandoval_2_28_2021.Controllers
{
    public class SampleCodeVBDotNET : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string contentRootVBDotNET, contentRootOCR;

        public SampleCodeVBDotNET(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootVBDotNET = _hostingEnvironment.ContentRootPath + @"\wwwroot\SampleCode\VB.NET\";
            contentRootOCR = _hostingEnvironment.ContentRootPath + @"\wwwroot\SampleCode\OCR\";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSignatureCoordinatesFromPDF()
        {
            ViewData["Title"] = "Get Signature Coordinates From PDF";
            return ReturnSimpleView(contentRootOCR + @"GetSignatureCoordinatesFromPDF.vb");
        }

        public IActionResult SeparatePDFIntoSmallerPDFs()
        {
            ViewData["Title"] = "Separate PDF Into Smaller PDFs";
            return ReturnSimpleView(contentRootOCR + @"SeparatePDFIntoSmallerPDFs.vb");
        }

        public IActionResult NonBorrowerToViewDocuSignDisclosureUpdates()
        {
            ViewData["Title"] = "non-Borrower To View DocuSign Disclosure Updates";
            return ReturnSimpleView(contentRootVBDotNET + @"NonBorrowerToViewDocuSignDisclosureUpdates.vb");
        }

        public IActionResult CustomSort()
        {
            ViewData["Title"] = "Custom Sort";
            return ReturnSimpleView(contentRootVBDotNET + @"CustomSort.vb");
        }

        public IActionResult NutshellWebServices()
        {
            ViewData["Title"] = "Nutshell Web Services";
            return ReturnSimpleView(contentRootVBDotNET + @"NutshellWebServices.vb");
        }
        


        #region Helper Functions
        public IActionResult ReturnSimpleView(string PageName)
        {
            SampleCodeVBDotNETViewModel oDPVM = new SampleCodeVBDotNETViewModel
            {
                Page = Helpers.Helper.GetFileContents(PageName)
            };

            return View(oDPVM);
        }
        #endregion
    }
}
