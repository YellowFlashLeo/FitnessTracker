using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;

namespace FitnessTracker.Server.Persistence.Services.MonthlyStatistics
{
    public class MonthlyStatistics : IMonthlyStatistics
    {
        private readonly FitnessStoreContext _dbContext;

        public MonthlyStatistics(FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
