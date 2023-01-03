using System;
using FluentValidation;

namespace HelloWebapi.BookOperations.CreateBook{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
            public CreateBookCommandValidator()
            {
                RuleFor(command => command.Model.GenreId).GreaterThan(0);
                RuleFor(command => command.Model.PageCount).GreaterThan(0);
                RuleFor(Command => Command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date );
                RuleFor(Commamd => Commamd.Model.Title).NotEmpty().MinimumLength(4);
                
            }
    }
}