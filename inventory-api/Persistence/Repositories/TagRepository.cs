using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
using inventoryapi.Persistence.Contexts;

namespace inventoryapi.Persistence.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Tag>> ListAsync()
        {
            return await this._context.Tags.ToListAsync();
        }

        public new async Task AddAsync(Tag model)
        {
            await this._context.Tags.AddAsync(model);
        }

        public new async Task<Tag> FindByIdAsync(int id)
        {
            return await this._context.Tags.FindAsync(id);
        }

        public new void Update(Tag model)
        {
            this._context.Tags.Update(model);
        }

        public new void Remove(Tag model)
        {
            this._context.Tags.Remove(model);
        }
    }
}
