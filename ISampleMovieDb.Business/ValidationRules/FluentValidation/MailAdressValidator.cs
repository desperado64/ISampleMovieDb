using FluentValidation;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Business.ValidationRules.FluentValidation
{
    class MailAdressValidator : AbstractValidator<MailAdress>
    {
        public MailAdressValidator()
        {
            RuleFor(x => x.AccountName).NotEmpty().WithMessage("Bir Hesap Adı Giriniz");
            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("E-posta Adı giriniz");            
            RuleFor(x => x.Username).EmailAddress().WithMessage("Uygun E-posta Adresini Giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("E-posta Şifresiniz Giriniz");
            RuleFor(x => x.Server).NotEmpty().WithMessage("E-posta Sunucu Adresini Giriniz");
            RuleFor(x => x.Port).NotNull().WithMessage("E-posta Portunu Giriniz");
            RuleFor(x => x.Port).GreaterThan(0).WithMessage("E-posta Portunu Sıfrıda Büyük Giriniz");
            RuleFor(x => x.SSL).NotNull().WithMessage("E-posta SSL Durumunu Giriniz");
        }
    }
}
