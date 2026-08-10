class BackupManager
{
    public static bool CreateBackup(Cluster c)
    {
        if (!Directory.Exists(c.Source) || !Directory.Exists(c.Target)) return false;

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        string targetDir = Path.Combine(c.Target, $"{c.Name}_{timestamp}");

        return CloneDirectory(c.Source, targetDir);
    }


    public static RestoreResult RestoreBackup(Cluster c)
    {
        if (!Directory.Exists(c.Source) || !Directory.Exists(c.Target)) return RestoreResult.Fail("ErrPathNotExist");

        string[] backups = Directory.GetDirectories(c.Target, $"{c.Name}_*");
        if (backups.Length == 0) return RestoreResult.Fail("NoBackupToRestore");

        string latest = backups.Max()!;

        // === TUTAJ BĘDZIE SNAPSHOT PRE-RESTORE ===
        // CreateSnapshot()
        return SafeReplaceDirectory(latest, c.Source);

    }


    private static bool CloneDirectory(string src, string dest)
    {
        // anti copy-loop
        if (IsSubdirectory(src, dest)) return false;

        try
        {
            Directory.CreateDirectory(dest);

            foreach (string file in Directory.GetFiles(src))
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
            }

            foreach (string dir in Directory.GetDirectories(src))
            {
                if (!CloneDirectory(dir, Path.Combine(dest, Path.GetFileName(dir))))
                    return false;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }


    private static RestoreResult SafeReplaceDirectory(string source, string target)
    {
        string temp = $"{target}_temp";

        if (!CloneDirectory(source, temp))
        {
            CleanupDirectory(temp);
            return RestoreResult.Fail("ErrCloneFailed");
        }

        try
        {
            if (Directory.Exists(target))
                Directory.Delete(target, true);

            Directory.Move(temp, target);
            return RestoreResult.Ok();
        }
        catch
        {
            // gdy błąd przy podmianie, temp pozostaje nieusunięty
            return RestoreResult.Fail("ErrReplaceFailedTempSaved", temp);
        }
    }


    private static bool IsSubdirectory(string src, string dest)
    {
        string fullSrc = Path.GetFullPath(src);
        string fullDest = Path.GetFullPath(dest);
        string relative = Path.GetRelativePath(fullSrc, fullDest);

        // gdy zaczyna się od ".." lub równe ".", to dest nie jest wewnątrz src
        return !relative.StartsWith("..") && relative != ".";
    }


    public static List<string> GetBackups(Cluster c)
    {
        if (!Directory.Exists(c.Target)) return [];
        return Directory.GetDirectories(c.Target, $"{c.Name}_*").ToList();
    }


    public static bool AnyBackupExists(Cluster c)
    {
        if (!Directory.Exists(c.Target)) return false;
        return Directory.EnumerateDirectories(c.Target, $"{c.Name}_*").Any();
    }


    private static void CleanupDirectory(string path)
    {
        if (Directory.Exists(path))
            Directory.Delete(path, true);
    }

}
