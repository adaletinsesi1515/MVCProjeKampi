using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz!!!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz!!!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adını en az 2 karakter olacak şekilde giriniz!!!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adını en fazla 50 karakter olacak şekilde giriniz!!!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında alanını boş geçemezsiniz!!!");
            //Burayı daha sonra büyük A harfini de kapsar şekilde güncellememiz lazım
            RuleFor(x => x.WriterAbout).Matches("a").WithMessage("Hakkında alanında mutlaka a harfi geçmelidir.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
        }
    }
}
