using System;
using System.Linq;
using System.Linq.Expressions;

namespace WillieSandoval_2_28_2021.Contracts
{
    public interface IRepositoryBase&lt;T>
    {
        IQueryable&lt;T> FindAll();
        IQueryable&lt;T> FindByCondition(Expression&lt;Func&lt;T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
