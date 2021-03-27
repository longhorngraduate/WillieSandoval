using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.Contracts_SampleCode
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }
        IProjectRepository Project { get; }
        IProjectsTopicsRepository ProjectsTopics { get; }
        ITopicRepository Topic { get; }
        void Save();
    }
}
