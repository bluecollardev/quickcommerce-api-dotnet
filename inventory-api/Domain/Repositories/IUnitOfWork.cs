using System.Threading.Tasks;

namespace inventoryapi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}