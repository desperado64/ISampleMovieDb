using FluentValidation;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Business.ValidationRules.FluentValidation
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen Kullanıcı Adını Giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Kullanıcı Şifresini Giriniz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen E-posta Adresini Giriniz");
        }
    }
}
