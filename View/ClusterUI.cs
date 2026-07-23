using static ClusterManager;
using static InputManager;
using static BackupManager;

class ClusterUI
{
    public static void RunCreator()
    {
        Console.Clear();
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
        Console.ReadLine();

    }

    public static void RunRemover()
    {
        Console.Clear();
        Console.WriteLine($"=== CLUSTER CREATOR ===");
        Console.WriteLine($"Select to remove:");
        for (int i = 0; i < Clusters.Count; i++)
        {
            Console.WriteLine($"[{i+1}] {Clusters[i].Name}");
        }

        Console.Write($"\nSelect: ");
        string input = Console.ReadLine() ?? "";
        if (IsWithinScope(input, Clusters, out int num))
        {
            Cluster c = Clusters[num-1];
            RemoveCluster(c);
        }

    }

    public static void Details(Cluster c)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Cluster {c.Name}");
            Console.WriteLine($"Source path: {c.Source}");
            Console.WriteLine($"Target path: {c.Target}\n");

            Console.WriteLine($"[1] Create Backup");
            Console.WriteLine($"[2] Restore Backup");
            Console.WriteLine($"[3] Show All Backups");
            Console.WriteLine($"[Q] Back\n");

            Console.Write($"Select: ");
            string input = Console.ReadLine() ?? "";
            if (input.ToLower() == "q") return;
            if (!IsWithinScope(input, (1, 3), out int num)) continue;

            switch (num)
            {
                case 1:
                    CreateBackup();
                    break;
                case 2:
                    RestoreBackup();
                    break;
                case 3:
                    ShowBackups();
                    break;
                default:
                    break;
            }

            return; // leave after action
        }
       

    }





}

