using static ClusterManager;

class Program
{
    public static void Main(string[] args)
    {

        LoadClusters();
        if (Clusters.Count == 0)
        {
            ConsoleUI.RunCreator();
            SaveClusters();
        }

        ConsoleUI.Menu();


    }

}
