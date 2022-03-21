using FluentValidation;
using RentACar.Entities;
using System;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.Descriptions).MinimumLength(2).MaximumLength(100).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty().GreaterThan(0);
            RuleFor(c=>c.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(c=>c.BrandId).NotEmpty().GreaterThan(0);
            /*RuleFor(c => c.Descriptions).Must(StartWithA);*/

        }

       /* private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }*/
    }
}
