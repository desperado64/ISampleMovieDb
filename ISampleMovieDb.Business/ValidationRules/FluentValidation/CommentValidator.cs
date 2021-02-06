using FluentValidation;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Business.ValidationRules.FluentValidation
{
    class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.comment.Length).GreaterThan(5).WithMessage("Yorum Beş (5) Karakterden Uzun Olmalı");
            RuleFor(x => x.UserID).NotNull().WithMessage("Kullanıcı Belirtilmemiş.");
            RuleFor(x => x.MovieID).NotNull().WithMessage("Film Belirtilmemiş.");
        }
    }
}
