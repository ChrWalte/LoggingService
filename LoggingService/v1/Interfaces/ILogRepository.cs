using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingService.v1.Entities;

namespace LoggingService.v1.Interfaces
{
    public interface ILogRepository
    {
        Task<IEnumerable<LogEntity>> GetLogs();
        Task<LogEntity> GetLogByIdentifier(Guid identifier);
        Task<IEnumerable<LogEntity>> GetLogsByTimeStamp(DateTime timeStamp);
        Task<IEnumerable<LogEntity>> GetLogsByType(string type);
        Task<IEnumerable<LogEntity>> GetLogsByLocation(string location);
        Task<IEnumerable<LogEntity>> GetLogsByLocation(object location);
        Task<bool> CreateLog(LogEntity log);
    }
}
