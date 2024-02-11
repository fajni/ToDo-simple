using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ObligationBusinessTests
    {
        private ObligationBusiness obligationBusiness = new ObligationBusiness();
        private Obligation obligation = new Obligation
        {
            GetSetUserId = 1,
            GetSetTitle = "Unit Test Obligation",
            GetSetDate = DateTime.Now,
            GetSetNote = "Note For Unit Test Obligation"
        };
        private List<Obligation> obligations = new List<Obligation>();

        [TestMethod]
        public void ConstructorTest()
        {
            obligationBusiness = new ObligationBusiness();
            Console.WriteLine(obligationBusiness.GetType());
            Assert.AreEqual(obligationBusiness.GetType(), new ObligationBusiness().GetType());
        }

        [TestMethod]
        public void GetAllObligationsTest()
        {
            obligations = obligationBusiness.GetAllObligations();
            Assert.IsNotNull(obligations);
        }

        [TestMethod]
        public void GetObligationsByUserIdTest1()
        {
            obligations = obligationBusiness.GetObligationsByUserId(1);
            int numberOfObligationsForUser= obligationBusiness.GetAllObligations().Count - obligations.Count;
            Assert.IsTrue(numberOfObligationsForUser>0);
        }

        [TestMethod]
        public void GetObligationsByUserIdTest2()
        {
            Assert.IsNotNull(obligationBusiness.GetObligationsByUserId(1));
        }

        [TestMethod]
        public void InsertObligationTest()
        {
            Assert.IsTrue(obligationBusiness.InsertObligation(obligation));
        }

        [TestMethod]
        public void DeleteObligationTest()
        {
            obligationBusiness.InsertObligation(obligation);
            Obligation newObligation = obligationBusiness.GetAllObligations().Where(o => o.GetSetTitle == obligation.GetSetTitle).ToList()[0];
            Assert.IsTrue(obligationBusiness.DeleteObligation(newObligation.GetSetId));
        }

        [TestMethod]
        public void UpdateObligationTest()
        {
            obligationBusiness.InsertObligation(obligation);
            Obligation newObligation = obligationBusiness.GetAllObligations().Where(o => o.GetSetTitle == obligation.GetSetTitle).ToList()[0];
            Assert.IsTrue(obligationBusiness.UpdateObligation(newObligation));
        }

        [TestCleanup]
        public void CleanUp()
        {
            foreach(var o in obligationBusiness.GetAllObligations())
            {
                if(o.GetSetTitle == obligation.GetSetTitle)
                {
                    obligationBusiness.DeleteObligation(o.GetSetId);
                }
            }
        }
    }
}
