class UI
{
    public static void Log(params object[] logs)
    {
        foreach (var log in logs) Console.WriteLine(log);
    }


}

