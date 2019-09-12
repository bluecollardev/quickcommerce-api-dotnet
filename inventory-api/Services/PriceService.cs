using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services;
using inventoryapi.Domain.Services.Communication;
using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;

namespace inventoryapi.Services
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _priceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PriceService(IPriceRepository priceRepository, IUnitOfWork unitOfWork)
        {
            this._priceRepository = priceRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Price>> ListAsync()
        {
            return await this._priceRepository.ListAsync();
        }

        public async Task<Price> FindByIdAsync(int id)
        {
            return await this._priceRepository.FindByIdAsync(id);
        }

        public async Task<BaseResponse<Price>> SaveAsync(Price model)
        {
            try
            {
                await this._priceRepository.AddAsync(model);
                await this._unitOfWork.CompleteAsync();

                return new SavePriceResponse(model);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePriceResponse($"An error occurred when saving the price: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Price>> UpdateAsync(int id, Price model)
        {
            var existingModel = await this._priceRepository.FindByIdAsync(id);

            if (existingModel == null) return new SavePriceResponse("Price could not be found"); // TODO: Return an appropriate response

            try
            {
                this._priceRepository.Update(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SavePriceResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePriceResponse($"An error occurred when updating the price: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Price>> DeleteAsync(int id)
        {
            var existingModel = await this._priceRepository.FindByIdAsync(id);

            if (existingModel == null) return new SavePriceResponse("Price could not be found"); // TODO: Return an appropriate response

            try
            {
                this._priceRepository.Remove(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SavePriceResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePriceResponse($"An error occurred when updating the price: {ex.Message}");
            }

        }
    }
}
