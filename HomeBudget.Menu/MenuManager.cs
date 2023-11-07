using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Menu
{
    public class MenuManager
    {
        public List<MenuItem> Items { get; } = new List<MenuItem>();

        public void AddItem(string text, Action action)
        {
            Items.Add(new MenuItem(text, action));
        }

        public void Draw()
        {
            Console.WriteLine("MENU:");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].Text}");
            }
            Console.WriteLine();
            Console.Write("Choose option number: ");
        }

        public void RunMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Draw();

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= Items.Count)
                {
                    var selectedMenu = Items[choice - 1];
                    selectedMenu.Action.Invoke();

                    if (selectedMenu.Text == "Exit")
                    {
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice. Enter valid number.");
                }
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadKey();
            }
        }
    }
}
