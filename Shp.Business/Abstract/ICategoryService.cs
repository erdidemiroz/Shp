using System.Collections.Generic;
using Shp.Core.Utilities.Results;
using Shp.Entities.Concrete;

namespace Shp.Business.Abstract
{
    public interface ICategoryService
    {
        IResult InsertCategory(Category category);
        IResult UpdateCategory(Category category);
        IResult DeleteCategory(Category category);
        IDataResult<Category> GetACategory(int categoryId);
        IDataResult<IEnumerable<Category>> GetAllCategories();
    }
}
