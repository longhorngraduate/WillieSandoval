using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Repository
{
    public class ProjectsTopicsRepository : RepositoryBase<ProjectsTopics>, IProjectsTopicsRepository
    {
        public ProjectsTopicsRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
