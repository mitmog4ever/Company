using System;
using System.Collections.Generic;
using DAL;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCompany
{
    [TestClass]
    public class UnitTestBusinessCompany
    {
        [TestMethod]
        public void TestMethodGetListCAT()
        {
            //Arrange : préparer le scénario I/O
              // input : nothing
              // output : list of categories

            List<Categorie> lCatAttendu = new List<Categorie>
             {
                 new Categorie () {id_cat = 1 ,description_cat =  "Test" },
                 new Categorie () {id_cat = 2 ,description_cat =  "RH" }

             };
          
            //Act : Exécuter la méthode
            var busComp = new BusinessCompany();
            var lCatObtenu = busComp.GetListeCategorie();

            //Assert : s'assurer que le résultat obtenu = attendu
            Assert.AreEqual(lCatAttendu.Count, lCatObtenu.Count);
            for (int i = 0; i < lCatAttendu.Count; i++)
            {
                Assert.AreEqual(lCatAttendu[i].id_cat, lCatObtenu[i].id_cat);
                Assert.AreEqual(lCatAttendu[i].description_cat, lCatObtenu[i].description_cat);
            }

        }

    }
}
