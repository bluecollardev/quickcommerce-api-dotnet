using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Address>> ListAsync()
        {
            return await this._context.Addresses.ToListAsync();
        }

        public new async Task AddAsync(Address model)
        {
            await this._context.Addresses.AddAsync(model);
        }

        public new async Task<Address> FindByIdAsync(int id)
        {
            return await this._context.Addresses.FindAsync(id);
        }

        public new void Update(Address model)
        {
            this._context.Addresses.Update(model);
        }

        public new void Remove(Address model)
        {
            this._context.Addresses.Remove(model);
        }
    }
}
