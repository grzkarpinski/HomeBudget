using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.helpers
{
    public class DateTimeService
    {
        public static (int Year, int Month) GetPreviousMonth(int year, int month)
        {
            if (month == 1)
            {
                return (year - 1, 12);
            }
            return (year, month - 1);
        }
    }
}
