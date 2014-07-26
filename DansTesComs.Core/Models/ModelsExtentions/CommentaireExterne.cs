using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using DansTesComs.Core.Models;
using DansTesComs.Ressources.CommentaireExterne;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof(CommentaireExterneMetaData))]
    public partial class CommentaireExterne
    {
        public void removeEmptyComs()
        {
            //on parcours a l'envers normal on supprime! si tu sais pas pourquoi google
            for (int i = CommentairesExterneContents.Count - 1; i >=0; i--)
            {
                var item = CommentairesExterneContents.ElementAt(i);
                if (string.IsNullOrEmpty(item.Commentaire) || string.IsNullOrEmpty(item.Pseudo))
                {
                    CommentairesExterneContents.Remove(item);
                }
            }
        }
    }


    public class CommentaireExterneMetaData
    {
        [MaxLength(50, ErrorMessageResourceType = typeof(CommentaireExterneRessources),ErrorMessageResourceName = "LongueurMax50")]
        [Required(ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "TitreObligatoire")]
        [Display(ResourceType = typeof(CommentaireExterneRessources) ,Name ="TitreLabel")]
        public string Titre { get; set; }

        [MaxLength(500, ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "LongueurMax500")]
        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(CommentaireExterneRessources), Name = "PublicationLabel")]
        public string Publication { get; set; }

        [MaxLength(200, ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "LongueurMax200Url")]
        [DataType(DataType.Url, ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "DoitEtreUnLien")]
        [Display(ResourceType = typeof(CommentaireExterneRessources), Name = "LienLabel")]
        public string Lien { get; set; }
    }

}