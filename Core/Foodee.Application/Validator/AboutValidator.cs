using FluentValidation;
using Foodee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Validator
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("About title is required.").MinimumLength(3).WithMessage("At la least 3 character.").MaximumLength(15);
            RuleFor(x => x.Description).NotNull().WithMessage("About description is required.").MinimumLength(3).WithMessage("At least 3 character.").MaximumLength(15);
            RuleFor(x => x.CoverImageUrl).NotNull().WithMessage("Bos birakma");
        }
    }
}
