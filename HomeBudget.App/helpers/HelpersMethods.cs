using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.helpers
{
    public class HelpersMethods
    {
        public static DateTime GetDate()
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

        public static int GenerateNextId<T>(List<T> items) where T : BaseEntity 
        {
            if (items.Count == 0) 
            {
                return 1;
            }
            else 
            {
                int maxId = int.MinValue;
                foreach (var item in items)
                {
                    if (item.Id > maxId)
                    {
                        maxId = item.Id;
                    }
                }
                return maxId + 1;
            }
        }
    }
}
