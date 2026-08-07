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


    public static bool RemoveCluster(Cluster cluster)
    {
        if (!Clusters.Contains(cluster)) return false;
        Clusters.Remove(cluster);
        return SaveClusters();
        
    }


    public static bool SaveClusters()
    {
        try
        {
            EnsureDirectoryExists(ConfigPath);

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


    public static Cluster? UpdateClusterName(Cluster current, string newName)
    {
        newName = newName.Trim();
        if (string.IsNullOrWhiteSpace(newName)) return null;

        int index = Clusters.IndexOf(current);
        if (index == -1) return null;

        Cluster newCluster = current with { Name = newName };
        Clusters[index] = newCluster;
        return SaveClusters() ? newCluster : null;
    }

    public static Cluster? UpdateClusterSource(Cluster current, string newSource)
    {
        newSource = newSource.Trim();
        if (string.IsNullOrWhiteSpace(newSource) || !Directory.Exists(newSource)) return null;

        int index = Clusters.IndexOf(current);
        if (index == -1) return null;

        Cluster newCluster = current with { Source = newSource };
        Clusters[index] = newCluster;
        return SaveClusters() ? newCluster : null;
    }

    public static Cluster? UpdateClusterTarget(Cluster current, string newTarget)
    {
        newTarget = newTarget.Trim();
        if (string.IsNullOrWhiteSpace(newTarget) || !Directory.Exists(newTarget)) return null;

        int index = Clusters.IndexOf(current);
        if (index == -1) return null;

        Cluster newCluster = current with { Target = newTarget };
        Clusters[index] = newCluster;
        return SaveClusters() ? newCluster : null;
    }


    private static void EnsureDirectoryExists(string filePath)
    {
        string? dirPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(dirPath) && !Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
    }

}
