using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.ViewModels
{
    public class ProjectsIndexDataViewModel
    {
        public Project Project { get; set; }

        public IEnumerable<Project> Projects { get; set; }
        
        public string TopicStringWithDelimeter { get; set; }
    }
}
