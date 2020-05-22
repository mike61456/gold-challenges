using KomodoCafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsole
{
    class ProgramUI
    {
        private MenuListRepository _menuRepo = new MenuListRepository();


        //program starts
        public void Run()
        {
            StarterContent();
            Menu();
        }


        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Komodo Cafe Menu select an Option:\n" +
                    "1. Get a list of all the Recipes\n" +
                    "2. Add a recipe to the list\n" +
                    "3. Remove a Recipe from the list\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllContent();
                        break;
                    case "2":
                        CreateNewContent();
                        break;
                    case "3":
                        DeleteContent();
                        break;

                    case "4":
                        Console.WriteLine("GoodBye!");
                        keepRunning = false;

                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        } 
        
        private void DisplayAllContent()
        {
            Console.Clear();
            List<MenuList> listofContent = _menuRepo.GetMenuList();
            foreach(MenuList content in listofContent)
            {
                Console.WriteLine($"Name: {content.Name} Desc: {content.Description} \n" +
                    $"Ingredients: {content.Ingredients} Number: {content.Number}  Price: ${content.Price}");

            }

        }
        private void CreateNewContent()
        {
            Console.Clear();
            MenuList newContent = new MenuList();
            Console.WriteLine("What is the name of the Menu Item?");
            newContent.Name = Console.ReadLine();
            Console.WriteLine("Enter a Description");
            newContent.Description = Console.ReadLine();
            Console.WriteLine("What Ingredients are required?");
            newContent.Ingredients = Console.ReadLine();
            Console.WriteLine("What is the price?");
            string priceAsString = Console.ReadLine();
            newContent.Price = decimal.Parse(priceAsString);
            Console.WriteLine("What is the Meal #");
            string numberAsString = Console.ReadLine();
            newContent.Number = int.Parse(numberAsString);

            _menuRepo.AddMenuItem(newContent);
        }

        private void DeleteContent()
        {
            DisplayAllContent();
            Console.WriteLine("Enter the name that you want to delete");
            string input = Console.ReadLine();
            bool wasDeleted = _menuRepo.RemoveMenuItem(input);
            if (wasDeleted)
            {
                Console.WriteLine("Your object was deleted");
            }
            else
            {
                Console.WriteLine("Error deleting your entry");
            }
        }
        private void StarterContent()
        {
            MenuList first = new MenuList(5, "CheeseBurger", "Grilled burger on a bun w/ cheese", "Bun Ground Beef Cheese", 2.3m);
            _menuRepo.AddMenuItem(first);

        }
    
    }


}





















