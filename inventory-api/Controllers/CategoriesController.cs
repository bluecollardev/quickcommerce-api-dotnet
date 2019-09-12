using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using inventoryapi.Domain.Models;
using inventoryapi.Domain.Services;
using inventoryapi.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace inventoryapi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _categoryService.ListAsync();
            IEnumerable<CategoryResource> resources = this._mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await this._categoryService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var category = this._mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await this._categoryService.SaveAsync(category);

            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = this._mapper.Map<Category, CategoryResource>(result.Model);
            return Ok(categoryResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var category = this._mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await this._categoryService.UpdateAsync(id, category);

            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = this._mapper.Map<Category, CategoryResource>(result.Model);
            return Ok(categoryResource);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var result = await this._categoryService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = this._mapper.Map<Category, CategoryResource>(result.Model);
            return Ok(categoryResource);
        }
    }
}
