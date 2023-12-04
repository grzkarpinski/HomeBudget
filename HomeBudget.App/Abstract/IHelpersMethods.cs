using HomeBudget.Domain.Common;

namespace HomeBudget.App.Abstract
{
    public interface IHelpersMethods
    {
        DateTime GetDate();
        decimal GetCost();
        int GenerateNextId<T>(List<T> items) where T : BaseEntity;
        string GetExpenseName();
        int GetIdToRemove();
    }
}
