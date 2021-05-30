using Microsoft.EntityFrameworkCore;
using System.Linq;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Repository
{
    public class CompanyRepository : RepositoryBase&lt;Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public IQueryable&lt;Company> LoadEmployersOnly()
        {
            return (IQueryable&lt;Company>)ApplicationDbContext
                .Set&lt;Company>()
                .Where(p => p.Display == true)
                .OrderByDescending(p => p.DateStart)
                .AsNoTracking();
        }
    }
}
