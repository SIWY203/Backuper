public readonly record struct RestoreResult(bool IsSuccess, string? ErrorKey = null, string? TempPath = null)
{
    public static RestoreResult Ok() => new(true);
    public static RestoreResult Fail(string errorKey, string? tempPath = null) => new(false, errorKey, tempPath);
}

