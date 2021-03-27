using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;

namespace WillieSandoval_2_28_2021.Repository_SampleCode
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _repoContext;
        private ICompanyRepository _company;
        private IProjectRepository _project;
        private IProjectsTopicsRepository _projectsTopics;
        private ITopicRepository _topic;

        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_repoContext);
                }
                return _company;
            }
        }

        public IProjectRepository Project
        {
            get
            {
                if (_project == null)
                {
                    _project = new ProjectRepository(_repoContext);
                }
                return _project;
            }
        }

        public IProjectsTopicsRepository ProjectsTopics
        {
            get
            {
                if (_projectsTopics == null)
                {
                    _projectsTopics = new ProjectsTopicsRepository(_repoContext);
                }
                return _projectsTopics;
            }
        }

        public ITopicRepository Topic
        {
            get
            {
                if (_topic == null)
                {
                    _topic = new TopicRepository(_repoContext);
                }
                return _topic;
            }
        }

        public RepositoryWrapper(ApplicationDbContext applicationDBContext)
        {
            _repoContext = applicationDBContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
