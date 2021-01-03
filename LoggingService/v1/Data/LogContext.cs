using LoggingService.v1.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.v1.Data
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options) { }

        public DbSet<LogEntity> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<LogEntity>(b => b.HasKey(e => e.Identifier));
        }
    }
}
