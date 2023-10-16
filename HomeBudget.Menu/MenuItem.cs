using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Menu
{
    public class MenuItem
    {
        public string Text { get; }
        public Action Action { get; }

        public MenuItem(string text, Action action)
        {
            Text = text;
            Action = action;
        }
    }
}
