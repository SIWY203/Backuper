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
        if (!ConfirmRestore())
        {
            Console.WriteLine("Anulowano...");
            Console.ReadLine();
            return;
        } 
        
        if (!AnyBackupExists(c))
        {
            Console.WriteLine("Brak backupów do przywrocenia!");
            Console.ReadLine();
            return;
        } 

        bool success = RestoreBackup(c);
        if (success) Console.WriteLine("Przywrócono backup!");
        Console.ReadLine();

    }

    public static bool ConfirmRestore()
    {
        Console.Clear();
        Console.WriteLine($"Czy na pewno chcesz przywrócić backup?");
        Console.WriteLine($"[T] Tak, przywróć\n[N] Nie, anuluj");
        Console.Write("Wybierz: ");
        string input = Console.ReadLine() ?? "";
        Console.Clear();

        if (input.ToUpper() == "T") return true;
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

        Console.ReadLine();

    }


}