using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Abstract
{
    public interface IMailAdressService
    {
        List<MailAdress> GetAll(Expression<Func<MailAdress, bool>> filter = null);
        MailAdress Get(int id);
        MailAdress Get(Expression<Func<MailAdress, bool>> filter);
        void Add(MailAdress mailAdress);
        void Update(MailAdress mailAdress);
        void Delete(MailAdress mailAdress);
    }
}
