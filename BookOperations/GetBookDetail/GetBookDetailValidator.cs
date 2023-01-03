using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using HelloWebapi.Common;
using HelloWebapi.DBOperations;

namespace HelloWebapi.BookOperations.GetBookDetail
{
    public class  GetBookDetailValidator : AbstractValidator<GetBookDetailQuery> {
         public GetBookDetailValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
             
        }
    }
}