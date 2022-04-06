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

        private List<ArchiveModel> _archiveModels = null;

        internal List<ArchiveModel> ArchiveModels
        {
            get 
            { 
                return _archiveModels; 
            }
            set 
            {
                _archiveModels = value;
                NotifyArchiveModelsDataChanged();
            }
        }

        //protection to run one at a time.
        private bool _gettingArchivesFromDatabaseAndCaching = false;
        internal async Task GetArchiveModelsFromDatabaseAndCache()
        {
            if (_gettingArchivesFromDatabaseAndCaching == false)
            {
                _gettingArchivesFromDatabaseAndCaching = true;
                _archiveModels = await _httpClient.GetFromJsonAsync<List<ArchiveModel>>(APIEndpoints.s_archiveModels);
                _gettingArchivesFromDatabaseAndCaching = false;
            }
        }

        internal event Action OnArchiveModelsDataChanged;

        private void NotifyArchiveModelsDataChanged() => OnArchiveModelsDataChanged?.Invoke();

    }
}
