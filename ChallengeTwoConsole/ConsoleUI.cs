using ChallengeTwoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole
{
    public class ConsoleUI
    {
        private ClaimRepo _repo = new ClaimRepo();
        private bool _isRunning = true;
        public void Start()
        {
            SeedClaims();
            RunConsole();
        }
        private void RunConsole()
        {
            
            while (_isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Modify An Existing Claim\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        _repo.DisplayAllClaims();
                        break;
                    case "2":
                        ShowNextClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                    case "4":
                        UpdateMenu();
                        break;
                    case "5":
                        _isRunning = false;
                        return;
                }
                Console.WriteLine();
                Console.WriteLine("Press a Key to Return to Menu...");
                Console.ReadKey();
            }
        }

        private void ShowNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:\n");
            Claim claim = _repo.CheckFirstClaim();
            _repo.DisplayClaim(claim);
            HandleOrNot();
        }
        private void HandleOrNot()
        {
            Console.Write("Do you want to deal with this claim now (y/n)?");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    _repo.RemoveFromQueue();
                    Console.WriteLine("Removed from Queue.");
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Invalid.");
                    break;
            }
        }
        private void AddClaim()
        {
            Console.Write("Enter the Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Claim Type:");
            ClaimType type = GetClaimType();

            Console.Write("Enter a Description: ");
            string description = Console.ReadLine();

            Console.Write("Amount of Damage: $");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Date of Incident: ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            Claim newClaim = new Claim(claimID, type, description, amount, dateOfIncident, dateOfClaim);

            if (newClaim.IsValid) { Console.WriteLine("This Claim is Valid.\n"); }
            else Console.WriteLine("This Claim is Not Valid.\n");

            Console.WriteLine("Claim Added to Queue.");
            _repo.AddToQueue(newClaim);
        }
        private ClaimType GetClaimType()
        {
            Console.WriteLine(
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            while(true)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                    case "car":
                        return ClaimType.Car;
                    case "2":
                    case "home":
                        return ClaimType.Home;
                    case "3":
                    case "theft":
                        return ClaimType.Theft;
                    default:
                        Console.WriteLine("Invalid. Try Again.");
                        break;
                }
            }
        }
        private void UpdateMenu()
        {
            Console.Clear();
            //while (true)
            //{
            //    Console.Write("Enter Claim ID: ");
            //    Claim claim = _repo.GetClaimByID(int.Parse(Console.ReadLine()));
            //    if (claim != null) { break; }
            //}
            int claimID = int.Parse(Console.ReadLine());
            Console.WriteLine("What do you need to modify?\n" +
                "1. Claim Type\n" +
                "2. Description\n" +
                "3. Amount\n" +
                "4. Incident Date\n" +
                "5. Claim Date\n" +
                "6. Cancel\n");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Select a Type:");
                        ClaimType type = GetClaimType();
                        _repo.ModifyClaimType(claimID, type);
                        return;
                    case "2":
                        Console.WriteLine("Type New Description:");
                        _repo.ModifyClaimDescription(claimID, Console.ReadLine());
                        return;
                    case "3":
                        Console.Write("Type New Amount: $");
                        _repo.ModifyClaimAmount(claimID, decimal.Parse(Console.ReadLine()));
                        return;
                    case "4":
                        Console.Write("Enter New Date: ");
                        _repo.ModifyIncidentDate(claimID, DateTime.Parse(Console.ReadLine()));
                        return;
                    case "5":
                        Console.Write("Enter New Date: ");
                        _repo.ModifyClaimDate(claimID, DateTime.Parse(Console.ReadLine()));
                        return;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid Try Again.\n");
                        break;
                }
            }
        }
        private void SeedClaims()
        {
            _repo.AddToQueue(new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27)));
            _repo.AddToQueue(new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12)));
            _repo.AddToQueue(new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01)));
        }
    }
}
