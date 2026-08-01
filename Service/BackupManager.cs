class BackupManager
{
    public static bool CreateBackup(Cluster c)
    {
        if (!Directory.Exists(c.Source) || !Directory.Exists(c.Target)) return false;

        // backup folder
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        string targetDir = Path.Combine(c.Target, $"{c.Name}_{timestamp}");
        CloneDirectory(c.Source, targetDir);
        return true;
    }


    public static bool RestoreBackup(Cluster c)
    {
        if (!Directory.Exists(c.Source) || !Directory.Exists(c.Target)) return false;

        string[] backups = Directory.GetDirectories(c.Target, $"{c.Name}_*");
        if (backups.Length == 0) return false; // no backups

        string temp = $"{c.Source}_temp";
        Directory.CreateDirectory(temp);

        string latest = backups.OrderBy(d => d).Last();
        bool success = CloneDirectory(latest, temp);

        if (success)
        {
            Directory.Delete(c.Source, true);
            Directory.Move(temp, c.Source);
            return true;
        }

        return false;
        
    }


    public static List<string> GetBackups(Cluster c)
    {
        string pattern = $"{c.Name}_*";
        string[] paths = Directory.GetDirectories(c.Target, pattern);
        List<string> backups = paths.ToList();

        if (!Directory.Exists(c.Target))
        {
            return new List<string>();
        }
        return backups;
    }

    public static bool AnyBackupExists(Cluster c)
    {
        if (GetBackups(c).Count == 0)
        {
            return false;
        }
        return true;
    }


    private static bool CloneDirectory(string src, string dest)
    {
        // anti copy loop, if destination is inside source
        if (dest.StartsWith(src, StringComparison.OrdinalIgnoreCase)) return false;

        try
        {
            Directory.CreateDirectory(dest);

            foreach (var file in Directory.GetFiles(src))
            {
                string fileName = Path.GetFileName(file);
                string fileDest = Path.Combine(dest, fileName);
                File.Copy(file, fileDest, true);
            }

            foreach (var dir in Directory.GetDirectories(src))
            {
                string dirName = Path.GetFileName(dir);
                string dirDest = Path.Combine(dest, dirName);
                CloneDirectory(dir, dirDest); // recursion
            }
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

}
