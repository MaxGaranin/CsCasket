﻿using System.Globalization;
using System.Windows.Controls;
using WpfSamples.Utils;

namespace WpfSamples.WpfInfrastructure.ValidationRules
{
    public class PositiveDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value as string;
            input = input.DecSepToSys();

            double result;
            var status = double.TryParse(input, out result);
            if (!status)
                return new ValidationResult(false, "Значение должно быть числовым");

            if (result < 0)
                return new ValidationResult(false, "Значение должно быть положительным числом");

            return ValidationResult.ValidResult;
        }

    }
}