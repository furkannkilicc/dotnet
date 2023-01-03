using HelloWebapi.Common;
using System;
using System.Linq;
using FluentValidation;

namespace HelloWebapi.BookOperations.DeleteBook{

    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand> 
    {
        public DeleteBookCommandValidator()
        {
             RuleFor(command => command.BookId).GreaterThan(0);
            
        }
        
    }
}