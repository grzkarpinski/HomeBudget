using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.helpers
{
    public class IdService
    {
        public static int GenerateNextId<T>(List<T> items) where T : BaseEntity
        {
            if (items.Count == 0)
            {
                return 1;
            }
            else
            {
                return items.Max(items => items.Id) + 1;
            }
        }
    }
}
