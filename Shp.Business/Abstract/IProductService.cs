using System.Collections.Generic;
using Shp.Entities.Concrete;

namespace Shp.Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        Product AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int productId);
    }
}
