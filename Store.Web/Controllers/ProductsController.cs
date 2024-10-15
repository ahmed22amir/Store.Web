using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.Products;
using Store.Service.Services.Products.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllBrands")]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllBrands()
            => Ok(await _productService.GetAllBrandsAsync());

        [HttpGet("GetAllTypes")]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
            => Ok(await _productService.GetAllTypesAsync());

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts()
            => Ok(await _productService.GetAllProductsAsync());

        [HttpGet("GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById(int? id)
            => Ok(await _productService.GetProductByIdAsync(id));
    }
}
