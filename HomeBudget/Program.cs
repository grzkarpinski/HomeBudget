using HomeBudget.App.Concrete;
using HomeBudget.App.managers;
using HomeBudget.Domain.Entity;
using HomeBudget.Menu;
using System;
//TODO:
// add buyers menager
// add report for given month

BuyerService buyers = new BuyerService();
//buyers.AddBuyer("Ewelina");
//buyers.AddBuyer("Grzegorz");

// file manager
//string path = "buyers.json";
List<Buyer> allBuyers = buyers.getBuyersList();
//FileManager<Buyer>.SaveListToFile(allBuyers, path);

ExpenseService itemService = new ExpenseService();

MenuManager mainMenu = new MenuManager();
mainMenu.AddItem("Add Expense", () => itemService.AddExpense(allBuyers));
mainMenu.AddItem("Remove Expense", () => itemService.RemoveExpense());
mainMenu.AddItem("Who Pays for Next Shopping?", () => itemService.WhoPays(allBuyers));
mainMenu.AddItem("List of Expenses", () => itemService.PrintAllExpenses());
mainMenu.AddItem("Exit", () => Console.WriteLine("Exit"));
mainMenu.RunMenu();
