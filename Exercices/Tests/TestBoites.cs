using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boites;

namespace Tests
{
    [TestClass]
    public class TestBoites
    {

        [TestMethod]
        public void TestCompteurInstance()
        {
            Boite b;
            for (int i = 0; i < 5; i++)
                b = new Boite();
            Assert.AreEqual(Boite.CompteurInstance, 5);

        }

        [TestMethod]
        public void TestVolume()
        {
            Boite b = new Boite(10, 20, 30);
            Assert.AreEqual(b.Volume, 6000);
        }


    }
}
