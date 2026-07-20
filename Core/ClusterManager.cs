using System.Text.Json;

class ClusterManager
{
    public static string ConfigPath = Path.Combine("config", "clusters.json");
    public static List<Cluster> Clusters = new();

    public static bool AddCluster(Cluster cluster)
    {
        if (Clusters.Contains(cluster)) return false;
        Clusters.Add(cluster);
        SaveClusters();
        return true;
    }

    public static void RemoveCluster(Cluster cluster)
    {
        if (Clusters.Contains(cluster))
        {
            Clusters.Remove(cluster);
        }
        
    }

    public static bool SaveClusters()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Clusters, options);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static void LoadClusters()
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        if (!File.Exists(ConfigPath)) return;
        var json = File.ReadAllText(ConfigPath);
        Clusters = JsonSerializer.Deserialize<List<Cluster>>(json, options) ?? new List<Cluster>();
    }


}
