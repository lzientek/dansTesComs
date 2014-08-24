using System;
using System.Collections.Generic;
using DansTesComs.Core.Helpers;
using DansTesComs.Ressources.General;

namespace DansTesComs.Core.Models
{
    public class SearchResult
    {
        public SearchResult(CommentaireExterne commentaireExterne, string link = null)
        {
            ResultObject = commentaireExterne;
            Categorie = SearchRessources.CatCommentaireExterne;
            Link = link;
        }
        public string Link { get; set; }
        public object ResultObject { get; set; }
        public string Categorie { get; set; }
        public int Importance { get; set; }
    }

    public class SearchResultComparer : IComparer<SearchResult>
    {
        public int Compare(SearchResult x, SearchResult y)
        {
            if (x.Importance == y.Importance &&
                typeof(CommentaireExterne) == x.ResultObject.GetType() &&
                x.ResultObject.GetType() == y.ResultObject.GetType()
                )
            {
                var com1 = TriNote.CoefPlusMoins((CommentaireExterne)x.ResultObject);
                var com2 = TriNote.CoefPlusMoins((CommentaireExterne)y.ResultObject);
                if (com1 > com2)
                    return 1;
                if (com2 > com1)
                    return -1;
                return 0;
            }

            if (x.Importance > y.Importance)
                return 1;
            if (x.Importance < y.Importance)
                return -1;
            return 0;
        }
    }
}