using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;
using WillieSandoval_2_28_2021.ViewModels;

namespace WillieSandoval_2_28_2021.Controllers_SampleCode
{
    public class ProjectsSampleCodeController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public ProjectsSampleCodeController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        // GET: Projects
        public IActionResult Index()
        {
            ViewData["Title"] = "Projects";

            //return View(_context.Project.Projects.ToListAsync());
            //return View(_repoWrapper.Project.FindAll());
            //return View(_repoWrapper.Project.LoadEverything());

            var viewModel = new ProjectsIndexDataViewModel();
            viewModel.Projects = _repoWrapper.Project.LoadEverything();
            //viewModel.Projects = _repoWrapper.Project.FindAll();

            //if (id != null)
            //{
            //    ViewBag.InstructorID = id.Value;
            //    viewModel.Courses = viewModel.Instructors.Where(
            //        i => i.ID == id.Value).Single().Courses;
            //}

            //if (courseID != null)
            //{
            //    ViewBag.CourseID = courseID.Value;
            //    viewModel.Enrollments = viewModel.Courses.Where(
            //        x => x.CourseID == courseID).Single().Enrollments;
            //}

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
