using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.Utilities;
using ISampleMovieDb.Business.ValidationRules.FluentValidation;
using ISampleMovieDb.DataAccess.Abstract;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            userDal.Add(user);
        }

        public User Get(int id)
        {
            return userDal.Get(x => x.ID == id);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return userDal.Get(filter);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return userDal.GetAll(filter);
        }

        public void Update(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            userDal.Update(user);
        }
    }
}
