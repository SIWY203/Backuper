using static ClusterManager;
using static InputManager;

class MenuUI
{
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine(Loc.Get("HeaderMenu"));
        if (Clusters.Count > 0)
        {
            Console.WriteLine(Loc.Get("ClusterList"));
            for (int i = 0; i < Clusters.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {Clusters[i].Name}");
            }
        }

        Console.WriteLine();
        Console.WriteLine(Loc.Get("OptAddCluster"));
        Console.WriteLine(Loc.Get("OptRemoveCluster"));
        Console.WriteLine(Loc.Get("OptSettings"));
        Console.WriteLine(Loc.Get("Quit"));
        Console.Write(Loc.Get("Select"));

        string input = Console.ReadLine() ?? "";
        if (IsWithinScope(input, Clusters, out int num))
        {
            ClusterUI.Details(Clusters[num-1]);
        }
        if (input.ToLower() == "a") ClusterUI.RunCreator();
        if (input.ToLower() == "r") ClusterUI.RunRemover();
        if (input.ToLower() == "s") Settings();
        if (input.ToLower() == "q") Environment.Exit(0);

    }

    public static void Settings()
    {
        Console.Clear();
        Console.WriteLine(Loc.Get("HeaderSettings"));
        Console.WriteLine(Loc.Get("Language"));
        Console.WriteLine(Loc.Get("BackupLimit"));
        Console.Write(Loc.Get("Select"));

        string input = Console.ReadLine() ?? "";
        if (input == "1") LanguageSettings();
        if (input == "2") LimitSettings();
    }

    public static void LanguageSettings()
    {
        Console.Clear();
        Console.WriteLine(Loc.Get("English"));
        Console.WriteLine(Loc.Get("Polish"));
        Console.Write(Loc.Get("Select"));

        string input = Console.ReadLine() ?? "";

        if (input == "1") Loc.Set(Lang.EN);
        else if (input == "2") Loc.Set(Lang.PL);
        else return;

        Console.Clear();
        Console.WriteLine(Loc.Get("LanguageSet"));
        Console.ReadLine();
    }

    public static void LimitSettings()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(Loc.Format("ShowCurrentLimits", Cleaner.MaxBackupCount, Cleaner.MaxSnapshotCount));
            Console.WriteLine(Loc.Get("SetBackupLimit"));
            Console.WriteLine(Loc.Get("SetSnapshotLimit"));
            Console.WriteLine(Loc.Get("OptBack"));
            Console.Write(Loc.Get("Select"));
        
            string input = Console.ReadLine() ?? "";
            if (input.ToUpper() == "Q") return;
            if (!IsWithinScope(input, (1, 2), out int num)) continue;

            Cleaner.Mode mode = num == 1 ? Cleaner.Mode.Backup : Cleaner.Mode.Snapshot;

            Console.Write(Loc.Get("EnterLimitValue"));
            string limitInput = Console.ReadLine() ?? "";
            if (!int.TryParse(limitInput, out int limit))
            {
                Console.Clear();
                Console.WriteLine(Loc.Get("NotNumber"));
                Console.ReadLine();
                return;
            }

            Cleaner.SetLimit(limit, mode);

            Console.Clear();
            Console.WriteLine(Loc.Get("NewLimitSet"));
            Console.ReadLine();
            return;
        }
        
    }


}

