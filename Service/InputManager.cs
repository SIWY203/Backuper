class InputManager
{
    public static bool IsWithinScope<T>(string input, List<T> scope, out int num)
    {
        bool success = int.TryParse(input, out num);
        if (success && num - 1 >= 0 && num - 1 < scope.Count)
        {
            return true;
        }
        return false;
    }

}
