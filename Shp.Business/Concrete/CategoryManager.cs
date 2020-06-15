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

        #region InsertProduct

        public IResult InsertCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages<Category>.EntityInserted);
        }

        #endregion

        #region UpdateProduct

        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages<Category>.EntityUpdated);
        }

        #endregion

        #region DeleteProduct

        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages<Category>.EntityDeleted);
        }


        #endregion

        #region GetCategory

        public IDataResult<Category> GetACategory(int categoryId) => new SuccessDataResult<Category>(_categoryDal.Get(x => x.Id == categoryId));

        public IDataResult<IEnumerable<Category>> GetAllCategories() => new SuccessDataResult<IEnumerable<Category>>(_categoryDal.GetList());

        #endregion
    }
}
