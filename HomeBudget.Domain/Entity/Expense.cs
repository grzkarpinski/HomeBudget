using HomeBudget.Domain.Common;
using HomeBudget.Domain.Enums;

namespace HomeBudget.Domain.Entity
{
    public class Expense : BaseEntity
    {
        public PurchaseCategory Category { get; set; }
        public string WhoPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
