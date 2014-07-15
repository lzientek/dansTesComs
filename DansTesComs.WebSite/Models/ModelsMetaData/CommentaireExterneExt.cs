using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using DansTesComs.Core;

namespace DansTesComs.WebSite.Models
{
    [MetadataType(typeof(CommentaireExterneMetaData))]
    public partial class CommentaireExterne
    {
        public IEnumerable<CommentaireParse> ParseContent(string content)
        {
            foreach (var ligne in content.Split(new[] { Environment.NewLine },
                                                StringSplitOptions.RemoveEmptyEntries))
            {
                if (Regex.IsMatch(ligne, RegexPattern.CommentaireExtRegex))
                {
                    var splitedString = ligne.Split(new[]{" > "}, StringSplitOptions.None);

                    //calcule du nombre de caractere ' ' au debut
                    int i = 0;
                    while (splitedString[0].ToCharArray()[i] == ' '){i++;}

                    int niveau = i/4;

                    yield return new CommentaireParse
                    {
                        Pseudo = splitedString[0].Trim(),
                        Commentaire = splitedString[1].Trim(),
                        Niveau = niveau
                    };
                }
            }
           
        }
    }

    public class CommentaireParse
    {
        public string Pseudo { get; set; }

        public string Commentaire { get; set; }

        public int Niveau { get; set; }
        
    }

    public class CommentaireExterneMetaData
    {
        
    }
}