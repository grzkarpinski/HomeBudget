using FluentAssertions;
using HomeBudget.Menu;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Tests
{
    public class MenuMenagerTests
    {
        [Fact]
        public void AddItemTest()
        {
            //Arrange
            MenuItem menuItem = new MenuItem("test text", () => Console.WriteLine("test action"));
            MenuManager testMenuManager = new MenuManager();
            string text = "test text";
            Action action = () => Console.WriteLine("test action");

            //Act
            testMenuManager.AddItem(text,action);

            //Assert
            Assert.Single(testMenuManager.Items);
            Assert.Equal(text, testMenuManager.Items[0].Text);
            Assert.Equal(action, testMenuManager.Items[0].Action);
        }

        [Fact]
        public void DrawTest() 
        {
            //Arrange
            var expectedOutput = "MENU:\r\n1. test text\r\n\r\nChoose option number: ";
            var testMenuManager = new MenuManager();
            testMenuManager.AddItem("test text", () => Console.WriteLine("test action"));
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            testMenuManager.Draw();
            var actualOutput = consoleOutput.ToString();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
