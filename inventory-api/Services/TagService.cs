using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using inventoryapi.Domain.Services;
using inventoryapi.Domain.Services.Communication;
using inventoryapi.Domain.Models;
using inventoryapi.Domain.Repositories;

namespace inventoryapi.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await this._tagRepository.ListAsync();
        }

        public async Task<Tag> FindByIdAsync(int id)
        {
            return await this._tagRepository.FindByIdAsync(id);
        }

        public async Task<BaseResponse<Tag>> SaveAsync(Tag model)
        {
            try
            {
                await this._tagRepository.AddAsync(model);
                await this._unitOfWork.CompleteAsync();

                return new SaveTagResponse(model);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveTagResponse($"An error occurred when saving the tag: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Tag>> UpdateAsync(int id, Tag model)
        {
            var existingModel = await this._tagRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveTagResponse("Tag could not be found"); // TODO: Return an appropriate response

            try
            {
                this._tagRepository.Update(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveTagResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveTagResponse($"An error occurred when updating the tag: {ex.Message}");
            }
        }

        public async Task<BaseResponse<Tag>> DeleteAsync(int id)
        {
            var existingModel = await this._tagRepository.FindByIdAsync(id);

            if (existingModel == null) return new SaveTagResponse("Tag could not be found"); // TODO: Return an appropriate response

            try
            {
                this._tagRepository.Remove(existingModel);
                await this._unitOfWork.CompleteAsync();

                return new SaveTagResponse(existingModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveTagResponse($"An error occurred when updating the tag: {ex.Message}");
            }

        }
    }
}
