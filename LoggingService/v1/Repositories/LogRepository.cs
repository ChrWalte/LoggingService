using LoggingService.v1.Data;
using LoggingService.v1.Entities;
using LoggingService.v1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingService.v1.Repositories
{
    public class LogRepository : ILogRepository
    {
        protected readonly LogContext Context;

        public LogRepository(LogContext context)
            => Context = context;

        public async Task<IEnumerable<LogEntity>> GetLogs()
            => await Context.Logs.ToListAsync();

        public async Task<LogEntity> GetLogByIdentifier(Guid identifier)
            => await Context.Logs.Where(log => log.Identifier.Equals(identifier)).FirstOrDefaultAsync();

        public async Task<IEnumerable<LogEntity>> GetLogsByTimeStamp(DateTime timeStamp)
            => await Context.Logs.Where(log => log.TimeStamp <= timeStamp).ToListAsync();

        public async Task<IEnumerable<LogEntity>> GetLogsByType(string type)
            => await Context.Logs.Where(log => log.Type.Equals(type)).ToListAsync();

        public async Task<IEnumerable<LogEntity>> GetLogsByLocation(string location)
            => await Context.Logs.Where(log => log.Location.Equals(location)).ToListAsync();

        public async Task<IEnumerable<LogEntity>> GetLogsByLocation(object location)
            => await Context.Logs.Where(log => log.Location.Equals(location.GetType().ToString())).ToListAsync();

        public async Task<bool> CreateLog(LogEntity log)
        {
            await Context.Logs.AddAsync(log);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges()
            => await Context.SaveChangesAsync() > 0;
    }
}