public enum Language { PL, EN }

public static class Loc
{
    public static Language CurrentLanguage { get; set; } = Language.EN;

    private static readonly Dictionary<string, Dictionary<Language, string>> Dictionary = new()
    {
        ["HeaderCreator"] = new() 
        { 
            [Language.PL] = "=== KREATOR KLASTRA ===", 
            [Language.EN] = "=== CLUSTER CREATOR ===" },

        ["CreatingBackup"] = new()
        {
            [Language.PL] = "Tworzenie kopii...",
            [Language.EN] = "Creating backup..." },
        ["EnterName"] = new() 
        { 
            [Language.PL] = "Podaj nazwę klastra: ", 
            [Language.EN] = "Enter cluster name: " },
        ["EnterSource"] = new() 
        { 
            [Language.PL] = "Podaj ścieżkę źródłową: ",
            [Language.EN] = "Enter source path: " },
        ["EnterTarget"] = new() 
        { 
            [Language.PL] = "Podaj ścieżkę backupu: ",
            [Language.EN] = "Enter backup path: " },
        ["ErrEmptyFields"] = new() 
        { 
            [Language.PL] = "Błąd: Wszystkie pola muszą być wypełnione!",
            [Language.EN] = "Error: All fields must be filled!" },
        ["ErrSubfolder"] = new() { [Language.PL] = "Błąd: Ścieżka docelowa nie może być podfolderem źródła!", [Language.EN] = "Error: Destination cannot be a subfolder of source!" },
        ["ClusterAdded"] = new() { [Language.PL] = "Klaster {0} został dodany!", [Language.EN] = "Cluster {0} added!" },
        ["ClusterExists"] = new() { [Language.PL] = "Klaster {0} już istnieje!", [Language.EN] = "Cluster {0} already exists!" },
        ["HeaderRemover"] = new() { [Language.PL] = "=== USUWANIE KLASTRA ===", [Language.EN] = "=== CLUSTER REMOVER ===" },
        ["SelectToRemove"] = new() { [Language.PL] = "Wybierz do usunięcia:", [Language.EN] = "Select to remove:" },
        ["Select"] = new() 
        { 
            [Language.PL] = "Wybierz: ",
            [Language.EN] = "Select: " },
        ["Cancelled"] = new()
        {
            [Language.PL] = "Anulowano...",
            [Language.EN] = "Cancelled..."
        },
        ["Failure"] = new()
        {
            [Language.PL] = "Niepowodzenie!",
            [Language.EN] = "Failure!"
        },
        ["ConfirmRemoveCluster"] = new() 
        { 
            [Language.PL] = "Czy na pewno chcesz usunąć cluster?",
            [Language.EN] = "Are you sure you want to remove cluster?" },
        ["ConfirmRemove"] = new() { [Language.PL] = "[T] Tak, usuń\n[N] Nie, anuluj", [Language.EN] = "[Y] Yes, remove\n[N] No, cancel" },
        ["Yes"] = new() 
        { 
            [Language.PL] = "T",
            [Language.EN] = "Y" },
        ["SourcePath"] = new() 
        { 
            [Language.PL] = "Ścieżka źródłowa: ",
            [Language.EN] = "Source path: " },
        ["TargetPath"] = new() 
        { 
            [Language.PL] = "Ścieżka docelowa: ",
            [Language.EN] = "Target path: " },
        ["OptCreateBackup"] = new() { [Language.PL] = "[1] Utwórz kopię zapasową", [Language.EN] = "[1] Create Backup" },
        ["OptRestoreBackup"] = new() { [Language.PL] = "[2] Przywróć kopię zapasową", [Language.EN] = "[2] Restore Backup" },
        ["OptShowBackups"] = new() { [Language.PL] = "[3] Pokaż wszystkie kopie zapasowe", [Language.EN] = "[3] Show All Backups" },
        ["OptBack"] = new() { [Language.PL] = "[Q] Powrót", [Language.EN] = "[Q] Back" }
    };


    public static string Get(string key)
    {
        if(Dictionary.TryGetValue(key, out var translations) && translations.TryGetValue(CurrentLanguage, out var text))
        {
            return text;
        }
        return key;
    }
}

