using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClasses
{
    public class Claim
    {
        public Claim() { }
        public Claim(int claimID, ClaimType type, string description, decimal amount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimID;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                double days = (DateOfClaim - DateOfIncident).TotalDays;
                return (days > 0 && days <= 30) ;
            }
        }
    }
    public enum ClaimType{Car, Home, Theft}
}
