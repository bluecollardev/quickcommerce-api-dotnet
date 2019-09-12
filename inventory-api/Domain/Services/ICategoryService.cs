using System.Threading.Tasks;

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Services.Communication;

namespace inventoryapi.Domain.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
    }
}
