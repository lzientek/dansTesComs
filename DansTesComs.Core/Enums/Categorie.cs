using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace DansTesComs.Core.Enums
{
    public enum Categorie
    {
        Trash = 1,
        Clash,
        Fun,
        Amoureux,
        Con,
        Jesaispas,
    }

    internal static class CategorieHelper
    {
        internal static string EnumToSaveString(this IEnumerable<Categorie> categories)
        {
            return string.Join("-", categories.Select(c=>(int)c));
        }

        internal static  IEnumerable<Categorie> StringToCategories(this string categories)
        {
            foreach (string c in categories.Split('-'))
                yield return (Categorie) int.Parse(c);
        }
    }

}
