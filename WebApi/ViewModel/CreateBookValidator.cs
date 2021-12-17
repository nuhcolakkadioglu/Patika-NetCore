using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModel
{
    public class CreateBookValidator:AbstractValidator<CreateBookModel>
    {
        public CreateBookValidator()
        {
            RuleFor(m => m.Title).NotNull().WithMessage("bu alan boş olamaz").MinimumLength(3);
            RuleFor(m => m.GenreId).GreaterThan(0);
            RuleFor(m => m.PageCount).GreaterThan(0);
            RuleFor(m => m.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
