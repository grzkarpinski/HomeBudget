using HomeBudget.App.Common;
using HomeBudget.App.helpers;
using HomeBudget.App.managers;
using HomeBudget.Domain.Entity;
using HomeBudget.Domain.Enums;
using HomeBudget.Domain.Helpers;
using HomeBudget.App.helpers;

namespace HomeBudget.App.Concrete
{
    public class ExpenseService : BaseService<Expense>
    {
        private List<Expense> _allExpenses;

        public ExpenseService(string expensesFilePath)
        {
            _allExpenses = new List<Expense>();
            string path = expensesFilePath;
            _allExpenses = FileManager<Expense>.LoadListFronFile(path);
        }

        public List<Expense> GetAllExpenses()
        {
            return _allExpenses;
        }

        public void AddExpense(List<Buyer> buyersList)
        {
            int nextId = IdService.GenerateNextId(_allExpenses);

            string name = UserInputMethods.GetExpenseName();

            PurchaseCategory category = PurchaseCategoryService.GetCategory();

            string whoPaid = UserInputMethods.GetBuyer(buyersList);

            decimal price = UserInputMethods.GetCost();

            DateTime purchaseDate = UserInputMethods.GetInputDate();

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
            _allExpenses.Add(expense);
            FileManager<Expense>.SaveListToFile(_allExpenses, "expenses.json");
        }

        public void RemoveExpense()
        {
            if (_allExpenses.Count == 0)
            {
                Console.WriteLine("List is already empty.");
                return;
            }

            Console.WriteLine("Enter Id of shopping you want to remove:");
            int idToRemove = UserInputMethods.GetIdToRemove();

            RemoveExpense(idToRemove);
        }

        public void RemoveExpense(int idToRemove)
        {

            if (idToRemove != 0)
            {
                Expense itemToRemove = _allExpenses.FirstOrDefault(item => item.Id == idToRemove);

                if (itemToRemove != null)
                {
                    _allExpenses.Remove(itemToRemove);
                    Console.WriteLine($"Shopping Id {idToRemove} was removed.");
                    FileManager<Expense>.SaveListToFile(_allExpenses, "expenses.json");
                }
                else
                {
                    Console.WriteLine($"Cannot find Id {idToRemove} on list.");
                }
            }
        }

        public void PrintAllExpenses(List<Expense> expenses)
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("Thera are no shopping added.");
                return;
            }

            Console.WriteLine("Requested shoppings:");
            expenses.ForEach(PrintExpenseDetails);
        }

        public static void PrintExpenseDetails(Expense item) 
        {
            Console.WriteLine($"Id: {item.Id}; " +
            $"Name: {item.Name}; " +
            $"Category: {item.Category}; " +
            $"WhoPaid: {item.WhoPaid}; " +
            $"Price: {item.Price} PLN; " +
            $"Purchase date: {item.PurchaseDate.ToString("dd-MM-yyyy")}");
        }

        public string WhoPays(List<Buyer> buyersList, List<Expense> expenses)
        {
            decimal lowest = decimal.MaxValue;
            string personWhoPays = "---";

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            List<Expense> currentMonthItems = GetMonthyExpenses(expenses, currentYear, currentMonth);
            decimal total = SumExpenses(currentMonthItems);

            Console.WriteLine($"Total sum of expenses this month ({DateTime.Now.ToString("MM-yyyy")}): {total} PLN");
            if (total == 0)
            {
                Console.WriteLine("There is no shoping this month. Looking in last month...");
                (currentYear, currentMonth) = DateTimeService.GetPreviousMonth(currentYear, currentMonth);
                currentMonthItems = GetMonthyExpenses(expenses, currentYear, currentMonth);
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

            return personWhoPays;
        }

        public void generateMonthlyReport(List <Expense> expenses) 
        {
            Console.WriteLine("Enter month for report (MM-yyyy):");
            string inputMonth = Console.ReadLine();
            if (DateTime.TryParse(inputMonth, out DateTime month)) 
            {
                List <Expense> monthExpenses = GetMonthyExpenses(expenses, month.Year, month.Month);

                if (monthExpenses.Count == 0)
                {
                    Console.WriteLine("Thera are no shopping added in month you requested.");
                    return;
                }

                Console.WriteLine("Requested shoppings:");
                monthExpenses.ForEach(PrintExpenseDetails);

            }
        }

        public List<Expense> GetMonthyExpenses(List<Expense> expenses, int year, int month)
        {
            List<Expense> monthlyExpenses = expenses.Where(item => item.PurchaseDate.Year == year && item.PurchaseDate.Month == month).ToList();

            return monthlyExpenses;

        }

        public decimal SumExpenses(List<Expense> expenses)
        {
            decimal total = expenses.Sum(item => item.Price);
            return total;
        }
    }
}
