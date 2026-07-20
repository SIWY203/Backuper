// ==========================
//  Warstwa prezentacji
// ==========================

using static ClusterManager;
class UI
{
    public static void Log(params object[] logs)
    {
        foreach (var log in logs) Console.WriteLine(log);
    }

    public static void RunCreator()
    {
        Console.WriteLine("=== CLUSTER CREATOR ===");

        Console.Write("Enter cluster name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter source path: ");
        string source = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter backup path: ");
        string target = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target))
        {
            Console.WriteLine("Error: All fields must be filled!");
            return;
        }

        Cluster newCluster = new Cluster(name, source, target);
        bool isAdded = AddCluster(newCluster); // jeśli już istniał: false

        if (isAdded) Console.WriteLine($"Cluster {newCluster.Name} added!");
        else Console.WriteLine($"Cluster {newCluster.Name} already exists!");

    }

    public static void Menu()
    {
        Console.WriteLine($"============ Backuper ============\n");
        if (Clusters.Count > 0)
        {
            Console.WriteLine("Cluster list:");
            for (int i = 0; i < Clusters.Count; i++)
            {
                Console.WriteLine($"[{i + 1:00}] {Clusters[i].Name}");
            }
        }

        Console.WriteLine($"[X] test");
        
    }

}

