using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services;
using inventoryapi.Domain.Services.Communication;
using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;

namespace inventoryapi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await this._productRepository.ListAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await this._productRepository.FindByIdAsync(id);
        }

        public async Task<BaseResponse<Product>> SaveAsync(Product model)
        {
            try
            {
                await this._productRepository.AddAsync(model);
                await this._unitOfWork.CompleteAsync();

                return new SaveProductResponse(model);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveProductResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Product>> UpdateAsync(int id, Product model)
        {
            var existingModel = await this._productRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveProductResponse("Product could not be found"); // TODO: Return an appropriate response

            try
            {
                this._productRepository.Update(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveProductResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveProductResponse($"An error occurred when updating the product: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Product>> DeleteAsync(int id)
        {
            var existingModel = await this._productRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveProductResponse("Product could not be found"); // TODO: Return an appropriate response

            try
            {
                this._productRepository.Remove(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveProductResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveProductResponse($"An error occurred when updating the product: {ex.Message}");
            }

        }
    }
}
