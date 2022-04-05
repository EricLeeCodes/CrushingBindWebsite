namespace Client.Static
{
    public class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:7202";
#else
        internal const string ServerBaseUrl = "https://appname.azurewebsites.net";
#endif
        internal readonly static string s_archives = $"{ServerBaseUrl}/api/archives";
    }
}
