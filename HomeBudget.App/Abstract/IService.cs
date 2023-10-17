using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAllItems();
        public void AddItem();
        public void RemoveItem();
    }
}
