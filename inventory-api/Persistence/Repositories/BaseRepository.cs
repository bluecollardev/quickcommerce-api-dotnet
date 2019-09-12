using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IRepositoryBase<T>
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            this._context = context;
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await Task.Run(() => new List<T>());
        }

        public virtual async Task AddAsync(T model)
        {
            Task<T> result = (Task<T>)Task.CompletedTask;
            await result;
        }

        public virtual async Task SaveAsync(T model)
        {
            Task<T> result = (Task<T>)Task.CompletedTask;
            await result;
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            Task<T> result = (Task<T>)Task.CompletedTask;
            return await result;
        }

        public virtual void Update(T model)
        {
        }

        public virtual void Remove(T model)
        {
        }
    }
}
