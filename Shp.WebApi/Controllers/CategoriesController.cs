using Microsoft.AspNetCore.Mvc;
using Shp.Business.Abstract;

namespace Shp.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region ctor

        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region GetCategory

        [HttpGet("getAll")]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        #endregion
    }
}