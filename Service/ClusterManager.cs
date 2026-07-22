using System.Text.Json;

class ClusterManager
{
    public static string ConfigPath => Path.Combine("config", "clusters.json");
    public static List<Cluster> Clusters = new();

    public static bool AddCluster(Cluster cluster)
    {
        if (Clusters.Contains(cluster)) return false;
        Clusters.Add(cluster);
        return SaveClusters();
    }

    public static void RemoveCluster(Cluster cluster)
    {
        if (Clusters.Contains(cluster))
        {
            Clusters.Remove(cluster);
            SaveClusters();
        }
        
    }

    public static bool SaveClusters()
    {
        try
        {
            string? dirPath = Path.GetDirectoryName(ConfigPath);
            if (!string.IsNullOrEmpty(dirPath)) Directory.CreateDirectory(dirPath);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Clusters, options);
            File.WriteAllText(ConfigPath, json);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static void LoadClusters()
    {
        if (!File.Exists(ConfigPath)) return;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var json = File.ReadAllText(ConfigPath);
        Clusters = JsonSerializer.Deserialize<List<Cluster>>(json, options) ?? new List<Cluster>();
    }


}
