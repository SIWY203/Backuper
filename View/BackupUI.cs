using static BackupManager;

class BackupUI
{
    public static void Create(Cluster c)
    {
        Console.Clear();
        Console.WriteLine("Creating backup...");
        bool success = CreateBackup(c);
        if (success) Console.WriteLine("Utworzono backup!");
        else Console.WriteLine("Niepowodzenie!");
        Console.ReadLine();

    }

    public static void Restore(Cluster c)
    {
        Console.Clear();
        Console.WriteLine("Restoring backup...");
        bool success = RestoreBackup(c);
        if (success) Console.WriteLine("Przywrócono backup!");
        Console.ReadLine();

    }

    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("Showing all backups...");
        ShowBackups();
        Console.ReadLine();

    }

}