using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public IQueryable<Project> LoadEverything()
        {
            return (IQueryable<Project>)ApplicationDbContext
                .Set<Project>()
                .Include(p => p.Company)
                .Include(p => p.ProjectsTopics)
                .ThenInclude(pt => pt.Topic)
                .OrderBy(p => p.Date)
                .AsNoTracking();
        }
    }
}
