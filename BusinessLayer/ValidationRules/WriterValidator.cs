using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator :AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan alanı boş geçilemez");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("soyadı 50 karakterden fazla olmaz");

            RuleFor(p => p.WriterAbout).Must(StartWithA).WithMessage("Hakkımda kısmında en az 1 tane a harfi olmak zorunda!!");

        }
        private bool StartWithA(string arg)
        {
            return arg.Contains("A".ToLower());
        }
    }
}
