﻿using HomeBudget.App.Abstract;
using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Common
{
    public class HelpersMethodsBase : IHelpersMethods
    {
        public virtual int GenerateNextId<T>(List<T> items) where T : BaseEntity
        {
            return 0;
        }

        public virtual decimal GetCost()
        {
            return 0;
        }

        public virtual DateTime GetDate()
        {
            return DateTime.Now;
        }

        public virtual string GetExpenseName()
        {
            return string.Empty;
        }

        public virtual int GetIdToRemove()
        {
            return 0;
        }
    }
}
