using Microsoft.EntityFrameworkCore;
using System.Linq;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Repository
{
    public class ProjectRepository : RepositoryBase&lt;Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public IQueryable&lt;Project> LoadEverything()
        {
            return (IQueryable&lt;Project>)ApplicationDbContext
                .Set&lt;Project>()
                .Include(p => p.Company)
                .Include(p => p.ProjectsTopics)
                .ThenInclude(pt => pt.Topic)
                .OrderBy(p => p.Date)
                .AsNoTracking();
        }
    }
}
