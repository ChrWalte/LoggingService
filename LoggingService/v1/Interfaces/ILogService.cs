using LoggingService.v1.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingService.v1.Interfaces
{
    public interface ILogService<T>
    {
        Task<IEnumerable<LogEntity>> GetLogs();

        Task<LogEntity> GetLogByIdentifier(Guid identifier);

        Task<IEnumerable<LogEntity>> GetLogsByTimeStamp(DateTime timeStamp);

        Task<IEnumerable<LogEntity>> GetLogsByType(string type);

        Task<IEnumerable<LogEntity>> GetLogsByLocation(string location);

        Task<IEnumerable<LogEntity>> GetLogsByLocation(object location);

        Task<LogEntity> LogDebug(string information);

        Task<LogEntity> LogInformation(string information);

        Task<LogEntity> LogWarning(string information);

        Task<LogEntity> LogError(Exception exception, string information);
    }
}