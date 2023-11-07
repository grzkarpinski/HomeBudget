using FluentAssertions;
using HomeBudget.Menu;
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
            MenuItem menuItem = new MenuItem("test text", () => Console.WriteLine("test action"));
            MenuManager testMenuManager = new MenuManager();
            string text = "test text";
            Action action = () => Console.WriteLine("test action");

            testMenuManager.AddItem(text,action);

            Assert.Single(testMenuManager.Items);
            Assert.Equal(text, testMenuManager.Items[0].Text);
            Assert.Equal(action, testMenuManager.Items[0].Action);
        }
    }
}
