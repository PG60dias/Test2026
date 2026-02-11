using Data.Models;
using Data.Repository.Common;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace Data.Repository.API
{
	public class LogRepository(HttpClient http) : ILogRepository
	{
		private readonly HttpClient _http = http;

		public async Task<IEnumerable<Log>> GetLogsAsync()
		{
			return await _http.GetFromJsonAsync<IEnumerable<Log>>("api/Logs") ?? new List<Log>();
		}

		public async Task AddLogAsync(Log log)
		{
			await _http.PostAsJsonAsync("api/Logs", log);
		}
	}
}