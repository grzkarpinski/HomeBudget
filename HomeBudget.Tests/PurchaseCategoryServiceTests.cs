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
    public class PurchaseCategoryServiceTests
    {
        [Fact]
        public void PrintAvalibleCategoriesTest() 
        {
            // Arrange
            var expected = "id: 1 Category: Grocery\r\nid: 2 Category: Cosmetics\r\nid: 3 Category: Household\r\nid: 4 Category: Other\r\n";
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            PurchaseCategoryService.PrintAvalibleCategories();
            var actual = output.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCategoryTest()
        {
            // Arrange
            var expected = PurchaseCategory.Grocery;
            var input = new StringReader("1");
            Console.SetIn(input);

            // Act
            var actual = PurchaseCategoryService.GetCategory();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
