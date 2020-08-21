using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClasses
{
    public class ClaimRepo
    {
        // Queue
        private readonly Queue<Claim> _claimQ = new Queue<Claim>();

        // Create, Enqueue
        public void AddToQueue(Claim claim)
        {
            _claimQ.Enqueue(claim);
        }

        // Read, Peek
        public Claim CheckFirstClaim()
        {
            return _claimQ.Peek();
        }
        public Claim GetClaimByID(int claimID)
        {
            foreach(Claim claim in _claimQ)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            Console.WriteLine("Claim ID Not Found.\n");
            return null;
        }
        public void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                $"Type: {claim.Type}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.Amount}\n" +
                $"DateOfIncident: {claim.DateOfIncident:MM/dd/yyyy}\n" +
                $"DateOfClaim: {claim.DateOfClaim:MM/dd/yyyy}\n" +
                $"IsValid: {claim.IsValid}\n");
        }
        public void DisplayAllClaims()
        {
            string[] titles = new string[] { "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid" };
            Console.WriteLine($"{titles[0], -10}{titles[1], -10}{titles[2], -30}{titles[3], -15}{titles[4], -20}{titles[5], -20}{titles[6], -15}");
            foreach(Claim claim in _claimQ)
            {
                Console.Write($"{claim.ClaimID,-10}{claim.Type,-10}{claim.Description, -30}${claim.Amount, -15}{claim.DateOfIncident, -20:MM/dd/yyyy}{claim.DateOfClaim, -20:MM/dd/yyyy}{claim.IsValid, -15}\n");
            }
        }

        // Update (individual properties)
        public bool ModifyClaimType(int claimID, ClaimType newType)
        {
            Claim claim = GetClaimByID(claimID);
            claim.Type = newType;
            Console.WriteLine("Claim Type Updated.\n");
            return (claim.Type == newType);
        }
        public bool ModifyClaimDescription(int claimID, string newDescription)
        {
            Claim claim = GetClaimByID(claimID);
            claim.Description = newDescription;
            Console.WriteLine("Description Updated.\n");
            return (claim.Description == newDescription);
        }
        public bool ModifyClaimAmount(int claimID, decimal newAmount)
        {
            Claim claim = GetClaimByID(claimID);
            claim.Amount = newAmount;
            Console.WriteLine("Amount Updated.\n");
            return (claim.Amount == newAmount);
        }
        public bool ModifyIncidentDate(int claimID, DateTime newDate)
        {
            Claim claim = GetClaimByID(claimID);
            claim.DateOfIncident = newDate;
            Console.WriteLine("Incident Date Updated.\n");
            return (claim.DateOfIncident == newDate);
        }
        public bool ModifyClaimDate(int claimID, DateTime newDate)
        {
            Claim claim = GetClaimByID(claimID);
            claim.DateOfClaim = newDate;
            Console.WriteLine("Claim Date Updated.\n");
            return (claim.DateOfClaim == newDate);
        }


        // Delete, Dequeue
        public Claim RemoveFromQueue()
        {
            return _claimQ.Dequeue();
        }
    }
}
