using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DansTesComs.Core.Enums;
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
                Assert.AreEqual(tuple.Item2, tuple.Item1.CommentairesExterneContents.Count);
            }

        }

        [TestMethod]
        public void CategoriesTest()
        {
            var list = new List<Tuple<IEnumerable<Categorie>, string>>
            {
                new Tuple<IEnumerable<Categorie>, string>(new List<Categorie>{Categorie.Trash,Categorie.Clash,Categorie.Fun,Categorie.Amoureux}, "1-2-3-4"),
                new Tuple<IEnumerable<Categorie>, string>(new List<Categorie>{Categorie.Fun,Categorie.Amoureux}, "3-4"),
                new Tuple<IEnumerable<Categorie>, string>(new List<Categorie>{Categorie.Fun,Categorie.Amoureux,Categorie.Con,Categorie.Jesaispas}, "3-4-5-6"),
            };

            foreach (var tuple in list)
            {
                var c = new CommentaireExterne() { CategorieEnum = tuple.Item1 };
                Assert.AreEqual(tuple.Item2, c.Categories);
            }

        }

        [TestMethod]
        public void CategoriesTest_stringToEnum()
        {
            var list = new List<Tuple<IEnumerable<Categorie>, string>>
            {
                new Tuple<IEnumerable<Categorie>, string>(new List<Categorie>{Categorie.Trash,Categorie.Clash,Categorie.Fun,Categorie.Amoureux}, "1-2-3-4"),
                new Tuple<IEnumerable<Categorie>, string>(new List<Categorie>{Categorie.Fun,Categorie.Amoureux}, "3-4"),
                new Tuple<IEnumerable<Categorie>, string>(new List<Categorie>{Categorie.Fun,Categorie.Amoureux,Categorie.Con,Categorie.Jesaispas}, "3-4-5-6"),
            };

            foreach (var tuple in list)
            {
                var c = new CommentaireExterne() { Categories = tuple.Item2 };
                CollectionAssert.AreEqual(tuple.Item1.ToArray(), c.CategorieEnum.ToArray());
            }

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CategoriesTest_stringToEnum_Exeption()
        {
            var list = "lucas";
            var c = new CommentaireExterne() { Categories = list };
            IEnumerable<Categorie> categorieEnum = c.CategorieEnum;
            var rien = categorieEnum.First();
        }

    }
}
