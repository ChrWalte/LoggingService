using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingService.v1.Entities;
using LoggingService.v1.Interfaces;

namespace LoggingService.v1.Services
{
    public class LogService<T> : ILogService<T>
    {
        private readonly T _location;
        private readonly ILogRepository _repository;

        public LogService(T location, ILogRepository repository)
        {
            _location = location;
            _repository = repository; 
        }

        public async Task<IEnumerable<LogEntity>> GetLogs()
            => await _repository.GetLogs();

        public async Task<LogEntity> GetLogByIdentifier(Guid identifier)
            => await _repository.GetLogByIdentifier(identifier);

        public async Task<IEnumerable<LogEntity>> GetLogsByTimeStamp(DateTime timeStamp)
            => await _repository.GetLogsByTimeStamp(timeStamp);

        public async Task<IEnumerable<LogEntity>> GetLogsByType(string type)
            => await _repository.GetLogsByType(type);

        public async Task<IEnumerable<LogEntity>> GetLogsByLocation(string location)
            => await _repository.GetLogsByLocation(location);

        public async Task<IEnumerable<LogEntity>> GetLogsByLocation(object location)
            => await _repository.GetLogsByLocation(location);

        public async Task<LogEntity> LogDebug(string information)
        {
            var log = LogEntity.LogDebug(_location, information);
            return await _repository.CreateLog(log)
                ? log
                : null;
        }

        public async Task<LogEntity> LogInformation(string information)
        {
            var log = LogEntity.LogInformation(_location, information);
            return await _repository.CreateLog(log)
                ? log
                : null;
        }

        public async Task<LogEntity> LogWarning(string information)
        {
            var log = LogEntity.LogWarning(_location, information);
            return await _repository.CreateLog(log)
                ? log
                : null;
        }

        public async Task<LogEntity> LogError(Exception exception, string information)
        {
            var log = LogEntity.LogError(_location, exception, information);
            return await _repository.CreateLog(log)
                ? log
                : null;
        }
    }
}
