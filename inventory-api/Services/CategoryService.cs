using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services;
using inventoryapi.Domain.Services.Communication;
using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;

namespace inventoryapi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this._categoryRepository.ListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await this._categoryRepository.FindByIdAsync(id);
        }

        public async Task<BaseResponse<Category>> SaveAsync(Category model)
        {
            try
            {
                await this._categoryRepository.AddAsync(model);
                await this._unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(model);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Category>> UpdateAsync (int id, Category model)
        {
            var existingModel = await this._categoryRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveCategoryResponse("Category could not be found"); // TODO: Return an appropriate response

            // TODO: Not sure why I have to explicitly set this...
            existingModel.Name = model.Name;

            try
            {
                this._categoryRepository.Update(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCategoryResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Category>> DeleteAsync(int id)
        {
            var existingModel = await this._categoryRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveCategoryResponse("Category could not be found"); // TODO: Return an appropriate response

            try
            {
                this._categoryRepository.Remove(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCategoryResponse($"An error occurred when updating the category: {ex.Message}");
            }

        }
    }
}
