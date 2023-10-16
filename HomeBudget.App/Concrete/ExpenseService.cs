using HomeBudget.App.Common;
using HomeBudget.Domain.Entity;
using HomeBudget.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Concrete
{
    public class ExpenseService : BaseService<Expense>
    {
        private List<Expense> _items;
        private int nextId;

        public ExpenseService()
        {
            _items = new List<Expense>();
            nextId = 1;
        }

        public List<Expense> GetAllExpenses()
        {
            return _items;
        }

        public void AddExpense(List<Buyer> buyersList)
        {
            Console.WriteLine("Enter short description:");
            string name = Console.ReadLine();

            PurchaseCategory category = PurchaseCategoryService.GetCategory();

            string whoPaid = GetBuyer(buyersList);

            decimal price = GetCost();

            DateTime purchaseDate = GetDate();

            Expense newItem = new Expense
            {
                Id = nextId,
                Name = name,
                Category = category,
                WhoPaid = whoPaid,
                Price = price,
                PurchaseDate = purchaseDate
            };

            _items.Add(newItem);

            nextId++;
        }
        public void RemoveExpense()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("List is already empty.");
                return;
            }

            Console.WriteLine("Enter Id of shopping you want to remove:");
            if (int.TryParse(Console.ReadLine(), out int idToRemove))
            {
                Expense itemToRemove = null;
                foreach (Expense item in _items)
                {
                    if (item.Id == idToRemove)
                    {
                        itemToRemove = item;
                        break;
                    }
                }

                if (itemToRemove != null)
                {
                    _items.Remove(itemToRemove);
                    Console.WriteLine($"Shopping Id {idToRemove} was removed.");
                }
                else
                {
                    Console.WriteLine($"Cannot find Id {idToRemove} on list.");
                }
            }
        }

        public void PrintAllExpenses()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Thera are no shopping added this month.");
                return;
            }

            Console.WriteLine("Monthly shopping:");
            foreach (var item in _items)
            {
                Console.WriteLine($"Id: {item.Id}; " +
                    $"Name: {item.Name}; " +
                    $"Category: {item.Category}; " +
                    $"WhoPaid: {item.WhoPaid}; " +
                    $"Price: {item.Price}; " +
                    $"Purchase date: {item.PurchaseDate.ToString("dd-MM-yyyy")}");
            }
        }

        public void WhoPays(List<Buyer> buyersList)
        {
            decimal lowest = decimal.MaxValue;
            string personWhoPays = "---";

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            List<Expense> currentMonthItems = GetCurrentMonthExpenses(_items, currentYear, currentMonth);
            decimal total = GetTotalExpenses(currentMonthItems);

            Console.WriteLine($"Total sum of expenses this month ({DateTime.Now.ToString("MM-yyyy")}): {total} PLN");
            if (total == 0)
            {
                Console.WriteLine("There is no shoping this month. Looking in last month...");
                personWhoPays = "---";
                currentMonth = currentMonth - 1;

                if (currentMonth == 0)
                {
                    currentMonth = 12;
                    currentYear = currentYear - 1;
                }
                currentMonthItems = GetCurrentMonthExpenses(_items, currentYear, currentMonth);
                total = GetTotalExpenses(currentMonthItems);
                Console.WriteLine($"Total sum of expenses last month ({DateTime.Now.ToString("MM-yyyy")}): {total} PLN");

            }

            foreach (Buyer whoPaid in buyersList)
            {
                decimal sumForWhoPaid = 0;
                foreach (Expense item in currentMonthItems)
                {
                    if (item.WhoPaid == whoPaid.Name)
                    {
                        sumForWhoPaid += item.Price;
                    }
                }

                Console.WriteLine($"{whoPaid.Name} - paid for: {sumForWhoPaid} PLN");

                if (sumForWhoPaid <= lowest)
                {
                    lowest = sumForWhoPaid;
                    personWhoPays = whoPaid.Name;
                }
            }
            Console.WriteLine($"{personWhoPays} pays for next shopping.");
        }

        private string GetBuyer(List<Buyer> buyersList)
        {
            Console.WriteLine("Who paid for this shopping (choose number):");
            foreach (var item in buyersList)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }

            bool buyerFound = false;
            string whoPaid = "";

            while (!buyerFound)
            {
                whoPaid = Console.ReadLine();
                int whoPaidInt;
                if (int.TryParse(whoPaid, out whoPaidInt))
                {
                    var selectedBuyer = buyersList.FirstOrDefault(buyer => buyer.Id == whoPaidInt);
                    if (selectedBuyer != null)
                    {
                        whoPaid = selectedBuyer.Name;
                        buyerFound = true;
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

            return whoPaid;
        }

        private decimal GetCost()
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

        private DateTime GetDate()
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

        private List<Expense> GetCurrentMonthExpenses(List<Expense> items, int currentYear, int currentMonth)
        {
            List<Expense> currentMonthItems = new List<Expense>();

            foreach (Expense item in items)
            {
                if (item.PurchaseDate.Year == currentYear && item.PurchaseDate.Month == currentMonth)
                {
                    currentMonthItems.Add(item);
                }
            }
            return currentMonthItems;

        }

        private decimal GetTotalExpenses(List<Expense> currentMonthItems)
        {
            decimal total = 0;
            foreach (Expense item in currentMonthItems)
            {
                total += item.Price;
            }
            return total;
        }
    }
}
