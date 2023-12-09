using HomeBudget.App.Abstract;
using HomeBudget.App.Common;
using HomeBudget.App.Concrete;
using HomeBudget.App.helpers;
using HomeBudget.Domain.Entity;
using HomeBudget.Domain.Enums;
using HomeBudget.Domain.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HomeBudget.Tests
{
    public class ExpenseServiceTests
    {
        [Fact]
        public void AddExpenseTest()
        {
            // Arrange
            var expense = new Expense();
            expense.Id = 1;
            expense.Name = "Lidl";
            expense.Category = PurchaseCategory.Grocery;
            expense.WhoPaid = "Grzegorz";
            expense.Price = 100;
            expense.PurchaseDate = new DateTime(2021, 1, 1);

            var expenseService = new ExpenseService("");

            // Act
            expenseService.AddItem(expense);

            // Assert
            Assert.Equal(1, expenseService.GetAllItems().Count);
            Assert.Equal(expense, expenseService.GetAllItems().First());


        }

        [Fact]
        public void RemoveExpenseTest()
        {
            // Arrange
            var expense = new Expense();
            expense.Id = 1;
            expense.Name = "Lidl";
            expense.Category = PurchaseCategory.Grocery;
            expense.WhoPaid = "Grzegorz";
            expense.Price = 100;
            expense.PurchaseDate = new DateTime(2021, 1, 1);

            var expenseService = new ExpenseService("");

            // Act
            expenseService.AddItem(expense);
            expenseService.RemoveItem(1);

            // Assert
            Assert.Equal(0, expenseService.GetAllItems().Count);
        }

        [Fact]
        public void PrintAllExpensesTest()
        {
            // Arrange
            var expenseService = new ExpenseService("");
            var expenses = expenseService.GetAllItems();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            expenseService.PrintAllExpenses(expenses);

            // Assert
            Assert.Equal("Thera are no shopping added.", stringWriter.ToString().Trim());

        }

        [Fact]
        public void PrintAllExpensesTest2()
        {
            // Arrange
            var expense = new Expense();
            expense.Id = 1;
            expense.Name = "Lidl";
            expense.Category = PurchaseCategory.Grocery;
            expense.WhoPaid = "Grzegorz";
            expense.Price = 100;
            expense.PurchaseDate = new DateTime(2021, 1, 1);

            var expenseService = new ExpenseService("");
            var expenses = expenseService.GetAllItems();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            expenseService.AddItem(expense);
            expenseService.PrintAllExpenses(expenses);

            // Assert
            Assert.Equal("Requested shoppings:\r\nId: 1; Name: Lidl; Category: Grocery; WhoPaid: Grzegorz; Price: 100 PLN; Purchase date: 01-01-2021", stringWriter.ToString().Trim());

        }

        [Fact]

        public void WhoPaysTest() 
        { 
            // Arrange
            var buyerService = new BuyerService("");
            var buyers = buyerService.getBuyersList();
            buyerService.AddItem("Ewelina", buyers);
            buyerService.AddItem("Grzegorz", buyers);
            List <Buyer> allBuyers = buyerService.getBuyersList();

            var expenseService = new ExpenseService("");
            var expenses = expenseService.GetAllItems();

            expenseService.AddItem(new Expense() { Id = 1,
                                                      Name = "Lidl",
                                                      Category = PurchaseCategory.Grocery,
                                                      WhoPaid = "Grzegorz",
                                                      Price = 100,
                                                      PurchaseDate = DateTime.Now });
            // Act
            var result = expenseService.WhoPays(allBuyers, expenses);

            // Assert
            Assert.Equal("Ewelina", result);
        }
    }
}
