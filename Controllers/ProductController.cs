using AdwWorksDapperAPI.Interfaces;
using AdwWorksDapperAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AdwWorksDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _memoryCache;
        public ProductController(IProductRepository productRepository, IMemoryCache memoryCache)
        {
            _productRepository = productRepository;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if(!_memoryCache.TryGetValue("ProductsKey", out IEnumerable<Product> list))
            {
                // set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions();
                // keep in cache for a specified time
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                list = _productRepository.GetProducts();
                _memoryCache.Set("ProductsKey", list, cacheEntryOptions);
            }
            return Ok(list);
        }

        [HttpGet("{Id:int}")]
        public IActionResult Get(int Id)
        {
            var result = _productRepository.GetProduct(Id);
            if(result == null) return NotFound(new { message = "Resource not found."});
            return Ok(result);
        }
    }
}
