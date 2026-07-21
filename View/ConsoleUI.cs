using static ClusterManager;

class ConsoleUI
{
    public static void Log(params object[] logs)
    {
        foreach (var log in logs) Console.WriteLine(log);
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

