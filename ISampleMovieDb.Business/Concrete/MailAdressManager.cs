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
    public class MailAdressManager : IMailAdressService
    {
        private IMailAdressDal mailAdressDal;

        public MailAdressManager(IMailAdressDal mailAdressDal)
        {
            this.mailAdressDal = mailAdressDal;
        }

        public void Add(MailAdress mailAdress)
        {
            ValidationTool.Validate(new MailAdressValidator(), mailAdress);
            mailAdressDal.Add(mailAdress);
        }

        public void Delete(MailAdress mailAdress)
        {
            mailAdressDal.Delete(mailAdress);
        }

        public MailAdress Get(int id)
        {
            return mailAdressDal.Get(x => x.ID == id);

        }

        public MailAdress Get(Expression<Func<MailAdress, bool>> filter)
        {
            return mailAdressDal.Get(filter);
        }

        public List<MailAdress> GetAll(Expression<Func<MailAdress, bool>> filter = null)
        {
            return mailAdressDal.GetAll(filter);
        }

        public void Update(MailAdress mailAdress)
        {
            ValidationTool.Validate(new MailAdressValidator(), mailAdress);
            mailAdressDal.Update(mailAdress);
        }
    }
}

