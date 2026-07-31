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

    public static void Show(Cluster c)
    {
        Console.Clear();
        List<string> backups = GetBackups(c);

        if (backups.Count == 0)
        {
            Console.WriteLine($"Brak backupów!");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Backupy klastra {c.Name}:");
        foreach (var backup in backups)
        {
            Console.WriteLine($" - {backup}");
        }

        Console.ReadLine();

    }

}