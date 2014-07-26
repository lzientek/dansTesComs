using System;
using System.Collections.Generic;
using DansTesComs.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.WebSite.Tests.Models
{
    [TestClass]
    public class CommentaireExterneTest
    {
        [TestMethod]
        public void SingleLineParse()
        {
           

        }


        [TestMethod]
        public void CommentAndPseudoTest()
        {
            var coms = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("    coucou > je suis belle", "coucou", "je suis belle"),
                new Tuple<string, string, string>("couou > ejaezij", "couou", "ejaezij"),
                new Tuple<string, string, string>(@"couou > eja@&#{[|`\ezij", "couou", @"eja@&#{[|`\ezij"),

            };
            foreach (var tuple in coms)
            {
                CommentaireExterne commentaire = new CommentaireExterne();



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
                

            }
        }

    }
}
