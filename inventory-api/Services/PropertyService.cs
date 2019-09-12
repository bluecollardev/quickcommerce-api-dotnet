using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services;
using inventoryapi.Domain.Services.Communication;
using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;
namespace inventoryapi.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyService(IPropertyRepository propertyRepository, IUnitOfWork unitOfWork)
        {
            this._propertyRepository = propertyRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Property>> ListAsync()
        {
            return await this._propertyRepository.ListAsync();
        }

        public async Task<Property> FindByIdAsync(int id)
        {
            return await this._propertyRepository.FindByIdAsync(id);
        }

        public async Task<BaseResponse<Property>> SaveAsync(Property model)
        {
            try
            {
                await this._propertyRepository.AddAsync(model);
                await this._unitOfWork.CompleteAsync();

                return new SavePropertyResponse(model);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePropertyResponse($"An error occurred when saving the property: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Property>> UpdateAsync(int id, Property model)
        {
            var existingModel = await this._propertyRepository.FindByIdAsync(id);

            if (existingModel == null) return new SavePropertyResponse("Property could not be found"); // TODO: Return an appropriate response

            try
            {
                this._propertyRepository.Update(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SavePropertyResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePropertyResponse($"An error occurred when updating the property: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Property>> DeleteAsync(int id)
        {
            var existingModel = await this._propertyRepository.FindByIdAsync(id);

            if (existingModel == null) return new SavePropertyResponse("Property could not be found"); // TODO: Return an appropriate response

            try
            {
                this._propertyRepository.Remove(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SavePropertyResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SavePropertyResponse($"An error occurred when updating the property: {ex.Message}");
            }

        }
    }
}
