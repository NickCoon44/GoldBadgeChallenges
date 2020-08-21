using System;
using System.Collections.Generic;
using System.Security.Claims;
using ChallengeOneClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneTests
{
    [TestClass]
    public class CafeRepoTests
    {
        private CafeRepo _repo;
        private MenuItem _menuItem;
        private MenuItem _menuItemTwo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepo();

            // Setting up Dummy Menu Item Data
            _menuItem = new MenuItem(1, "Hamburger", "It's like a sandwich, but way better.", new List<string>(), 1.99m);
            _menuItem.AddIngredient("Beef");
            _menuItem.AddIngredient("Buns");
            _menuItem.AddIngredient("Pickles");

            _menuItemTwo = new MenuItem(2, "Cheeseburger", "It's like a Hamburger, but way better.", new List<string>(), 2.99m);
            _menuItemTwo.AddIngredient("Beef");
            _menuItemTwo.AddIngredient("Buns");
            _menuItemTwo.AddIngredient("Pickles");
            _menuItemTwo.AddIngredient("Cheese");

            // Add Dummy Menu Items to Repository
            _repo.AddToMenu(_menuItem);
            _repo.AddToMenu(_menuItemTwo);

        }
        
        [TestMethod]
        public void PrintMenu_ShouldPrintCorrectMenuInfo()
        {   
            // Act
            _repo.PrintMenu();
            // Assert (Prints to console, from the method.)
            // Also verifies AddToMenu Method
        }

        [TestMethod]
        public void RemoveItemByNumber_ShouldReturnCorrectBool()
        {
            // Act
            bool isRemoved = _repo.RemoveFromMenu(1);
            //Assert
            Assert.IsTrue(isRemoved);

        }

        [TestMethod]
        public void GetMenuItemByNumber_PropertiesShouldMatch()
        {
            MenuItem expected = _menuItem;
            MenuItem actual = _repo.GetByNumber(1);

            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Description, actual.Description);

        }

        [TestMethod]
        public void AfterRemoval_ShouldShiftLargerNumbersDown()
        {
            _repo.RemoveFromMenu(1);
            // Assert
            Assert.AreEqual(1, _menuItemTwo.Number);
        }
    }
}
