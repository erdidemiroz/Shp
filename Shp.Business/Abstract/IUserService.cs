using System.Collections.Generic;
using Shp.Core.Entities.Concrete;
using Shp.Core.Utilities.Results;

namespace Shp.Business.Abstract
{
    public interface IUserService
    {
        IResult AddUser(User user);
        User GetUserByEmail(string email);
        IEnumerable<OperationClaims> GetClaims(User user);
    }
}
