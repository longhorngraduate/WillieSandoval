using System;
using System.Linq;
using System.Linq.Expressions;
using WillieSandoval_2_28_2021.Contracts;
using Microsoft.EntityFrameworkCore;
using WillieSandoval_2_28_2021.Data;

namespace WillieSandoval_2_28_2021.Repository
{
    public abstract class RepositoryBase&lt;T> : IRepositoryBase&lt;T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
        }
        public IQueryable&lt;T> FindAll()
        {
            return this.ApplicationDbContext.Set&lt;T>().AsNoTracking();
        }
        public IQueryable&lt;T> FindByCondition(Expression&lt;Func&lt;T, bool>> expression)
        {
            return this.ApplicationDbContext.Set&lt;T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.ApplicationDbContext.Set&lt;T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.ApplicationDbContext.Set&lt;T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set&lt;T>().Remove(entity);
        }
    }
}
