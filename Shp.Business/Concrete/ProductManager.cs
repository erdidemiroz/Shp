using System.Collections.Generic;
using Shp.Business.Abstract;
using Shp.Business.Constants;
using Shp.Core.Utilities.Results;
using Shp.DataAccess.Abstract;
using Shp.Entities.Concrete;

namespace Shp.Business.Concrete
{
    public sealed class ProductManager : IProductService
    {
        #region ctor

        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        #endregion

        #region AddProduct

        public IResult AddProduct(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages<Product>.EntityInserted);
        } 

        #endregion

        #region UpdateProduct

        public IResult UpdateProduct(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages<Product>.EntityUpdated);
        }

        #endregion

        #region DeleteProduct

        public IResult DeleteProduct(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages<Product>.EntityDeleted);
        } 


        #endregion

        #region GetProduct

        public IDataResult<Product> GetAProduct(int productId) => new SuccessDataResult<Product>(_productDal.Get(x => x.Id == productId));

        public IDataResult<IEnumerable<Product>> GetAllProducts() => new SuccessDataResult<IEnumerable<Product>>(_productDal.GetList());

        public IDataResult<IEnumerable<Product>> GetProductsByCategory(int categoryId) => new SuccessDataResult<IEnumerable<Product>>(_productDal.GetList(x => x.CategoryId == categoryId));

        #endregion
    }
}
