using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter veri giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter veri girilebilir");


        }
    }
}
