using HomeBudget.App.Abstract;
using HomeBudget.Domain.Common;

namespace HomeBudget.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseService()
        {
            Items = new List<T>();
        }
        public virtual void AddItem()
        {
        }

        public virtual List<T> GetAllItems()
        {
            return Items;
        }

        public virtual void RemoveItem()
        {
        }
    }
}
