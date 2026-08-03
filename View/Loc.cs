public enum Lang { PL, EN }

public static class Loc
{
    public static Lang CurrentLang { get; set; } = Lang.EN;

    private static readonly Dictionary<string, Dictionary<Lang, string>> Dictionary = new()
    {
        ["HeaderCreator"] = new()  { 
            [Lang.PL] = "=== KREATOR KLASTRA ===", 
            [Lang.EN] = "=== CLUSTER CREATOR ===" 
        },
        ["BackupCreating"] = new() {
            [Lang.PL] = "Tworzenie kopii...",
            [Lang.EN] = "Creating backup..."
        },
        ["BackupCreated"] = new() {
            [Lang.PL] = "Utworzono backup!",
            [Lang.EN] = "Backup created!"
        },
        ["BackupRestored"] = new() {
            [Lang.PL] = "Przywrócono backup!",
            [Lang.EN] = "Backup restored!"
        },
        ["NoBackupToRestore"] = new() {
            [Lang.PL] = "Brak backupów do przywrocenia!",
            [Lang.EN] = "There is no backups to restore!"
        },
        ["ConfirmRestoreBackup"] = new() {
            [Lang.PL] = "Czy na pewno chcesz przywrócić backup?",
            [Lang.EN] = "Are you sure you want to restoe the backup?"
        },

        

        ["EnterClusterName"] = new()  { 
            [Lang.PL] = "Podaj nazwę klastra: ", 
            [Lang.EN] = "Enter cluster name: " 
        },
        ["EnterClusterSource"] = new()  { 
            [Lang.PL] = "Podaj ścieżkę źródłową: ",
            [Lang.EN] = "Enter source path: " },
        ["EnterClusterTarget"] = new()  { 
            [Lang.PL] = "Podaj ścieżkę backupu: ",
            [Lang.EN] = "Enter backup path: " 
        },
        ["ErrEmptyFields"] = new()  { 
            [Lang.PL] = "Błąd: Wszystkie pola muszą być wypełnione!",
            [Lang.EN] = "Error: All fields must be filled!" 
        },
        ["ErrSubfolder"] = new() { [Lang.PL] = "Błąd: Ścieżka docelowa nie może być podfolderem źródła!", [Lang.EN] = "Error: Destination cannot be a subfolder of source!" },
        ["ClusterAdded"] = new() { [Lang.PL] = "Klaster {0} został dodany!", [Lang.EN] = "Cluster {0} added!" },
        ["ClusterExists"] = new() { [Lang.PL] = "Klaster {0} już istnieje!", [Lang.EN] = "Cluster {0} already exists!" },
        ["HeaderRemover"] = new() { [Lang.PL] = "=== USUWANIE KLASTRA ===", [Lang.EN] = "=== CLUSTER REMOVER ===" },
        ["SelectToRemove"] = new() { [Lang.PL] = "Wybierz do usunięcia:", [Lang.EN] = "Select to remove:" },
        ["ConfirmRemoveCluster"] = new()
        {
            [Lang.PL] = "Czy na pewno chcesz usunąć cluster?",
            [Lang.EN] = "Are you sure you want to remove cluster?"
        },
        ["ConfirmRemove"] = new()
        {
            [Lang.PL] = "[Y] Tak, usuń\n[N] Nie, anuluj",
            [Lang.EN] = "[Y] Yes, remove\n[N] No, cancel"
        },



        ["Select"] = new() { 
            [Lang.PL] = "Wybierz: ",
            [Lang.EN] = "Select: " 
        },
        ["Cancelled"] = new() {
            [Lang.PL] = "Anulowano...",
            [Lang.EN] = "Cancelled..."
        },
        ["Failure"] = new() {
            [Lang.PL] = "Niepowodzenie!",
            [Lang.EN] = "Failure!"
        },
        ["Yes"] = new() { 
            [Lang.PL] = "Y",
            [Lang.EN] = "Y" 
        },
        ["No"] = new() {
            [Lang.PL] = "N",
            [Lang.EN] = "N"
        },
        ["YesOrNo"] = new() {
            [Lang.PL] = "[Y] Tak, przywróć\n[N] Nie, anuluj",
            [Lang.EN] = "[Y] Yes, restore\n[N] No, cancel"
        },
        ["SourcePath"] = new() { 
            [Lang.PL] = "Ścieżka źródłowa: ",
            [Lang.EN] = "Source path: " 
        },
        ["TargetPath"] = new() { 
            [Lang.PL] = "Ścieżka docelowa: ",
            [Lang.EN] = "Target path: " 
        },
        ["OptCreateBackup"] = new() { [Lang.PL] = "[1] Utwórz kopię zapasową", [Lang.EN] = "[1] Create Backup" },
        ["OptRestoreBackup"] = new() { [Lang.PL] = "[2] Przywróć kopię zapasową", [Lang.EN] = "[2] Restore Backup" },
        ["OptShowBackups"] = new() { [Lang.PL] = "[3] Pokaż wszystkie kopie zapasowe", [Lang.EN] = "[3] Show All Backups" },
        ["OptBack"] = new() { [Lang.PL] = "[Q] Powrót", [Lang.EN] = "[Q] Back" }
    
    };


    public static string Get(string key)
    {
        if(Dictionary.TryGetValue(key, out var translations) && translations.TryGetValue(CurrentLang, out var text))
        {
            return text;
        }
        return key;
    }
}

