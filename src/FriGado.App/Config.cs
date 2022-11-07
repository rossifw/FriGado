using System.ComponentModel;

namespace FriGado.App
{
    public static class Config
    {
        public const string APIUrl = "https://localhost:44345/api";
        public const string HKey = "Fs584fEq8a9P@d4f78Z!a69$SzOvmj";
        public static string BearerToken { get; set; } = string.Empty;
    }
}
