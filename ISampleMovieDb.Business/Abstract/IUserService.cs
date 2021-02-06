using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User Get(int id);
        User Get(Expression<Func<User, bool>> filter);
        void Add(User user);
        void Update(User user);
    }
}
