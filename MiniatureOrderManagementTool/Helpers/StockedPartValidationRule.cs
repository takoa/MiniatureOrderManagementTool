using MiniatureOrderManagementTool.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace MiniatureOrderManagementTool.Helpers
{
    public class StockedPartValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            StockedPart stockedPart = (StockedPart)((BindingGroup)value).Items[0];

            if (0 <= stockedPart.Count
                && 0 <= stockedPart.TimeSpent 
                && 0 <= stockedPart.UnitPrice
                && 0 <= stockedPart.MaterialCost)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "不正な値が含まれています");
            }
        }
    }
}
