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
    }
}
