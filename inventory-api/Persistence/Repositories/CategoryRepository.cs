using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Category>> ListAsync()
        {
            return await this._context.Categories.ToListAsync();
        }

        public new async Task AddAsync(Category model)
        {
            await this._context.Categories.AddAsync(model);
        }

        public new async Task<Category> FindByIdAsync(int id)
        {
            return await this._context.Categories.FindAsync(id);
        }

        public new void Update(Category model)
        {
            this._context.Categories.Update(model);
        }

        public new void Remove(Category model)
        {
            this._context.Categories.Remove(model);
        }
    }
}
