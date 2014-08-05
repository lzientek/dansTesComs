using System;
using System.ComponentModel.DataAnnotations;

namespace DansTesComs.Core.Attribute.DateValidator
{
    /// <summary>
    /// Vérifie Si La date entré est bien inférieur 
    /// </summary>
    public sealed class DateMinAttribute : ValidationAttribute
    { 
        public DateTime MinimumDate { get; set; }

        /// <summary>
        /// Vérifie Si La date entré est bien inférieur
        /// </summary>
        /// <param name="minDate"></param>
        public DateMinAttribute(DateTime minDate)
        {
            MinimumDate = minDate;
        }

        public override bool IsValid(object value)
        {
            DateTime dateValue = (DateTime)value;
            return (dateValue <= MinimumDate);
        }
    }
}
