using Komodo_Claims_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Console
{
    class ProgramUI
    {
        ClaimRepo claimRepo = new ClaimRepo();
        Queue<Claims> claimQueue = new Queue<Claims>();

        public void RunMenu()
        {
            Claims auto = new Claims(1, "Auto", "Broken window", 125.00m, "12/12/2012", "12/20/2012", true);
            Claims home = new Claims(2, "Home", "Fire", 4000.00m, "11/15/2015", "12/25/2015", false);
            claimRepo.AddClaimToQueue(auto);
            claimRepo.AddClaimToQueue(home);
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:" +
                    "\n1. See all claims" +
                    "\n2. Take care of next claim" +
                    "\n3. Enter a new claim" +
                    "\n4. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1: 
                        ShowAllClaims();
                        break;
                    case 2:                         
                        WorkNextClaim();
                        break;
                    case 3: 
                        NewClaim();
                        break;
                    case 4: 
                        isRunning = false;
                        Console.WriteLine("Press any key to exit");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("invalid option");
                        break;
                }
            }
        }

        public void ShowAllClaims()
        {
            claimQueue = claimRepo.ShowClaimList();
            Console.Clear();

            Console.WriteLine("Claim ID# \t Type \t Description \t Claim Amount \t Date of Incident \t Date of Claim \t Is Valid");
            foreach (Claims claim in claimQueue)
            {
                Console.WriteLine($"{claim.ClaimID}\t {claim.Type}\t {claim.Description}\t {claim.ClaimAmount:c2}\t {claim.DateOfIncident}\t {claim.DateOfClaim}\t {claim.IsValid}");
            }
            Console.ReadLine();
        }

        public void NewClaim()
        {
            Claims claim = new Claims();
            Console.Clear();
            Console.WriteLine("What is the claim ID number?");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("What type of claim? car, home, or theft?");
            claim.Type = Console.ReadLine();

            Console.WriteLine("Describe the claim.");
            claim.Description = Console.ReadLine();

            Console.WriteLine("What is the dollar amount for this claim?");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("What was the date of the incident? mm/dd/yyyy");
            claim.DateOfIncident = Console.ReadLine();

            Console.WriteLine("What was the date that this incident was reported? mm/dd/yyyy");
            claim.DateOfClaim = Console.ReadLine();

            claim.IsValid = claimRepo.ValidDate(claim);

            claimRepo.AddClaimToQueue(claim);
        }

        public void WorkNextClaim()
        {
            claimQueue = claimRepo.NextClaim();
            Console.Clear();
            Console.WriteLine("The next claim is:");
            Console.WriteLine($"{claimQueue.Peek()}");

            Console.WriteLine("Would you like to handle this claim? (y/n)");
            string handleClaim = Console.ReadLine();
            if (handleClaim == "y")
            {
                claimRepo.RemoveClaim();
            }
        }
    }
}

