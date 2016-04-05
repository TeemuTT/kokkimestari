/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 05/04/2016
* Author: Teemu Tuomela
*/

using System.Globalization;
using System.Windows.Controls;

namespace KokkimestariWPF
{
    class TextValidator : ValidationRule
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; } = int.MaxValue;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length >= Minimum && value.ToString().Length <= Maximum)
                return new ValidationResult(true, null);
            else if (value.ToString().Length > Maximum)
                return new ValidationResult(false, "Enintään " + Maximum + " merkkiä");
            else
                return new ValidationResult(false, "Pakollinen tieto.");
        }
    }
}
