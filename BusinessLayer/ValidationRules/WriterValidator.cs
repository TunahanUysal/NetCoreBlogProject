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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu kısmı boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Bu kısmı boş geçemezsiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Bu kısmı boş geçemezsiniz");
            RuleFor(x => x.WriterImage).MaximumLength(100).WithMessage("Maksimum 100 karakter giriniz");



        }
    }
}
