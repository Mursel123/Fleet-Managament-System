using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Facturen.Create
{
    public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
    {
        public CreateDocumentCommandValidator()
        {
            RuleFor(x => x.FileData)
                .NotEmpty()
                .WithMessage("{PropertyName} is verplicht.");

            RuleFor(x => x.BestandType)
                .IsInEnum()
                .NotNull().WithMessage("{PropertyName} is verplicht.");
        }
    }
}
