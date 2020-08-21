using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneClasses
{
    public class CafeRepo
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();


        // Create, Add
        public void AddToMenu(MenuItem item)
        {
            _menu.Add(item);
        }

        // Read, Print
        public List<MenuItem> GetMenu()
        {
            return _menu;
        }
        public MenuItem GetByNumber(int number)
        {
            foreach (MenuItem item in _menu)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }
            return null;
        }
        public void PrintMenu()
        {
            foreach(MenuItem item in _menu)
            {
                Console.WriteLine(
                    $"#{item.Number}\n" +
                    $"Meal: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"{item.Ingredients}\n" +
                    $"Price: ${item.Price}\n" +
                    $"\n");
            }
        }

        // Delete, Remove
        public bool RemoveFromMenu(int number)
        {
            MenuItem item = GetByNumber(number);
            if (item != null)
            {
                _menu.Remove(item);
                ShiftNumbersDown(number);
                return true;
            }
            else return false;
        }

        // Shift Menu Item Number
        private void ShiftNumbersDown(int number)
        {
            foreach(MenuItem item in _menu)
            {
                if(item.Number > number)
                {
                    item.Number--;
                }
            }
        }

    }
}
