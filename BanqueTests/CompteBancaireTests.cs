using System;
using CompteBanqueNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BanqueTests
{
    [TestClass]
    public class CompteBancaireTests
    {
        // Cas 3 : montant valide, il est soustrait du solde
        [TestMethod]
        public void VérifierDébitCompteCorrect()
        {
            // Arrange
            double soldeInitial = 500000;
            double montantDébit = 400000;
            double soldeAttendu = 100000;
            var cb = new CompteBancaire("Pr Doudou Fall", soldeInitial);

            // Act
            cb.Débiter(montantDébit);

            // Assert
            double soldeObtenu = cb.Solde;
            Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
        }

        // Cas 1 : débit supérieur au solde -> ArgumentOutOfRangeException
        [TestMethod]
        public void Débiter_MontantSupérieurAuSolde_LèveException()
        {
            var cb = new CompteBancaire("Pr Doudou Fall", 500000);

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => cb.Débiter(600000));
        }

        // Cas 2 : débit négatif -> ArgumentOutOfRangeException
        [TestMethod]
        public void Débiter_MontantNégatif_LèveException()
        {
            var cb = new CompteBancaire("Pr Doudou Fall", 500000);

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => cb.Débiter(-100));
        }
    }
}