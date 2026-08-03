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
        
        if (!AnyBackupExists(c))
        {
            Console.WriteLine(Loc.Get("NoBackupToRestore"));
            Console.ReadLine();
            return;
        } 

        bool success = RestoreBackup(c);
        if (success) Console.WriteLine(Loc.Get("BackupRestored"));
        Console.ReadLine();

    }

    public static bool ConfirmRestore()
    {
        Console.Clear();
        Console.WriteLine(Loc.Get("ConfirmRestoreBackup"));
        Console.WriteLine(Loc.Get("YesOrNo"));
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
            Console.WriteLine("Brak backupów do wyświetlenia!");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Backupy klastra {c.Name}:");
        foreach (var backup in backups)
        {
            Console.WriteLine($" - {backup}");
        }

        Process.Start("explorer.exe", c.Target);

        Console.ReadLine();

    }


}