using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Product>> ListAsync()
        {
            return await this._context.Products
                .Include(p => p.Prices)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }

        public new async Task AddAsync(Product model)
        {
            await this._context.Products.AddAsync(model);
        }

        public new async Task<Product> FindByIdAsync(int id)
        {
            return await this._context.Products.FindAsync(id);
        }

        public new void Update(Product model)
        {
            this._context.Products.Update(model);
        }

        public new void Remove(Product model)
        {
            this._context.Products.Remove(model);
        }
    }
}
