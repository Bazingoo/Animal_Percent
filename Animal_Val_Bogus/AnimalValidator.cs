using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Val_Bogus
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(animal => animal.Kind).NotEmpty()
                .WithMessage("Поле не може бути порожнім");
            RuleFor(animal => animal.Kind).MinimumLength(2)
                .WithMessage("Вид тварини введено не повністю");
            RuleFor(animal => animal.Kind).MaximumLength(15)
                .WithMessage("Перевищено кількість символів");

            RuleFor(animal => animal.Name).NotEmpty()
               .WithMessage("Поле не може бути порожнім");
            RuleFor(animal => animal.Name).MinimumLength(2)
                .WithMessage("Вид тварини введено не повністю");
            RuleFor(animal => animal.Name).MaximumLength(15)
                .WithMessage("Перевищено кількість символів");
        }
    }
}
