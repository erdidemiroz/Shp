using System.Collections.Generic;
using Shp.Core.Entities.Concrete;

namespace Shp.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IEnumerable<OperationClaims> operationClaims);
    }
}
