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
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagsController(ITagService tagService, IMapper mapper)
        {
            this._tagService = tagService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await this._tagService.ListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Tag> Get(int id)
        {
            return await this._tagService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var tag = this._mapper.Map<SaveTagResource, Tag>(resource);
            var result = await this._tagService.SaveAsync(tag);

            if (!result.Success) return BadRequest(result.Message);

            var tagResource = this._mapper.Map<Tag, TagResource>(result.Model);
            return Ok(tagResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var tag = this._mapper.Map<SaveTagResource, Tag>(resource);
            var result = await this._tagService.UpdateAsync(id, tag);

            if (!result.Success) return BadRequest(result.Message);

            var tagResource = this._mapper.Map<Tag, TagResource>(result.Model);
            return Ok(tagResource);
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

            var result = await this._tagService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var tagResource = this._mapper.Map<Tag, TagResource>(result.Model);
            return Ok(tagResource);
        }
    }
}
