using Shp.Core.DataAccess.EntityFramework;
using Shp.DataAccess.Abstract;
using Shp.DataAccess.Concrete.EntityFramework.Contexts;
using Shp.Entities.Concrete;

namespace Shp.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ShpContext>, IProductDal
    {
    }
}
