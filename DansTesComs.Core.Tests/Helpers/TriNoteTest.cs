using System;
using DansTesComs.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.Core.Tests.Helpers
{
    [TestClass]
    public class TriNoteTest
    {
        [TestMethod]
        public void TestCoefPlusMoins_valeur_du_coef_positif()
        {
            Assert.IsTrue(TriNote.CoefPlusMoins(10, 11) > 1);
            Assert.IsTrue(TriNote.CoefPlusMoins(10, 100) > 1);
            Assert.IsTrue(TriNote.CoefPlusMoins(10000, 10001) > 1);
        }

        [TestMethod]
        public void TestCoefPlusMoins_valeur_du_coef_negatif()
        {
            Assert.IsTrue(TriNote.CoefPlusMoins(11,10) < 1);
            Assert.IsTrue(TriNote.CoefPlusMoins(100, 10) < 1);
            Assert.IsTrue(TriNote.CoefPlusMoins(10001, 10000) < 1);
        }

        [TestMethod]
        public void TestCoefPlusMoins_test0()
        {
            Assert.IsTrue(TriNote.CoefPlusMoins(11, 0) < 1);
            Assert.IsTrue(TriNote.CoefPlusMoins(0, 10) > 1);
            Assert.IsTrue(TriNote.CoefPlusMoins(10001, 0) < 1);
        }

        [TestMethod]
        public void TestCoefPlusMoins_Compartif_attendu()
        {
            Assert.IsTrue(TriNote.CoefPlusMoins(1, 1) > TriNote.CoefPlusMoins(11, 0));
            Assert.IsTrue(TriNote.CoefPlusMoins(1, 1) > TriNote.CoefPlusMoins(11, 10));
            Assert.IsTrue(TriNote.CoefPlusMoins(10001, 12000) > TriNote.CoefPlusMoins(11, 100));
            Assert.IsTrue(TriNote.CoefPlusMoins(99, 100) < TriNote.CoefPlusMoins(11, 100));
        }
    }
}
