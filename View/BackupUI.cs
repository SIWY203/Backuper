using static BackupManager;
using System.Diagnostics;

class BackupUI
{
    public static void Create(Cluster c)
    {
        Console.Clear();
        Console.WriteLine(Loc.Get("BackupCreating"));
        bool success = CreateBackup(c);
        if (success) Console.WriteLine(Loc.Get("BackupCreated"));
        else Console.WriteLine(Loc.Get("Failure"));
        Console.ReadLine();

    }

    public static void Restore(Cluster c)
    {
        Console.Clear();
        if (!ConfirmRestore())
        {
            Console.WriteLine(Loc.Get("Cancelled"));
            Console.ReadLine();
            return;
        }

        RestoreResult result = RestoreBackup(c);
        if (result.IsSuccess) Console.WriteLine(Loc.Get("BackupRestored"));
        else
        {
            Console.WriteLine(Loc.Get(result.ErrorKey ?? "Failure"));
            if (result.TempPath is not null) Console.WriteLine(Loc.Format("ErrTempSavedAt", result.TempPath));
        }
        Console.ReadLine();

    }

    public static bool ConfirmRestore()
    {
        Console.Clear();
        Console.WriteLine(Loc.Get("AskForRestoreBackup"));
        Console.WriteLine(Loc.Get("ConfirmRestoreBackup"));
        Console.Write(Loc.Get("Select"));
        string input = Console.ReadLine() ?? "";
        Console.Clear();

        if (input.ToUpper() == "Y") return true;
        return false;
    }

    public static void Show(Cluster c)
    {
        Console.Clear();
        List<string> backups = GetBackups(c);

        if (!AnyBackupExists(c))
        {
            Console.WriteLine(Loc.Get("NoBackupToDisplay"));
            Console.ReadLine();
            return;
        }

        Console.WriteLine(Loc.Format("BackupsOfCluster", c.Name));
        foreach (var backup in backups)
        {
            Console.WriteLine($" - {backup}");
        }

        Process.Start("explorer.exe", c.Target);

        Console.ReadLine();

    }


}