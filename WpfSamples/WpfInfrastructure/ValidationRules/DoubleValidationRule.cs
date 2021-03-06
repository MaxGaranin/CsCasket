﻿using System.Globalization;
using System.Windows.Controls;
using WpfSamples.Utils;

namespace WpfSamples.WpfInfrastructure.ValidationRules
{
    public class DoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value as string;
            input = input.DecSepToSys();

            double result;
            var status = double.TryParse(input, out result);
            if (!status)
            {
                return new ValidationResult(false, "Значение должно быть числовым");
            }

            return ValidationResult.ValidResult;
        }
    }
}