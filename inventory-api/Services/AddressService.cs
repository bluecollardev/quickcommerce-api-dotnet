using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services;
using inventoryapi.Domain.Services.Communication;
using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;

namespace inventoryapi.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
        {
            this._addressRepository = addressRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Address>> ListAsync()
        {
            return await this._addressRepository.ListAsync();
        }

        public async Task<Address> FindByIdAsync(int id)
        {
            return await this._addressRepository.FindByIdAsync(id);
        }

        public async Task<BaseResponse<Address>> SaveAsync(Address model)
        {
            try
            {
                await this._addressRepository.AddAsync(model);
                await this._unitOfWork.CompleteAsync();

                return new SaveAddressResponse(model);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveAddressResponse($"An error occurred when saving the address: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Address>> UpdateAsync(int id, Address model)
        {
            var existingModel = await this._addressRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveAddressResponse("Address could not be found"); // TODO: Return an appropriate response

            try
            {
                this._addressRepository.Update(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveAddressResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveAddressResponse($"An error occurred when updating the address: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Address>> DeleteAsync(int id)
        {
            var existingModel = await this._addressRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveAddressResponse("Address could not be found"); // TODO: Return an appropriate response

            try
            {
                this._addressRepository.Remove(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveAddressResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveAddressResponse($"An error occurred when updating the address: {ex.Message}");
            }

        }
    }
}
