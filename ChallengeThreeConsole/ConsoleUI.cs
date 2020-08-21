using ChallengeThreeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{
    class ConsoleUI
    {
        private BadgeRepo _repo = new BadgeRepo();
        private bool _isRunning = true;
        public void Start()
        {
            SeedBadges();
            RunMenu();
        }
        private void RunMenu()
        {
            while (_isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello SecAdmin, What Do You Want?\n" +
                    "---------------------------------\n" +
                    "1. Build-a-Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditDoors();
                        break;
                    case "3":
                        Console.Clear();
                        _repo.PrintAllBadges();
                        break;
                    case "4":
                        _isRunning = false;
                        return;
                    default:
                        Console.WriteLine("Invalid. Try Again.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press Any Key to Return...");
                Console.ReadKey();
            }
        }

        private void AddBadge()
        {
            Console.Clear();
            Console.Write("Input Name: ");
            string name = Console.ReadLine();

            Console.Write("Input Badge #: ");
            int badgeID = int.Parse(Console.ReadLine());

            List<string> doors = GetMoreDoors();

            _repo.CreateNewBadge(badgeID, doors, name);
            Console.WriteLine("Badge Created and Added...");
        }

        private List<string> GetMoreDoors()
        {
            List<string> doors = new List<string>();
            Console.WriteLine("More Door Access: Enter '/' when complete.");

            while (true)
            {
                Console.Write("Add a Door: ");
                string input = Console.ReadLine().ToUpper();
                if (input != "/")
                {
                    doors.Add(input);
                }
                else break;
            }
            return doors;
        }

        private void EditDoors()
        {
            Console.Clear();
            Console.WriteLine("Which Badge # Would You Like To Edit?");
            int badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine();
            string doorList = _repo.GetDoorsByID(badgeID);
            Console.WriteLine($"Badge {badgeID} Has Access To: " + doorList + "\n");
            if (doorList == "Badge Not Found") { return; }
            Console.WriteLine(
                "Select an Option:\n" +
                "   1. Add Doors\n" +
                "   2. Remove a Door\n" +
                "   3. Revoke All Access\n" +
                "   4. Cancel\n");
            string userInput = Console.ReadLine();
            SelectEdit(userInput, badgeID);
        }

        private void SelectEdit(string input, int badgeID)
        {
            bool notCancel = true;
            while (notCancel)
            {
                switch (input)
                {
                    case "1":
                        List<string> newRange = GetMoreDoors();
                        _repo.AddDoor(badgeID, newRange);
                        return;
                    case "2":
                        Remove(badgeID);
                        return;
                    case "3":
                        _repo.DeleteDoors(badgeID);
                        return;
                    case "4":
                        notCancel = false;
                        break;
                    default:
                        Console.WriteLine("Invalid. Try Again.");
                        break;
                }
            }
            Console.WriteLine("Edit Canceled.");
        }
        private void Remove(int badgeID)
        {
            Badge targetBadge = _repo.GetBadge(badgeID);
            Console.WriteLine("Which Door Would You Like To Remove?");
            string door = Console.ReadLine().ToUpper();
            _repo.RemoveDoor(targetBadge, door);
            Console.WriteLine($"Badge {badgeID} Has Access To: " + _repo.GetDoorsByID(badgeID) + "\n");
        }

        private void SeedBadges()
        {
            List<string> doorListOne = new List<string> { "A1", "A2" };
            List<string> doorListTwo = new List<string> { "B1" };
            List<string> doorListThree = new List<string> { "A1", "B2", "C3" };
            _repo.CreateNewBadge(12345, doorListOne, "FIRST");
            _repo.CreateNewBadge(67890, doorListTwo, "SECOND");
            _repo.CreateNewBadge(54321, doorListThree, "THIRD");
        }
    }
}
