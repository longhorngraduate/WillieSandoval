using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.Models
{
    public class ProjectsTopics
    {
        public int ProjectId { get; set; }
        public int TopicId { get; set; }
        public Project Project { get; set; }
        public Topic Topic { get; set; }
    }
}
