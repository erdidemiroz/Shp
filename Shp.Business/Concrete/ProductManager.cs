﻿using System.Collections.Generic;
using Shp.Business.Abstract;
using Shp.Business.Constants;
using Shp.Business.ValidationRules.FluentValidation;
using Shp.Core.Aspects.Autofac.Authorization;
using Shp.Core.Aspects.Autofac.Caching;
using Shp.Core.Aspects.Autofac.Logging;
using Shp.Core.Aspects.Autofac.Performance;
using Shp.Core.Aspects.Autofac.Validation;
using Shp.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts.Loggers;
using Shp.Core.CrossCuttingConcerns.Validation;
using Shp.Core.Utilities.Business;
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

        #region Add

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));
            if (result != null)
                return result;
            _productDal.Add(product);
            return new SuccessResult(Messages<Product>.EntityInserted);
        }

        private IResult CheckIfProductNameExists(string productProductName)
        {
            if (_productDal.Get(x => x.ProductName == productProductName) != null)
                return new ErrorResult("Product name already exist.");

            return new SuccessResult();
        }

        #endregion

        #region Update

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages<Product>.EntityUpdated);
        }

        #endregion

        #region Delete

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages<Product>.EntityDeleted);
        } 


        #endregion

        #region GetProduct

        public IDataResult<Product> Get(int productId) => new SuccessDataResult<Product>(_productDal.Get(x => x.Id == productId));

        //[AuthorizationAspect("Product.List")]
        //[CacheAspect]
        //[PerformanceAspect(0)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<IEnumerable<Product>> GetAll() => new SuccessDataResult<IEnumerable<Product>>(_productDal.GetList());

        [CacheAspect]
        public IDataResult<IEnumerable<Product>> GetProductsByCategory(int categoryId) => new SuccessDataResult<IEnumerable<Product>>(_productDal.GetList(x => x.CategoryId == categoryId));

        #endregion
    }
}
