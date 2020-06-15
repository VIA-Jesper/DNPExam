using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasPump;
using Microsoft.EntityFrameworkCore;

namespace GasPumpWebService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<PumpFillHistory> FillHistories { get; set; }
        public DbSet<PumpUsageHistory> UsageHistories { get; set; }
    }
}
