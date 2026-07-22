using static ClusterManager;
using static InputManager;

class ConsoleUI
{
    public static void Log(params object[] logs)
    {
        foreach (var log in logs) Console.WriteLine(log);
    }

    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine($"============ Backuper ============");
        if (Clusters.Count > 0)
        {
            Console.WriteLine("Cluster list:");
            for (int i = 0; i < Clusters.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {Clusters[i].Name}");
            }
        }

        Console.WriteLine($"");
        Console.WriteLine($"[A] Add cluster");
        Console.WriteLine($"[R] Remove cluster");
        Console.WriteLine($"[Q] Quit\n");

        Console.Write($"Select: ");
        string input = Console.ReadLine() ?? "";
        if (IsWithinScope(input, Clusters, out int num))
        {
            ClusterUI.Details(Clusters[num-1]);
        }
        if (input.ToLower() == "a") ClusterUI.RunCreator();
        if (input.ToLower() == "r") ClusterUI.RunRemover();
        if (input.ToLower() == "q") Environment.Exit(0);


    }

}

