using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Core.Models;

namespace DansTesComs.Core.Helpers
{
    public static class TriNote
    {
        public static double CoefPlusMoins(int nbMoins, int nbPlus)
        {
            if (nbMoins == 0)
            {
                if (nbPlus == 0)
                {
                    return -0.00000001;
                }
                nbMoins = 1;
            }
            var ratio = nbPlus / (double)nbMoins;
            //ratio -1 si plus de moins que de plus ca deviens négatif
            return (ratio - 1) * (nbMoins + nbPlus);
        }

        public static double CoefPlusMoins(CommentaireExterne commentaire)
        {
            return CoefPlusMoins(commentaire.Notes.Count(n => n.NoteValue == NoteValue.Moins),
                commentaire.Notes.Count(n => n.NoteValue == NoteValue.Plus));
        }
    }
}
