using System;
using System.Collections;
using System.Collections.Generic;
using ChallengeTwoClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claimFirst;
        private Claim _claimSecond;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claimFirst = new Claim(1, ClaimType.Car, "The car lit on fire mysteriously...", 2000.50m, new DateTime(2019, 09, 22), new DateTime(2019, 09, 30));
            _claimSecond = new Claim(2, ClaimType.Theft, "TV was stolen and then returned broken", 600m, new DateTime(2020, 04, 21), new DateTime(2020, 06, 05));

            _repo.AddToQueue(_claimFirst);
            _repo.AddToQueue(_claimSecond);
        }

        [TestMethod]
        public void PeekQueue_ShouldMatchFirstClaim()
        {
            // Also verifies AddToQueue Method.
            Claim expected = _claimFirst;
            Claim actual = _repo.CheckFirstClaim();

            Assert.AreEqual(expected.ClaimID, actual.ClaimID);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.DateOfIncident, actual.DateOfIncident);
            Assert.AreEqual(expected.DateOfClaim, actual.DateOfClaim);
        }

        [TestMethod]
        public void GetClaimByID_ShouldMatchSecondClaim()
        {
            // Also verifies AddToQueue Method.
            Claim expected = _claimSecond;
            Claim actual = _repo.GetClaimByID(2);

            Assert.AreEqual(expected.ClaimID, actual.ClaimID);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.DateOfIncident, actual.DateOfIncident);
            Assert.AreEqual(expected.DateOfClaim, actual.DateOfClaim);
        }

        [TestMethod]
        public void DisplayClaims_ShouldPrintSeedClaimsToConsole()
        {
            _repo.DisplayClaim(_claimFirst);
            Console.WriteLine("---------------------------");
            _repo.DisplayClaim(_claimSecond);
            Console.WriteLine("---------------------------");
            _repo.DisplayAllClaims();
        }

        [TestMethod]
        public void ModifyClaimProperties_ShouldBeTrueAndEqual()
        {
            bool wasTypeModified = _repo.ModifyClaimType(2, ClaimType.Home);
            Assert.IsTrue(wasTypeModified);
            Assert.AreEqual(ClaimType.Home, _claimSecond.Type);

            bool wasDescriptionModified = _repo.ModifyClaimDescription(2, "banana");
            Assert.IsTrue(wasDescriptionModified);
            Assert.AreEqual("banana", _claimSecond.Description);

            bool wasAmountModified = _repo.ModifyClaimAmount(2, 2.20m);
            Assert.IsTrue(wasAmountModified);
            Assert.AreEqual(2.20m, _claimSecond.Amount);

            DateTime testDate = new DateTime(1993, 2, 2);
            bool wasIncidentDateModified = _repo.ModifyIncidentDate(2, testDate);
            Assert.IsTrue(wasIncidentDateModified);
            Assert.AreEqual(testDate, _claimSecond.DateOfIncident);

            bool wasClaimDateModified = _repo.ModifyClaimDate(2, DateTime.Today);
            Assert.IsTrue(wasClaimDateModified);
            Assert.AreEqual(DateTime.Today, _claimSecond.DateOfClaim);
        }

        [TestMethod]
        public void Dequeue_PeekShouldBeSecondClaim()
        {
            _repo.RemoveFromQueue();

            Claim expected = _claimSecond;
            Claim actual = _repo.CheckFirstClaim();

            Assert.AreEqual(expected.ClaimID, actual.ClaimID);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.DateOfIncident, actual.DateOfIncident);
            Assert.AreEqual(expected.DateOfClaim, actual.DateOfClaim);

        }
    }
}
