using System;

namespace LoggingService.v1.Entities
{
    public class LogEntity
    {
        public Guid Identifier { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Information { get; set; }

        public static LogEntity LogDebug(object location, string information)
            => Log("Debug", GetTypeAsString(location), information);

        public static LogEntity LogInformation(object location, string information)
            => Log("Information", GetTypeAsString(location), information);

        public static LogEntity LogWarning(object location, string information)
            => Log("Information", GetTypeAsString(location), information);

        public static LogEntity LogError(object location, Exception exception, string information)
            => Log("Information", GetTypeAsString(location), $"Exception: {exception}. Information: {information}.");

        private static LogEntity Log(string type, string location, string information)
        {
            return new LogEntity
            {
                Identifier = Guid.NewGuid(),
                TimeStamp = DateTime.UtcNow,
                Type = type,
                Location = location,
                Information = information
            };
        }

        private static string GetTypeAsString(object type)
            => type.GetType().ToString();
    }
}