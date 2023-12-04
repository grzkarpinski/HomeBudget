using HomeBudget.App.Concrete;
using HomeBudget.Domain.Entity;
using HomeBudget.Menu;
//TODO:
// add report for given month

string buyersPath = "buyers.json";
BuyerService buyers = new BuyerService(buyersPath);
List<Buyer> allBuyers = buyers.getBuyersList();

string expensesPath = "expenses.json";
ExpenseService itemService = new ExpenseService(expensesPath);

MenuManager mainMenu = new MenuManager();
mainMenu.AddItem("Add Expense", () => itemService.AddExpense(allBuyers));
mainMenu.AddItem("Remove Expense", () => itemService.RemoveExpense());
mainMenu.AddItem("Who Pays for Next Shopping?", () => itemService.WhoPays(allBuyers));
mainMenu.AddItem("List of Expenses", () => itemService.PrintAllExpenses());
mainMenu.AddItem("Buyers List", () => buyers.PrintAllBuyers());
mainMenu.AddItem("Add Buyer", () => buyers.AddBuyer());
mainMenu.AddItem("Remove Buyer", () => buyers.RemoveBuyer());
mainMenu.AddItem("Exit", () => Console.WriteLine("Exit"));
mainMenu.RunMenu();
