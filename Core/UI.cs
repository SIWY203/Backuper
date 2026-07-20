// ==========================
//  Warstwa prezentacji
// ==========================

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
            Console.WriteLine("Błąd: Wszystkie pola muszą być wypełnione!");
            return;
        }

        Cluster newCluster = new Cluster(name, source, target);
        bool isAdded = ClusterManager.AddCluster(newCluster); // jeśli już istniał: false

    }

}

