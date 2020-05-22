using Komodo_Insurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Console
{
    class ProgramUI
    {
        List<string> newDoorList = new List<string>();
        BadgeRepo _badgeRepo = new BadgeRepo();
        Dictionary<int, List<string>> newBadgeID = new Dictionary<int, List<string>>();
        Badge newBadge = new Badge();

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("What action would you like to take:\n\t" +
                    "1. Create a new Badge\n\t" +
                    "2. Add door to Badge\n\t" +
                    "3. Remove all doors from Badge\n\t " +
                    "4. Show all created Badges" +
                    "5. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateNewBadge();
                        break;
                    case 2:
                        AddDoorToBadge();
                        break;
                    case 3:
                        RemoveAllDoors();
                        break;
                    case 4:
                        ShowAllBadges();
                        break;
                    case 5:
                        isRunning = false;
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        break;
                }

            }
        }
        public void CreateNewBadge()
        {
            Console.Clear();
            Console.WriteLine("Please enter ID number!");
            newBadge.BadgeNum = int.Parse(Console.ReadLine());
            bool addingDoor = true;
            while (addingDoor)
            {
                Console.WriteLine("Please enter the door to give access (A1, A2, B1, etc..)");
                string door = Console.ReadLine();
                newDoorList.Add(door);
                Console.WriteLine("add more doors? y/n");
                string reponse = Console.ReadLine();
                if (reponse == "n")
                {
                    addingDoor = false;
                }
                _badgeRepo.AddBadge(newBadge);

            }


        }
        public void AddDoorToBadge()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.ShowDoorList();


        }
        public void RemoveAllDoors()
        {

        }
        public void ShowAllBadges()
        {

        }
    }
}

