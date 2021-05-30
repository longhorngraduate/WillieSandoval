using System;
using System.Linq;
using System.Linq.Expressions;
using WillieSandoval_2_28_2021.Contracts;
using Microsoft.EntityFrameworkCore;
using WillieSandoval_2_28_2021.Data;

namespace WillieSandoval_2_28_2021.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.ApplicationDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.ApplicationDbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
        }
    }
}
