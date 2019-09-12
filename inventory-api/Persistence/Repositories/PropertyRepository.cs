using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Property>> ListAsync()
        {
            return await this._context.Properties
                .Include(p => p.Address)
                .Include(p => p.Prices)
                .ToListAsync();
        }

        public new async Task AddAsync(Property model)
        {
            await this._context.Properties.AddAsync(model);
        }

        public new async Task<Property> FindByIdAsync(int id)
        {
            return await this._context.Properties.FindAsync(id);
        }

        public new void Update(Property model)
        {
            this._context.Properties.Update(model);
        }

        public new void Remove(Property model)
        {
            this._context.Properties.Remove(model);
        }
    }
}
