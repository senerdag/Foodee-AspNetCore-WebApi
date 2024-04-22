using FluentValidation;
using Foodee.Domain.Entities;
using Foodee.Dto.EventDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Validator
{
    public class EventValidator: AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Event description is required.").NotNull().WithMessage("Event title is description.").MinimumLength(3);

        }
    }
}
