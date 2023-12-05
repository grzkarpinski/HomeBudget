using HomeBudget.Domain.Common;

namespace HomeBudget.App.Abstract
{
    public interface IHelpersMethods
    {
        DateTime GetDate();
        decimal GetCost();
        string GetExpenseName();
        int GetIdToRemove();
    }
}
