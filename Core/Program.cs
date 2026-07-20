using static ClusterManager;

class Program
{
    public static void Main(string[] args)
    {

        LoadClusters();
        if (Clusters.Count == 0)
        {
            UI.RunCreator();
            SaveClusters();
        }

        UI.Menu();


    }

}
