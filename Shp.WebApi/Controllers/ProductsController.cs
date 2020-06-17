using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shp.Business.Abstract;
using Shp.Entities.Concrete;

namespace Shp.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region ctor

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region AddProduct

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.AddProduct(product);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        #endregion

        #region UpdateProduct

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.UpdateProduct(product);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        #endregion

        #region DeleteProduct

        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.DeleteProduct(product);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        #endregion

        #region GetProduct

        [HttpGet("/{productId}")]
        public IActionResult GetAProduct(int productId)
        {
            var result = _productService.GetAProduct(productId);
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "Product.List")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getProductsByCategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = _productService.GetProductsByCategory(categoryId);
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        #endregion
    }
}