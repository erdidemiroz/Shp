using System.Collections.Generic;
using Shp.Core.Utilities.Results;
using Shp.Entities.Concrete;

namespace Shp.Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<Product> Get(int productId);
        IDataResult<IEnumerable<Product>> GetAll();
        IDataResult<IEnumerable<Product>> GetProductsByCategory(int categoryId);
    }
}
