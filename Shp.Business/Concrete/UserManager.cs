using System.Collections.Generic;
using Shp.Business.Abstract;
using Shp.Business.Constants;
using Shp.Core.Entities.Concrete;
using Shp.Core.Utilities.Results;
using Shp.DataAccess.Abstract;

namespace Shp.Business.Concrete
{
    public sealed class UserManager : IUserService
    {

        #region ctor

        private IUserDal _efUserDal;

        public UserManager(IUserDal efUserDal)
        {
            _efUserDal = efUserDal;
        }

        #endregion

        #region Add

        public IResult Add(User user)
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
