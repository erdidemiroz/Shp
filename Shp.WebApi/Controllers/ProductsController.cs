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

        #region Add

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success) 
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        #endregion

        #region Update

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        #endregion

        #region Delete

        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        #endregion

        #region GetProduct

        [HttpGet("/{productId}")]
        public IActionResult GetAProduct(int productId)
        {
            var result = _productService.Get(productId);
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getAll")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAll();
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getProductsByCategory{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = _productService.GetProductsByCategory(categoryId);
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        #endregion
    }
}