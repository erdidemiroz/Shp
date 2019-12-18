using System.Collections.Generic;
using Shp.Business.Abstract;
using Shp.DataAccess.Abstract;
using Shp.Entities.Concrete;

namespace Shp.Business.Concrete
{
    public class ProductManagement : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManagement(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IEnumerable<Product> GetProducts() => _productDal.GetList();

        public IEnumerable<Product> GetProductsByCategory(int categoryId) => _productDal.GetList(x => x.CategoryId == categoryId);

        public Product AddProduct(Product product) => _productDal.Add(product);

        public void DeleteProduct(Product product) => _productDal.Delete(product);

        public void UpdateProduct(Product product) => _productDal.Update(product);

        public Product GetProductById(int productId) => _productDal.Get(x => x.Id == productId);
    }
}
