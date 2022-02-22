﻿using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreateEventCommandValidator : UniClubAbstractValidator<CreateEventDto>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(e => e.StartDate)
                .NotNull().WithMessage("{PropertyName} is not null")
                .Must(BeAFutureDate).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.EndDate)
                .NotNull().WithMessage("{PropertyName} is not null")
                .Must(BeAFutureDate).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.Status)
                .IsInEnum();

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 50).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.MaxParticipants)
                .NotEmpty().WithMessage("{PropertyName} is invalid")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.Point)
                .NotEmpty().WithMessage("{PropertyName} is invalid")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
