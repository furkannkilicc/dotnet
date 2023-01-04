using FluentValidation;
using HelloWebapi.Common;
using System;
using System.Linq;

namespace HelloWebapi.BookOperations.UpdateBook{



    public  class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> 
    {
        public UpdateBookCommandValidator()
        {
                  RuleFor(command => command.BookId).GreaterThan(0);
                  RuleFor(command => command.Model.GenreId).GreaterThan(0);
                RuleFor(Commamd => Commamd.Model.Title).NotEmpty().MinimumLength(4);
                
            
        }
    }




    
}
