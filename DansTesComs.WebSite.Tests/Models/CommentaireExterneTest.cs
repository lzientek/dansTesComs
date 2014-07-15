using System;
using System.Collections.Generic;
using DansTesComs.WebSite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.WebSite.Tests.Models
{
    [TestClass]
    public class CommentaireExterneTest
    {
        [TestMethod]
        public void SingleLineParse()
        {
            var coms = new List<Tuple<string, bool, int>>
            {
                new Tuple<string, bool, int>("    coucou > je suis belle", true, 1),
                new Tuple<string, bool, int>("couou> ejaezij", false, 0),
                new Tuple<string, bool, int>("couou > ejaezij", true, 0),
                new Tuple<string, bool, int>("    couou> ejaezij", false, 0),
                new Tuple<string, bool, int>("     couou > ejaezij", true, 1),
                new Tuple<string, bool, int>("        couou > ejaezij", true, 2),
            };
            foreach (var tuple in coms)
            {
                CommentaireExterne commentaire  = new CommentaireExterne();
                List<CommentaireParse> result = new List<CommentaireParse>(commentaire.ParseContent(tuple.Item1));
                if (tuple.Item2)
                {
                    Assert.IsNotNull(result[0]);
                    Assert.AreEqual(tuple.Item3,result[0].Niveau);
                }
                else
                {
                    Assert.AreEqual(result.Count,0);
                }
                
            }
        }

        [TestMethod]
        public void MultiLineParse()
        {
            var coms = new List<Tuple<string, bool, int>>//ligne valid nb ligne
            {
                new Tuple<string, bool, int>("    coucou > je suis belle"+
                    Environment.NewLine+
                    "couou > ejaezij", true, 2),
                new Tuple<string, bool, int>("couou > ejaezij"
                    +Environment.NewLine+
                    "    couou > ejaezij"
                    +Environment.NewLine+
                    "    couou > ejaezij", true, 3),
                new Tuple<string, bool, int>("couou >ejaezij"
                    +Environment.NewLine+
                    "    couou > ejaezij"
                    +Environment.NewLine+
                    "    couou > ejaezij", true,2),
                    new Tuple<string, bool, int>("couou >ejaezij"
                    +Environment.NewLine+
                    "    couou> ejaezij"
                    +Environment.NewLine+
                    "    couou >ejaezij", false, 0),
            };
            foreach (var tuple in coms)
            {
                CommentaireExterne commentaire = new CommentaireExterne();
                List<CommentaireParse> result = new List<CommentaireParse>(commentaire.ParseContent(tuple.Item1));
                if (tuple.Item2)
                {
                    Assert.IsNotNull(result[0]);
                    Assert.AreEqual(tuple.Item3, result.Count);
                }
                else
                {
                    Assert.AreEqual(result.Count, 0);
                }

            }
        }

    }
}
