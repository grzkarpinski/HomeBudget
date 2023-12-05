using HomeBudget.App.Concrete;
using HomeBudget.Domain.Entity;
using HomeBudget.Menu;

string buyersPath = "buyers.json";
BuyerService buyers = new BuyerService(buyersPath);
List<Buyer> allBuyers = buyers.getBuyersList();

string expensesPath = "expenses.json";
ExpenseService itemService = new ExpenseService(expensesPath);
List<Expense> allExpenses = itemService.GetAllExpenses();

MenuManager mainMenu = new MenuManager();
mainMenu.AddItem("Add Expense", () => itemService.AddExpense(allBuyers));
mainMenu.AddItem("Remove Expense", () => itemService.RemoveExpense());
mainMenu.AddItem("Who Pays for Next Shopping?", () => itemService.WhoPays(allBuyers, allExpenses));
mainMenu.AddItem("List of Expenses", () => itemService.PrintAllExpenses(allExpenses));
mainMenu.AddItem("Monthly Report", () => itemService.generateMonthlyReport(allExpenses));
mainMenu.AddItem("Buyers List", () => buyers.PrintAllBuyers());
mainMenu.AddItem("Add Buyer", () => buyers.AddBuyer());
mainMenu.AddItem("Remove Buyer", () => buyers.RemoveBuyer());
mainMenu.AddItem("Exit", () => Console.WriteLine("Exit"));
mainMenu.RunMenu();
