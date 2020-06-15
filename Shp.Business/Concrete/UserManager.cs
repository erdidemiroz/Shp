using System.Collections.Generic;
using Shp.Business.Abstract;
using Shp.Business.Constants;
using Shp.Core.Entities.Concrete;
using Shp.Core.Utilities.Results;
using Shp.DataAccess.Concrete.EntityFramework;

namespace Shp.Business.Concrete
{
    public sealed class UserManager : IUserService
    {

        #region ctor

        private EfUserDal _efUserDal;

        public UserManager(EfUserDal efUserDal)
        {
            _efUserDal = efUserDal;
        }

        #endregion

        #region InsertUser

        public IResult InsertUser(User user)
        {
            _efUserDal.Add(user);
            return new SuccessResult(Messages<User>.EntityInserted);
        }

        #endregion

        #region GetUserByEmail

        public User GetUserByEmail(string email) => _efUserDal.Get(x => x.Email == email);

        #endregion

        #region GetClaims

        public IEnumerable<OperationClaims> GetClaims(User user) => _efUserDal.GetClaims(user);

        #endregion
    }
}
