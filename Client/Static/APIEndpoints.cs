namespace Client.Static
{
    public class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:7106";
#else
        internal const string ServerBaseUrl = "https://crushingbindserver.azurewebsites.net";
#endif
        internal readonly static string s_archiveModels = $"{ServerBaseUrl}/api/archivemodels";
        internal readonly static string s_archivesWithPosts = $"{ServerBaseUrl}/api/archives/withposts";
        internal readonly static string s_posts = $"{ServerBaseUrl}/api/posts";
        internal readonly static string s_postsDTO = $"{ServerBaseUrl}/api/posts/dto";
        internal readonly static string s_imageUpload = $"{ServerBaseUrl}/api/imageupload";
        internal readonly static string s_signIn = $"{ServerBaseUrl}/api/signin";

    }
}
