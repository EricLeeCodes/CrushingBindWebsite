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

        #region ArchiveModels
        

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

        internal async Task<ArchiveModel> GetArchiveByArchiveId(int archiveId, bool withPosts)
        {
            if(_archiveModels == null)
            {
                await GetArchiveModelsFromDatabaseAndCache(withPosts);
            }

            ArchiveModel archiveToReturn = _archiveModels.First(archive => archive.ArchiveId == archiveId);

            if(archiveToReturn == null && withPosts == true)
            {
                archiveToReturn = await _httpClient.GetFromJsonAsync<ArchiveModel>($"{APIEndpoints.s_archivesWithPosts}/{archiveToReturn.ArchiveId}");
            }

            return archiveToReturn;
        }

        internal async Task<ArchiveModel> GetArchiveByArchiveChapterName(string archiveChapterNumberName, bool withPosts, bool nameToLowerFromUrl)
        {
            if (_archiveModels == null)
            {
                await GetArchiveModelsFromDatabaseAndCache(withPosts);
            }

            ArchiveModel archiveToReturn = null;

            if (nameToLowerFromUrl == true)
            {
                archiveToReturn = _archiveModels.First(archive => archive.ArchiveChapterNumber.ToLowerInvariant() == archiveChapterNumberName);
            }
            else
            {
                archiveToReturn = _archiveModels.First(archive => archive.ArchiveChapterNumber == archiveChapterNumberName);
            }

            if (archiveToReturn.Posts == null && withPosts == true)
            {
                archiveToReturn = await _httpClient.GetFromJsonAsync<ArchiveModel>($"{APIEndpoints.s_archivesWithPosts}/{archiveToReturn.ArchiveId}");
            }

            return archiveToReturn;
        }

        //protection to run one at a time.
        private bool _gettingArchivesFromDatabaseAndCaching = false;
        internal async Task GetArchiveModelsFromDatabaseAndCache(bool withPosts)
        {
            if (_gettingArchivesFromDatabaseAndCaching == false)
            {
                _gettingArchivesFromDatabaseAndCaching = true;

                List<ArchiveModel> archivesFromDatabase = null;

                if (_archiveModels != null)
                {
                    _archiveModels = null;
                }

                if(withPosts == true)
                {
                    archivesFromDatabase = await _httpClient.GetFromJsonAsync<List<ArchiveModel>>(APIEndpoints.s_archivesWithPosts);
                }
                else
                {
                    archivesFromDatabase = await _httpClient.GetFromJsonAsync<List<ArchiveModel>>(APIEndpoints.s_archiveModels);
                }

                _archiveModels = archivesFromDatabase.OrderByDescending(archive => archive.ArchiveId).ToList();

                if (withPosts == true)
                {
                    List<Post> _postsFromArchives = new List<Post>();

                    foreach (var archive in _archiveModels)
                    {
                        if (archive.Posts.Count != 0)
                        {
                            foreach (var post in archive.Posts)
                            {
                                ArchiveModel postArchiveWithoutPosts = new ArchiveModel
                                {
                                    ArchiveId = archive.ArchiveId,
                                    ArchiveThumbnailImagePath = archive.ArchiveThumbnailImagePath,
                                    ArchiveChapterNumber = archive.ArchiveChapterNumber,
                                    Posts = null
                                };



                                post.ArchiveModel = postArchiveWithoutPosts;

                                _postsFromArchives.Add(post);
                            }
                        }
                    }

                    _posts = _postsFromArchives.OrderByDescending(post => post.PostId).ToList();
                }

                _gettingArchivesFromDatabaseAndCaching = false;
            }
        }

        internal event Action OnArchiveModelsDataChanged;

        private void NotifyArchiveModelsDataChanged() => OnArchiveModelsDataChanged?.Invoke();


        #endregion

        #region Posts

        private List<Post> _posts = null;
        internal List<Post> Posts
        {
            get
            {
                return _posts;
            }
            set
            {
                _posts = value;
                NotifyPostsDataChanged();
            }

        }

        internal async Task<Post> GetPostByPostId(int postId)
        {
            if (_posts == null)
            {
                await GetPostsFromDatabaseAndCache();
            }

            return _posts.First(post => post.PostId == postId);
        }

        internal async Task<PostDTO> GetPostDTOByPostId(int postId) => await _httpClient.GetFromJsonAsync<PostDTO>($"{APIEndpoints.s_postsDTO}/{postId}");

        private bool _gettingPostsFromDatabaseAndCaching = false;
        internal async Task GetPostsFromDatabaseAndCache()
        {
            // Only allow one Get to run at a time

            if (_gettingPostsFromDatabaseAndCaching == false)
            {
                _gettingPostsFromDatabaseAndCaching = true;

                if (_posts != null)
                {
                    _posts = null;
                }

                List<Post> postsFromDatabase = await _httpClient.GetFromJsonAsync<List<Post>>(APIEndpoints.s_posts);

                _posts = postsFromDatabase.OrderByDescending(post => post.PostId).ToList();

                _gettingPostsFromDatabaseAndCaching = false;
            }
        }


        internal event Action OnPostsDataChanged;
        private void NotifyPostsDataChanged() => OnPostsDataChanged?.Invoke();

        #endregion

    }

}
