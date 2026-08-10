class ConfigManager
{
    private static readonly string AppFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Backuper");

    public static string ClusterConfigFile { get; } = Path.Combine(AppFolder, "clusters.json");
    public static string LanguageConfigFile { get; } = Path.Combine(AppFolder, "lang_config.txt");

    static ConfigManager()
    {
        // konstruktor statyczny,
        // tworzy foldery na dowolnym OS, jeśli nie istnieją
        Directory.CreateDirectory(AppFolder);
    }
}
