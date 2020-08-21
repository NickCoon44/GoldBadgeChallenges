using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClasses
{
    public class Badge
    {
        public Badge(int badgeID, List<string> doors, string name)
        {
            BadgeID = badgeID;
            Doors = doors;
            Name = name;
        }
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
        public string Name { get; set; }
    }
}
