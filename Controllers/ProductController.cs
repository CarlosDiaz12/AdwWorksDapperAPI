using AdwWorksDapperAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdwWorksDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _productRepository.GetProducts();
            return Ok(result);
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
