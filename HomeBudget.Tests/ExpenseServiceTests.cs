using HomeBudget.App.Abstract;
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

            var expenseService = new ExpenseService();

            // Act
            expenseService.AddExpense(expense);

            // Assert
            Assert.Equal(1, expenseService.GetAllExpenses().Count);
            Assert.Equal(expense, expenseService.GetAllExpenses().First());


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

            var expenseService = new ExpenseService();

            // Act
            expenseService.AddExpense(expense);
            expenseService.RemoveExpense(1);

            // Assert
            Assert.Equal(0, expenseService.GetAllExpenses().Count);
        }

        [Fact]
        public void PrintAllExpensesTest()
        {
            // Arrange
            var expenseService = new ExpenseService();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            expenseService.PrintAllExpenses();

            // Assert
            Assert.Equal("Thera are no shopping added this month.", stringWriter.ToString().Trim());

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

            var expenseService = new ExpenseService();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            expenseService.AddExpense(expense);
            expenseService.PrintAllExpenses();

            // Assert
            Assert.Equal("Monthly shopping:\r\nId: 1; Name: Lidl; Category: Grocery; WhoPaid: Grzegorz; Price: 100; Purchase date: 01-01-2021", stringWriter.ToString().Trim());

        }
    }
}
