using static ClusterManager;

class ClusterUI
{
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


}

