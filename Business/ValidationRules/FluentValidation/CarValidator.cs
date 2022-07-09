﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
        }
    }
}
