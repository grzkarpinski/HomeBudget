using HomeBudget.App.Abstract;
using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseService()
        {
            Items = new List<T>();
        }
        public void AddItem()
        {
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem()
        {
        }
    }
}
