class ConfigManager
{
    private static readonly string AppFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Backuper");

    //public static string ClusterConfigFile { get; } = Path.Combine(AppFolder, "clusters.json");
    //public static string LanguageConfigFile { get; } = Path.Combine(AppFolder, "lang_config.txt");

    // temporary for no use appdata
    public static string ClusterConfigFile = Path.Combine(AppContext.BaseDirectory, "clusters.json");
    public static string LanguageConfigFile = Path.Combine(AppContext.BaseDirectory, "lang_config.txt");

    static ConfigManager()
    {
        // konstruktor statyczny,
        // tworzy foldery na dowolnym OS, jeśli nie istnieją
        Directory.CreateDirectory(AppFolder);
    }
}
    

