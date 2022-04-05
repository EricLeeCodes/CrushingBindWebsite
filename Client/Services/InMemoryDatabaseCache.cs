using Client.Static;
using Shared.Models;
using System.Net.Http.Json;

namespace Client.Services
{
    internal sealed class InMemoryDatabaseCache
    {
        private readonly HttpClient _httpClient;

        public InMemoryDatabaseCache(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private List<Archive> _archives = new List<Archive>();

        internal List<Archive> Archives
        {
            get 
            { 
                return _archives; 
            }
            set 
            { 
                _archives = value;
                NotifyArchivesDataChanged();
            }
        }

        //protection to run one at a time.
        private bool _gettingArchivesFromDatabaseAndCaching = false;
        internal async Task GetArchivesChaptersFromDatabaseAndCache()
        {
            if (_gettingArchivesFromDatabaseAndCaching == false)
            {
                _gettingArchivesFromDatabaseAndCaching = true;
                _archives = await _httpClient.GetFromJsonAsync<List<Archive>>(APIEndpoints.s_archives);
                _gettingArchivesFromDatabaseAndCaching = false;
            }
        }

        internal event Action OnArchivesDataChanged;

        private void NotifyArchivesDataChanged() => OnArchivesDataChanged?.Invoke();

    }
}
