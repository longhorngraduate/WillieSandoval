using System.Linq;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Contracts
{
    public interface IProjectRepository : IRepositoryBase&lt;Project>
    {
        IQueryable&lt;Project> LoadEverything();
    }
}
