using HomeBudget.App.Common;
using HomeBudget.Domain.Common;
using HomeBudget.Domain.Entity;

namespace HomeBudget.App.helpers
{
    public class UserInputMethods: HelpersMethodsBase
    {
        public static DateTime GetInputDate()
        {
            DateTime purchaseDate;

            while (true)
            {
                Console.WriteLine("Enter purchase date (YYYY-MM-DD):");
                string inputDate = Console.ReadLine();

                if (DateTime.TryParse(inputDate, out purchaseDate))
                {
                    Console.WriteLine("ok");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date format. Please try again...");
                }
            }
            return purchaseDate;
        }

        public static decimal GetCost()
        {
            bool validCost = false;
            decimal price = 0;
            while (!validCost)
            {
                Console.WriteLine("Enter cost (XX,XX) PLN:");
                if (decimal.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("ok");
                    validCost = true;
                }
                else
                {
                    Console.WriteLine("Wrong value...");
                }
            }
            return price;
        }

        public static string GetExpenseName()
        {
            Console.WriteLine("Enter short description:");
            string ExpenseName = Console.ReadLine();
            return ExpenseName;
        }

        public static int GetIdToRemove() 
        {
            if (int.TryParse(Console.ReadLine(), out int idToRemove))
            {
                return idToRemove;
            }
            else
            {
                Console.WriteLine("Wrong value...");
                return 0;
            }
        }

        public static string GetBuyer(List<Buyer> buyersList)
        {
            if (buyersList.Count == 0)
            {
                Console.WriteLine("No buyers available. Please add buyers from main menu before recording expenses.");
                return null;
            }

            Console.WriteLine("Who paid for this shopping (choose number):");
            foreach (var person in buyersList)
            {
                Console.WriteLine($"{person.Id}. {person.Name}");
            }

            while (true)
            {
                string input = Console.ReadLine();
                int whoPaidInt;
                if (int.TryParse(input, out whoPaidInt))
                {
                    var selectedBuyer = buyersList.FirstOrDefault(buyer => buyer.Id == whoPaidInt);

                    if (selectedBuyer != null)
                    {
                        return selectedBuyer.Name;
                    }
                    else
                    {
                        Console.WriteLine("Choose valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
