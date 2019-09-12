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
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            IEnumerable<Product> products = await this._productService.ListAsync();
            IEnumerable<ProductResource> resources = this._mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await this._productService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var product = this._mapper.Map<SaveProductResource, Product>(resource);
            var result = await this._productService.SaveAsync(product);

            if (!result.Success) return BadRequest(result.Message);

            var productResource = this._mapper.Map<Product, ProductResource>(result.Model);
            return Ok(productResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(allErrors);
            }

            var product = this._mapper.Map<SaveProductResource, Product>(resource);
            var result = await this._productService.UpdateAsync(id, product);

            if (!result.Success) return BadRequest(result.Message);

            var productResource = this._mapper.Map<Product, ProductResource>(result.Model);
            return Ok(productResource);
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

            var result = await this._productService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var productResource = this._mapper.Map<Product, ProductResource>(result.Model);
            return Ok(productResource);
        }
    }
}
