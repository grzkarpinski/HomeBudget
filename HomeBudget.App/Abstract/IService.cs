using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Abstract
{
    public interface IService<T>
    {
        public List<T> Items { get; set; }
        public List<T> GetAllItems();
        public void AddItem();
        public void RemoveItem();
    }
}
