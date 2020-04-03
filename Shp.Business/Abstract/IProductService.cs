using System.Collections.Generic;
using Shp.Core.Utilities.Results;
using Shp.Entities.Concrete;

namespace Shp.Business.Abstract
{
    public interface IProductService
    {
        IResult InsertProduct(Product product);
        IResult UpdateProduct(Product product);
        IResult DeleteProduct(Product product);
        IDataResult<Product> GetAProduct(int productId);
        IDataResult<IEnumerable<Product>> GetAllProducts();
        IDataResult<IEnumerable<Product>> GetProductsByCategory(int categoryId);
    }
}
