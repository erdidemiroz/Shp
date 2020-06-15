using System.Collections.Generic;
using Shp.Core.DataAccess;
using Shp.Core.Entities.Concrete;

namespace Shp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        IEnumerable<OperationClaims> GetClaims(User user);
    }
}
