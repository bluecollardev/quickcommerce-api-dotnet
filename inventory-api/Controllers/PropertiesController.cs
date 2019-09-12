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
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertyService propertyService, IMapper mapper)
        {
            this._propertyService = propertyService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<PropertyResource>> GetAllAsync()
        {
            IEnumerable<Property> properties = await this._propertyService.ListAsync();
            IEnumerable<PropertyResource> resources = this._mapper.Map<IEnumerable<Property>, IEnumerable<PropertyResource>>(properties);
            return resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Property> Get(int id)
        {
            return await this._propertyService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePropertyResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var property = this._mapper.Map<SavePropertyResource, Property>(resource);
            var result = await this._propertyService.SaveAsync(property);

            if (!result.Success) return BadRequest(result.Message);

            var propertyResource = this._mapper.Map<Property, PropertyResource>(result.Model);
            return Ok(propertyResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePropertyResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var property = this._mapper.Map<SavePropertyResource, Property>(resource);
            var result = await this._propertyService.UpdateAsync(id, property);

            if (!result.Success) return BadRequest(result.Message);

            var propertyResource = this._mapper.Map<Property, PropertyResource>(result.Model);
            return Ok(propertyResource);
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

            var result = await this._propertyService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var propertyResource = this._mapper.Map<Property, PropertyResource>(result.Model);
            return Ok(propertyResource);
        }
    }
}
