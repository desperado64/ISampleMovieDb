using FluentValidation;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Business.ValidationRules.FluentValidation
{
    class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(x => x.rating).GreaterThan(0).WithMessage("Puan 0'dan Büyük Olmalıdır");
            RuleFor(x => x.rating).LessThanOrEqualTo(10).WithMessage("Puan 10'dan Büyük Olmamalıdır.");
            RuleFor(x => x.UserID).NotNull().WithMessage("Kullanıcı Belirtilmemiş.");
            RuleFor(x => x.MovieID).NotNull().WithMessage("Film Belirtilmemiş.");
        }
    }
}
