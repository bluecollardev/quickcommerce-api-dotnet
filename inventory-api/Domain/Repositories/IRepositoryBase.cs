using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace inventoryapi.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        //IQueryable<T> FindAll();
        //IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        //void Create(T model);
        //void Update(T model);
        //void Delete(T model);
        Task<IEnumerable<T>> ListAsync();
        Task AddAsync(T model);
        Task SaveAsync(T model);
        Task<T> FindByIdAsync(int id);
        void Update(T model);
        void Remove(T model);
    }
}
