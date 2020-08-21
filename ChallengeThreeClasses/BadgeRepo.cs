using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClasses
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        // Create, Add
        public void CreateNewBadge(int badgeID, List<string> doors, string name)
        {
            Badge newBadge = new Badge(badgeID, doors, name);
            _badgeDictionary.Add(badgeID, newBadge);
        }

        // Read, Get
        public Badge GetBadge(int badgeID)
        {
            if (_badgeDictionary.ContainsKey(badgeID))
            {
                return _badgeDictionary[badgeID];
            }
            return null;
        }
        public string GetDoorsByID(int badgeID)
        {
            Badge targetBadge = GetBadge(badgeID);
            if (targetBadge != null)
            {
                return string.Join(", ", targetBadge.Doors);
            }
            return "Badge Not Found";
        }

        // Update Doors: Add and Delete
        public void AddDoor(int badgeID, List<string> newRange)
        {
            Badge targetBadge = GetBadge(badgeID);
            targetBadge.Doors.AddRange(newRange);
            if (targetBadge.Doors.Contains("All Access Revoked"))
            {
                RemoveDoor(targetBadge, "All Access Revoked");
            }
            Console.WriteLine("Doors Added.");
            Console.WriteLine($"Badge {badgeID} Has Access To: " + GetDoorsByID(badgeID) +"\n");
        }
        public void RemoveDoor(Badge targetBadge, string door)
        {

            if (targetBadge.Doors.Contains(door))
            {
                targetBadge.Doors.Remove(door);
                Console.WriteLine("Door Removed.");
            }
            else Console.WriteLine("Failed. Badge Does Not Have Access to Door.");

        }



        // Delete all doors from badge
        public bool DeleteDoors(int badgeID)
        {
            Badge targetBadge = GetBadge(badgeID);
            targetBadge.Doors = new List<string> { "All Access Revoked" };
            Console.WriteLine("All Access Revoked.");
            return (targetBadge.Doors.Contains("All Access Revoked"));
        }

        public void PrintAllBadges()
        {
            Console.WriteLine();
            Console.WriteLine($"{"Badge#", -15}{"Door Access", -15}");
            Console.WriteLine("------------------------------");
            foreach(KeyValuePair<int, Badge> badge in _badgeDictionary)
            {
                Console.WriteLine($"{badge.Key, -15}{GetDoorsByID(badge.Key), -15}");
            }
        }
    }
}
