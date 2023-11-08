using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
