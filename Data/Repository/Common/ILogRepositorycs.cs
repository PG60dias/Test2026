using Data.Models;

public interface ILogRepository
{
	Task<IEnumerable<Log>> GetLogsAsync();
	Task AddLogAsync(Log log);
}