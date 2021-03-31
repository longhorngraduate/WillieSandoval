﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillieSandoval_2_28_2021.Contracts;
using WillieSandoval_2_28_2021.Data;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Repository_SampleCode
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public IQueryable<Company> LoadEmployersOnly()
        {
            return (IQueryable<Company>)ApplicationDbContext
                .Set<Company>()
                .Where(p => p.Display == true)
                .OrderByDescending(p => p.DateStart)
                .AsNoTracking();
        }
    }
}
