using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DansTesComs.Core.Attribute.CollectionValidator
{
    public class CollectionMinValueAttribute : ValidationAttribute
    {
        public int MinimumCount { get; set; }

        /// <summary>
        /// Verifie qu'il y est au moins un certain nombre d'objet dans la collection
        /// </summary>
        /// <param name="minDate"></param>
        public CollectionMinValueAttribute()
        {
            MinimumCount = 1;
        }

        public override bool IsValid(object value)
        {
            var collection = value as ICollection;
            if (collection != null)
            {
                return collection.Count >= MinimumCount;
            }
            return false;
        }
    }
}
