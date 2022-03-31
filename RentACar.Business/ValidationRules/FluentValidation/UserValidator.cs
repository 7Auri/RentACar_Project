using FluentValidation;
using RentACar.Core.Entities.Concrete;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
   public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.Email).EmailAddress().NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(u=>u.FirstName).NotEmpty().WithMessage("Firstname cannot be empty");
            RuleFor(u=>u.LastName).NotEmpty().WithMessage("Lastname cannot be empty");
            RuleFor(u=>u.Password).NotEmpty().MinimumLength(6).Must(HasValidPassword);
        }
        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
}
