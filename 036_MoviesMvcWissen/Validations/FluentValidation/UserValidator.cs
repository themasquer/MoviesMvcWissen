using _036_MoviesMvcWissen.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Validations.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(e => e.UserName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(e => e.Password).NotEmpty().Length(5, 25);
        }
    }
}