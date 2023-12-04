using HomeBudget.App.Concrete;
using HomeBudget.App.helpers;
using HomeBudget.Domain.Common;
using HomeBudget.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HomeBudget.Tests
{
    public class HelpersMethodsTests
    {
        [Fact]
        public void GetDateTest() 
        {
            // Arrange
            var input = new StringReader("2020-01-01");
            Console.SetIn(input);

            // Act
            var result = HelpersMethods.GetDate();

            // Assert
            Assert.Equal(new DateTime(2020, 01, 01), result);
        }

        [Fact]
        public void GetCostTest()
        {
            // Arrange
            var input = new StringReader("10,00");
            Console.SetIn(input);

            // Act
            var result = HelpersMethods.GetCost();

            // Assert
            Assert.Equal(10.00m, result);
        }

        [Fact]
        public void GenerateNextIdTest()
        {
            // Arrange
            var items = new List<BaseEntity>();
            items.Add(new BaseEntity() { Id = 1 });
            items.Add(new BaseEntity() { Id = 2 });
            items.Add(new BaseEntity() { Id = 3 });

            // Act
            var result = HelpersMethods.GenerateNextId(items);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void GetExpenseNameTest() 
        {
            // Arrange
            var input = new StringReader("test");
            Console.SetIn(input);

            // Act
            var result = HelpersMethods.GetExpenseName();

            // Assert
            Assert.Equal("test", result);
        }

        [Fact]
        public void GetIdToRemoveTest()
        {
            // Arrange
            var input = new StringReader("1");
            Console.SetIn(input);

            // Act
            var result = HelpersMethods.GetIdToRemove();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetBuyerTest()
        {
            // Arrange
            var buyerService = new BuyerService("");
            buyerService.AddBuyer("Ewelina");
            buyerService.AddBuyer("Grzegorz");
            List<Buyer> allBuyers = buyerService.getBuyersList();

            var expenseService = new ExpenseService("");

            var input = new StringReader("2");
            Console.SetIn(input);

            // Act
            var result = HelpersMethods.GetBuyer(allBuyers);

            // Assert
            Assert.Equal("GRZEGORZ", result);
        }
    }
}
