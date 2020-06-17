using System.Collections.Generic;
using Shp.Core.Utilities.Results;
using Shp.Entities.Concrete;

namespace Shp.Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<Category> Get(int categoryId);
        IDataResult<IEnumerable<Category>> GetAll();
    }
}
