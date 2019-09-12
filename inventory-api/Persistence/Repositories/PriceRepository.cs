using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Price>> ListAsync()
        {
            return await this._context.Prices.ToListAsync();
        }

        public new async Task AddAsync(Price model)
        {
            await this._context.Prices.AddAsync(model);
        }

        public new async Task<Price> FindByIdAsync(int id)
        {
            return await this._context.Prices.FindAsync(id);
        }

        public new void Update(Price model)
        {
            this._context.Prices.Update(model);
        }

        public new void Remove(Price model)
        {
            this._context.Prices.Remove(model);
        }
    }
}
