using ISampleCommentDb.Business.Abstract;
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
    public class CommentManager : ICommentService
    {
        private ICommentDal commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            ValidationTool.Validate(new CommentValidator(), comment);
            commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            commentDal.Delete(comment);
        }

        public Comment Get(int id)
        {
            return commentDal.Get(x => x.ID == id);
            
        }

        public Comment Get(Expression<Func<Comment, bool>> filter)
        {
            return commentDal.Get(filter);
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            return commentDal.GetAll(filter);
        }

        public void Update(Comment comment)
        {
            ValidationTool.Validate(new CommentValidator(), comment);
            commentDal.Update(comment);
        }
    }
}
