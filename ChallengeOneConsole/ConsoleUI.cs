using ChallengeOneClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsole
{
    public class ConsoleUI
    {
        private readonly CafeRepo _repo = new CafeRepo();
        private bool _isRunning = true;
        public void Start()
        {
            SeedMenuItems();
            RunConsoleUI();
        }
        private void RunConsoleUI()
        {

            while (_isRunning)
            {
                Console.Clear();
                Console.WriteLine("Select an Option:\n" +
                    "1. Show List of Menu Items\n" +
                    "2. Create a New Menu Item\n" +
                    "3. Remove an Item from the Menu\n" +
                    "4. Exit");
                SelectOption();
            }
        }
        private void SelectOption()
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "show":
                        Console.Clear();
                        _repo.PrintMenu();
                        break;
                    case "2":
                    case "create":
                        CreateNewItem();
                        break;
                    case "3":
                    case "remove":
                        RemoveItem();
                        break;
                    case "4":
                    case "exit":
                        _isRunning = false;
                        return;
                    default:
                        return;
                }
                Console.WriteLine("Press a key to return to the menu...");
                Console.ReadKey();
                return;
            }
        }

        private void CreateNewItem()
        {
            Console.Clear();
            // Menu Item Number
            int itemNumber = _repo.GetMenu().Last().Number + 1;
            // Menu Item Name
            Console.Write("Enter the Item Name: ");
            string name = Console.ReadLine();
            // Description
            Console.Write("Describe it: ");
            string description = Console.ReadLine();
            // List of Ingredients
            List<string> ingredients = GetIngredients();
            // Price
            Console.Write("Price: ");
            decimal price;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal parsedNum))
                {
                    price = parsedNum;
                    break;
                }
                else Console.WriteLine("That is NOT a Price. Try Again.");
            }

            MenuItem newItem = new MenuItem(itemNumber, name, description, ingredients, price);
            _repo.AddToMenu(newItem);
        }

        private List<string> GetIngredients()
        {
            List<string> ingredients = new List<string>();
            Console.WriteLine("Ingredients List: Type '/' when complete.");
        
            while(true)
            {
                Console.Write("Add an Ingredient: ");
                string input = Console.ReadLine();
                if (input != "/")
                {
                    ingredients.Add(input);
                }
                else break;
            }
            return ingredients;
        }
        private void RemoveItem()
        {
            Console.Clear();
            Console.Write("Please type the Menu Item's Number: ");
            while (true)
            {
                string input = Console.ReadLine();
                bool wasParsed = int.TryParse(input, out int parsedNum);
                if (wasParsed)
                {
                    bool isRemoved = _repo.RemoveFromMenu(parsedNum);
                    if (isRemoved)
                    {
                        Console.WriteLine("Item Removed from Menu.");
                        return;
                    }
                    Console.Write("Item Not Found. "); 
                    TryAgain();
                    RemoveItem();
                    return;
                }
                else Console.Write("Invalid. Please Enter a Number: ");
            }
        }
        private void TryAgain()
        {
            Console.WriteLine("Try Again? Y/N");
            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                case "y":
                    return;
                case "no":
                case "n":
                    RunConsoleUI();
                    return;
                default:
                    TryAgain();
                    break;
            }
        }

        private void SeedMenuItems()
        {
            MenuItem hamburger = new MenuItem(1, "Hamburger", "It's like a sandwich, but way better.", new List<string>(), 1.99m);
            hamburger.AddIngredient("Beef");
            hamburger.AddIngredient("Buns");
            hamburger.AddIngredient("Pickles");

            MenuItem cheeseburger = new MenuItem(2, "Cheeseburger", "It's like a Hamburger, but way better.", new List<string>(), 2.99m);
            cheeseburger.AddIngredient("Beef");
            cheeseburger.AddIngredient("Buns");
            cheeseburger.AddIngredient("Pickles");
            cheeseburger.AddIngredient("Cheese");

            _repo.AddToMenu(hamburger);
            _repo.AddToMenu(cheeseburger);
        }
    }
}
