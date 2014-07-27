using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DansTesComs.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.Core.Tests.Models
{
    [TestClass]
    public class CommentaireExterneTest
    {
        [TestMethod]
        public void RemoveEmptyComsTest()
        {
            var list = new List<Tuple<CommentaireExterne, int>>
            {
                new Tuple<CommentaireExterne, int>(new CommentaireExterne()
                {
                    CommentairesExterneContents = new Collection<CommentairesExterneContent>()
                    {
                        new CommentairesExterneContent {Commentaire = "test", Pseudo = "zezef"},
                        new CommentairesExterneContent{Commentaire = "eovnr ve",Pseudo = "ononfezf"},
                        new CommentairesExterneContent{Commentaire = "eovnr ve",Pseudo = " "},
                    },
                }, 2),
                 new Tuple<CommentaireExterne, int>(new CommentaireExterne()
                {
                    CommentairesExterneContents = new Collection<CommentairesExterneContent>()
                    {
                        new CommentairesExterneContent {Commentaire = "test", Pseudo = "zezef"},
                        new CommentairesExterneContent{Commentaire = "eovnr ve",Pseudo = "ononfezf"},
                        new CommentairesExterneContent{Commentaire = "eovnr ve",Pseudo = " "},
                        new CommentairesExterneContent{Commentaire = "",Pseudo = "e"},
                        new CommentairesExterneContent{Commentaire = " ve",Pseudo = "e"},
                    },
                }, 3),
                 new Tuple<CommentaireExterne, int>(new CommentaireExterne()
                {
                    CommentairesExterneContents = new Collection<CommentairesExterneContent>()
                    {
                        new CommentairesExterneContent {Commentaire = "test", Pseudo = "zezef"},
                        new CommentairesExterneContent{Commentaire = "eovnr|ve",Pseudo = "ononfezf"},
                        new CommentairesExterneContent{Commentaire = "eovnr ve",Pseudo = "0"},
                        new CommentairesExterneContent{Commentaire = " eve",Pseudo = "0"},
                        new CommentairesExterneContent{Commentaire = "eovnr ve",Pseudo = "0"},
                    },
                }, 5)

            };


            foreach (var tuple in list)
            {
                tuple.Item1.RemoveEmptyComs();
                Assert.AreEqual(tuple.Item2,tuple.Item1.CommentairesExterneContents.Count);
            }

        }
    }
}
