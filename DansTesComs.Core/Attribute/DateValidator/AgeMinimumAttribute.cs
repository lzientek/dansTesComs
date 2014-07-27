using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DansTesComs.Core.Attribute.DateValidator
{
    public sealed class AgeMinimumAttribute : ValidationAttribute
    {
        public int Age { get; set; }

        /// <summary>
        /// Vérifie Si La date de naissance corespond bien a un certain age
        /// </summary>
        /// <param name="age"></param>
        public AgeMinimumAttribute(int age)
        {
            Age = age;
        }

        public override bool IsValid(object value)
        {
            DateTime? naissance = value as DateTime?;
            if (naissance!=null)
            {
                return (naissance <= DateTime.Now.AddYears(0 - Age));                
            }
            return false;
        }
    }
}
