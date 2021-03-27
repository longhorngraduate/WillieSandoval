using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Repository_SampleCode
{
    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
