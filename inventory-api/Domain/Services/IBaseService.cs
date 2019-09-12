using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services.Communication;

namespace inventoryapi.Domain.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> FindByIdAsync(int id);
        Task<BaseResponse<T>> SaveAsync(T model);
        Task<BaseResponse<T>> UpdateAsync(int id, T model);
        Task<BaseResponse<T>> DeleteAsync(int id);
    }
}