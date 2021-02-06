using System;
using System.Collections.Generic;
using System.Text;
using ISampleMovieDb.Entities.Concrete;

namespace ISampleMovieDb.DataAccess.Abstract
{
    public interface IMailAdressDal : IEntityRepository<MailAdress>
    {
    }
}
