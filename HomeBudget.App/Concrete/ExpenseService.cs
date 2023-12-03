using HomeBudget.App.Common;
using HomeBudget.App.helpers;
using HomeBudget.Domain.Entity;
using HomeBudget.Domain.Enums;
using HomeBudget.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HomeBudget.App.Concrete
{
    public class ExpenseService : BaseService<Expense>
    {
        private List<Expense> _items;

        public ExpenseService()
        {
            _items = new List<Expense>();
        }

        public List<Expense> GetAllExpenses()
        {
            return _items;
        }

        public void AddExpense(List<Buyer> buyersList)
        {
            int nextId = HelpersMethods.GenerateNextId(_items);

            string name = HelpersMethods.GetExpenseName();

            PurchaseCategory category = PurchaseCategoryService.GetCategory();

            string whoPaid = HelpersMethods.GetBuyer(buyersList);

            decimal price = HelpersMethods.GetCost();

            DateTime purchaseDate = HelpersMethods.GetDate();

            Expense newItem = new Expense
            {
                Id = nextId,
                Name = name,
                Category = category,
                WhoPaid = whoPaid,
                Price = price,
                PurchaseDate = purchaseDate
            };

            AddExpense(newItem);

        }

        public void AddExpense(Expense expense)
        {
            _items.Add(expense);
        }

        public void RemoveExpense()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("List is already   empty.");
                return;
            }

            Console.WriteLine("Enter Id of shopping you want to remove:");
            int idToRemove = HelpersMethods.GetIdToRemove();

            RemoveExpense(idToRemove);
        }

        public void RemoveExpense(int idToRemove)
        {

            if (idToRemove != 0)
            {
                Expense itemToRemove = _items.FirstOrDefault(item => item.Id == idToRemove);

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
                Console.WriteLine("Thera are no shopping added.");
                return;
            }

            Console.WriteLine("Requested shoppings:");
            _items.ForEach(PrintExpenseDetails);
        }

        private static void PrintExpenseDetails(Expense item) 
        {
            Console.WriteLine($"Id: {item.Id}; " +
            $"Name: {item.Name}; " +
            $"Category: {item.Category}; " +
            $"WhoPaid: {item.WhoPaid}; " +
            $"Price: {item.Price}; " +
            $"Purchase date: {item.PurchaseDate.ToString("dd-MM-yyyy")}");
        }

        public string WhoPays(List<Buyer> buyersList)
        {
            decimal lowest = decimal.MaxValue;
            string personWhoPays = "---";

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            List<Expense> currentMonthItems = GetCurrentMonthExpenses(_items, currentYear, currentMonth);
            decimal total = SumExpenses(currentMonthItems);

            Console.WriteLine($"Total sum of expenses this month ({DateTime.Now.ToString("MM-yyyy")}): {total} PLN");
            if (total == 0)
            {
                Console.WriteLine("There is no shoping this month. Looking in last month...");

                currentMonth = currentMonth - 1;

                if (currentMonth == 0)
                {
                    currentMonth = 12;
                    currentYear = currentYear - 1;
                }
                currentMonthItems = GetCurrentMonthExpenses(_items, currentYear, currentMonth);
                total = SumExpenses(currentMonthItems);
                Console.WriteLine($"Total sum of expenses last month ({DateTime.Now.ToString("MM-yyyy")}): {total} PLN");
            }
            if (total == 0)
            {
                Console.WriteLine("Where was also no shopping last month. Pick someone random :)");
            }
            else
            {
                foreach (Buyer whoPaid in buyersList)
                {
                    decimal sumForWhoPaid = currentMonthItems.Where(item => item.WhoPaid == whoPaid.Name).Sum(item => item.Price);

                    Console.WriteLine($"{whoPaid.Name} - paid for: {sumForWhoPaid} PLN");

                    if (sumForWhoPaid < lowest)
                    {
                        lowest = sumForWhoPaid;
                        personWhoPays = whoPaid.Name;
                    }
                }
                Console.WriteLine($"{personWhoPays} pays for next shopping.");
            }

            return "---";
        }

        private List<Expense> GetCurrentMonthExpenses(List<Expense> items, int currentYear, int currentMonth)
        {
            List<Expense> currentMonthItems = items.Where(item => item.PurchaseDate.Year == currentYear && item.PurchaseDate.Month == currentMonth).ToList();

            return currentMonthItems;

        }

        private decimal SumExpenses(List<Expense> currentMonthItems)
        {
            decimal total = currentMonthItems.Sum(item => item.Price);
            return total;
        }
    }
}
