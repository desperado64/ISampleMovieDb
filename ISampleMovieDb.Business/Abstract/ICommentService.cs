using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleCommentDb.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null);        
        Comment Get(int id);
        Comment Get(Expression<Func<Comment, bool>> filter);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
