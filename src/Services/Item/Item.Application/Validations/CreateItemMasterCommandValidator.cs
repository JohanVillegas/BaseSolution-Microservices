using FluentValidation;
using Item.Application.Commands;

using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Application.Validations
{
    public class CreateItemMasterCommandValidator: AbstractValidator<CreateItemMasterCommand>
    {
        public CreateItemMasterCommandValidator()
        {
            RuleFor(command => command.Number).NotEmpty();
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.ShortName).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.DateTime).NotEmpty();
            RuleFor(command => command.TypeId).NotEmpty().WithMessage("Es obligatorio asignar el tipo");
            RuleFor(command => command.UnitMeasureId).NotEmpty().WithMessage("Es obligatorio asignar la unidad de medida"); ;
        }
    }
}
