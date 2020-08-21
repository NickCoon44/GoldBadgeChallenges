using System;
using System.Collections.Generic;
using ChallengeThreeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgeRepo _repo;
        private List<string> _doorListOne = new List<string> { "A1", "A2" };
        private List<string> _doorListTwo = new List<string> { "B3", "B4" };

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();

            _repo.CreateNewBadge(123, _doorListOne, "FIRST");
            _repo.CreateNewBadge(456, _doorListTwo, "SECOND");
        }

        [TestMethod]
        public void PrintTest_VerifyBadgesCreatedAndWriteToConsole()
        {
            _repo.PrintAllBadges();
        }

        [TestMethod]
        public void GetBadge_ShouldContainAndMatchValues()
        {
            Badge badgeOne = _repo.GetBadge(123);
            Assert.IsTrue(badgeOne.Doors.Contains("A1"));
            Assert.AreEqual("FIRST", badgeOne.Name);

            Badge badgeTwo = _repo.GetBadge(456);
            Assert.IsTrue(badgeTwo.Doors.Contains("B4"));
            Assert.AreEqual("SECOND", badgeTwo.Name);
        }

        [TestMethod]
        public void GetStringOfDoorsByID_ShouldContainCorrectDoors()
        {
            string doorsOne = _repo.GetDoorsByID(123);
            Assert.IsTrue(doorsOne.Contains("A1"));
            Assert.IsTrue(doorsOne.Contains("A2"));

            string doorsTwo = _repo.GetDoorsByID(456);
            Assert.IsTrue(doorsTwo.Contains("B3"));
            Assert.IsTrue(doorsTwo.Contains("B4"));
        }

        [TestMethod]
        public void AddNewDoors_ShouldContainNewDoors()
        {
            List<string> newDoors = new List<string> {"A3", "A4" };
            _repo.AddDoor(123, newDoors);
            Badge target = _repo.GetBadge(123);
            Assert.IsTrue(target.Doors.Contains("A3"));
            Assert.IsTrue(target.Doors.Contains("A4"));
        }

        [TestMethod]
        public void DeleteSingleDoor_ShouldNotContainDoor()
        {
            Badge target = _repo.GetBadge(123);
            _repo.RemoveDoor(target, "A2");
            Assert.IsFalse(target.Doors.Contains("A2"));
        }

        [TestMethod]
        public void DeleteAllDoors_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.DeleteDoors(456));
        }
    }
}
