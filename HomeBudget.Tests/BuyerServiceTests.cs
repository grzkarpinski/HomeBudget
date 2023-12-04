using HomeBudget.App.Concrete;
using HomeBudget.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HomeBudget.Tests
{
    public class BuyerServiceTests
    {
        [Fact]
        public void getBuyersListTest()
        {
            // Arrange
            var buyer = new Buyer();
            buyer.Id = 1;
            buyer.Name = "GRZEGORZ";

            var buyerService = new BuyerService("");

            // Act
            buyerService.AddBuyer("Grzegorz");

            // Assert
            Assert.Equal("GRZEGORZ", buyerService.getBuyersList()[0].Name);
            Assert.Equal(1, buyerService.getBuyersList()[0].Id);
        }

        [Fact]
        public void AddBuyerTest()
        {
            // Arrange
            var buyer = new Buyer();
            buyer.Id = 1;
            buyer.Name = "GRZEGORZ";

            var buyerService = new BuyerService("");

            // Act
            buyerService.AddBuyer("Grzegorz");

            // Assert
            Assert.Equal(1, buyerService.getBuyersList().Count);
        }

        [Fact]
        public void RemoveBuyerTest()
        {
            // Arrange
            var buyer = new Buyer();
            buyer.Id = 1;
            buyer.Name = "GRZEGORZ";

            var buyerService = new BuyerService("");

            // Act
            buyerService.AddBuyer("Grzegorz");
            buyerService.RemoveBuyer(1);

            // Assert
            Assert.Equal(0, buyerService.getBuyersList().Count);
        }
    }
}
