class Cleaner
{
    public static int MaxBackupCount { get; set; } = 3;
    public static int MaxSnapshotCount { get; set; } = 2;

    public enum Mode { Backup, Snapshot }

    public static void LoadConfig()
    {
        // załadować w Program.cs, wczytać configi z json, ustalić plik w ConfigManager.cs
    }

    public static void SetLimit(int limit, Mode mode)
    {
        if (mode == Mode.Backup) MaxBackupCount = limit;
        if (mode == Mode.Snapshot) MaxSnapshotCount = limit;
    }


    public static Result Check(Cluster cluster, Mode mode)
    {

        return Result.Ok();
    }


    public static Result CleanUp(Cluster cluster, Mode mode)
    {

        return Result.Ok();
    }

}
