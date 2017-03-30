using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boites;

namespace Tests
{
    [TestClass]
    public class TestBoites
    {
        [TestMethod]
        public void TestVolume()
        {
            Boite b = new Boite(10.0, 20.0, 30.0);
            // Si test sur un résultat de double, il vaut mieux tester que la différence entre le résultat
            // attendu et le résultat obtenu est inférieure à 0.0...01.
            // (res test, val attendue, delta entre les 2 résultat)
            Assert.AreEqual(b.Volume, 6000.0, 0.0001);
        }

        [TestMethod]
        public void TestCompteurInstance()
        {
            Boite b;
            int valInit = Boite.CompteurInstance;
            for (int i = 0; i < 5; i++)
                b = new Boite();
            Assert.AreEqual(Boite.CompteurInstance - valInit, 5);
        }
    }
}
