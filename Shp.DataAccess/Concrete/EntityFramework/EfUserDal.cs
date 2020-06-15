using System.Collections.Generic;
using System.Linq;
using Shp.Core.DataAccess.EntityFramework;
using Shp.Core.Entities.Concrete;
using Shp.DataAccess.Abstract;
using Shp.DataAccess.Concrete.EntityFramework.Contexts;

namespace Shp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ShpContext>, IUserDal
    {

        public IEnumerable<OperationClaims> GetClaims(User user)
        {
            using (var context = new ShpContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaims { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
