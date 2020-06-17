using System.Collections.Generic;
using Shp.Business.Abstract;
using Shp.Business.Constants;
using Shp.Core.Utilities.Results;
using Shp.DataAccess.Abstract;
using Shp.Entities.Concrete;

namespace Shp.Business.Concrete
{
    public sealed class CategoryManager : ICategoryService
    {
        #region ctor

        private readonly ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        #endregion

        #region Add

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages<Category>.EntityInserted);
        }

        #endregion

        #region Update

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages<Category>.EntityUpdated);
        }

        #endregion

        #region Delete

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages<Category>.EntityDeleted);
        }


        #endregion

        #region GetCategory

        public IDataResult<Category> Get(int categoryId) => new SuccessDataResult<Category>(_categoryDal.Get(x => x.Id == categoryId));

        public IDataResult<IEnumerable<Category>> GetAll() => new SuccessDataResult<IEnumerable<Category>>(_categoryDal.GetList());

        #endregion
    }
}
