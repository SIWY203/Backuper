using static ConfigManager;

public enum Lang { PL, EN }

public static class Loc
{
    public static Lang CurrentLang { get; set; } = Lang.EN;

    private static readonly Dictionary<string, Dictionary<Lang, string>> Dictionary = new()
    {
        // ================================
        //  main menu
        // ================================
        ["HeaderMenu"] = new() {
            [Lang.PL] = "============ Backuper ============",
            [Lang.EN] = "============ Backuper ============"
        },
        ["ClusterList"] = new() {
            [Lang.PL] = "Lista klastrów: ",
            [Lang.EN] = "Cluster list:"
        },
        ["OptAddCluster"] = new() {
            [Lang.PL] = "[A] Dodaj klaster",
            [Lang.EN] = "[A] Add cluster"
        },
        ["OptRemoveCluster"] = new() {
            [Lang.PL] = "[R] Usuń klaster",
            [Lang.EN] = "[R] Remove cluster"
        },
        ["OptSettings"] = new() {
            [Lang.PL] = "[S] Ustawienia",
            [Lang.EN] = "[S] Settings"
        },
        ["Quit"] = new() {
            [Lang.PL] = "[Q] Wyjdź",
            [Lang.EN] = "[Q] Quit"
        },

        // ================================
        //  settings
        // ================================
        ["HeaderSettings"] = new() {
            [Lang.PL] = "=========== Ustawienia ===========",
            [Lang.EN] = "============ Settings ============"
        },
        ["Language"] = new() {
            [Lang.PL] = "[1] Język",
            [Lang.EN] = "[1] Language"
        },
        ["LanguageSet"] = new() {
            [Lang.PL] = "Ustawiono język polski",
            [Lang.EN] = "English language set"
        },
        ["English"] = new() {
            [Lang.PL] = "[1] English",
            [Lang.EN] = "[1] English"
        },
        ["Polish"] = new() {
            [Lang.PL] = "[2] Polski",
            [Lang.EN] = "[2] Polski"
        },

        // ================================
        //  backups
        // ================================
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
        ["AskForRestoreBackup"] = new() {
            [Lang.PL] = "Czy na pewno chcesz przywrócić backup?",
            [Lang.EN] = "Are you sure you want to restore the backup?"
        },
        ["ConfirmRestoreBackup"] = new()
        {
            [Lang.PL] = "[Y] Tak, przywróć\n[N] Nie, anuluj",
            [Lang.EN] = "[Y] Yes, restore\n[N] No, cancel"
        },
        ["NoBackupToDisplay"] = new()
        {
            [Lang.PL] = "Brak backupów do wyświetlenia!",
            [Lang.EN] = "There is no backups to display!"
        },
        ["BackupsOfCluster"] = new()
        {
            [Lang.PL] = "Backupy klastra {0}: ",
            [Lang.EN] = "Backups of cluster {0}: "
        },
        ["ErrPathNotExist"] = new()
        {
            [Lang.PL] = "Ścieżka źródłowa, lub do backupów nie istnieje!",
            [Lang.EN] = "Source path or backup path does not exist!"
        },
        ["ErrCloneFailed"] = new()
        {
            [Lang.PL] = "Kopiowanie nie powiodło się!",
            [Lang.EN] = "Copying failed!"
        },
        ["ErrReplaceFailed"] = new()
        {
            [Lang.PL] = "Kopiowanie nie powiodło się!",
            [Lang.EN] = "Copying failed!"
        },


        // ================================
        //  clusters
        // ================================
        ["HeaderCreator"] = new()
        {
            [Lang.PL] = "=== KREATOR KLASTRÓW ===",
            [Lang.EN] = "=== CLUSTER CREATOR ==="
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
        ["ErrEmptyFields"] = new() { 
            [Lang.PL] = "Błąd: Wszystkie pola muszą być wypełnione!",
            [Lang.EN] = "Error: All fields must be filled!" 
        },
        ["ErrEmptyField"] = new() { 
            [Lang.PL] = "Błąd: Nic nie wpisano!",
            [Lang.EN] = "Error: Nothing was entered!"
        },
        ["ErrSubfolder"] = new() {
            [Lang.PL] = "Błąd: Ścieżka docelowa nie może być podfolderem źródła!",
            [Lang.EN] = "Error: Destination cannot be a subfolder of source!" 
        },
        ["ClusterAdded"] = new() {
            [Lang.PL] = "Klaster {0} został dodany!",
            [Lang.EN] = "Cluster {0} added!" 
        },
        ["ClusterExists"] = new() { 
            [Lang.PL] = "Klaster {0} już istnieje!",
            [Lang.EN] = "Cluster {0} already exists!" 
        },
        ["SelectToRemove"] = new() {
            [Lang.PL] = "Wybierz do usunięcia:",
            [Lang.EN] = "Select to remove:"
        },
        ["AskToRemoveCluster"] = new()
        {
            [Lang.PL] = "Czy na pewno chcesz usunąć cluster?",
            [Lang.EN] = "Are you sure you want to remove cluster?"
        },
        ["ConfirmRemoveCluster"] = new()
        {
            [Lang.PL] = "[Y] Tak, usuń\n[N] Nie, anuluj",
            [Lang.EN] = "[Y] Yes, remove\n[N] No, cancel"
        },
        ["ClusterDetails"] = new()
        {
            [Lang.PL] = "Klaster {0} \nŚcieżka źródłowa: {1} \nŚcieżka docelowa: {2} \n",
            [Lang.EN] = "Cluster {0} \nSource path: {1} \nTarget path: {2} \n"
        },
        ["OptEditCluster"] = new()
        {
            [Lang.PL] = "[E] Edytuj klaster\n",
            [Lang.EN] = "[E] Edit cluster\n"
        },
        ["OptCreateBackup"] = new() {
            [Lang.PL] = "[1] Stwórz backup", 
            [Lang.EN] = "[1] Create Backup" 
        },
        ["OptRestoreBackup"] = new() {
            [Lang.PL] = "[2] Przywróć backup",
            [Lang.EN] = "[2] Restore Backup" 
        },
        ["OptShowBackups"] = new() { 
            [Lang.PL] = "[3] Pokaż wszystkie backupy",
            [Lang.EN] = "[3] Show All Backups" 
        },
        ["ErrClusterAlreadyExist"] = new() { 
            [Lang.PL] = "Błąd! Ten klaster już istnieje!",
            [Lang.EN] = "Error! Cluster already exist!"
        },
        ["ErrSameDirectory"] = new() { 
            [Lang.PL] = "Błąd! Nie można przypisać tego samego folderu do obu ścieżek!",
            [Lang.EN] = "Error! Cannot assign the same folder to both paths!"
        },

        // ================================
        //  cluster editor
        // ================================
        ["HeaderClusterEditor"] = new() { 
            [Lang.PL] = "============ EDYTOR KLASTRÓW ============",
            [Lang.EN] = "============ CLUSTER EDITOR ============="
        },
        ["OptUpdateClusterName"] = new() { 
            [Lang.PL] = "[1] Zmień nazwę",
            [Lang.EN] = "[1] Change name"
        },
        ["OptUpdateClusterSource"] = new() { 
            [Lang.PL] = "[2] Zmień ścieżkę źródłową",
            [Lang.EN] = "[2] Change source path"
        },
        ["OptUpdateClusterTarget"] = new() { 
            [Lang.PL] = "[3] Zmień ścieżkę docelową",
            [Lang.EN] = "[3] Change backup path"
        },
        ["UpdateClusterName"] = new() { 
            [Lang.PL] = "Podaj nową nazwę: ",
            [Lang.EN] = "Enter new name: "
        },
        ["UpdateClusterSource"] = new() { 
            [Lang.PL] = "Podaj nowe źródło: ",
            [Lang.EN] = "Enter new source: "
        },
        ["UpdateClusterTarget"] = new() { 
            [Lang.PL] = "Podaj nową ścieżkę backupów: ",
            [Lang.EN] = "Enter new backup path: "
        },
        ["UpdateNameSuccess"] = new() { 
            [Lang.PL] = "Nazwa została zmieniona!",
            [Lang.EN] = "The name has been changed!"
        },
        ["UpdatePathSuccess"] = new() { 
            [Lang.PL] = "Ścieżka została zmieniona!",
            [Lang.EN] = "The path has been changed!"
        },

        // ================================
        //  snapshot
        // ================================
        ["ErrSnapshotCreatingFailed"] = new()
        {
            [Lang.PL] = "Nie udało się zrobić snapshota! Anulowano.",
            [Lang.EN] = "Snapshot failed! Operation canceled."
        },
        ["ErrSnapshotPathNotExist"] = new()
        {
            [Lang.PL] = "Ścieżka do snapshota nie istnieje!",
            [Lang.EN] = "Snapshot failed! Operation canceled."
        },

        // ================================
        //  standard
        // ================================
        ["OptBack"] = new()
        {
            [Lang.PL] = "[Q] Powrót",
            [Lang.EN] = "[Q] Back"
        },
        ["Select"] = new() { 
            [Lang.PL] = "\nWybierz: ",
            [Lang.EN] = "\nSelect: " 
        },
        ["Cancelled"] = new() {
            [Lang.PL] = "Anulowano...",
            [Lang.EN] = "Cancelled..."
        },
        ["Failure"] = new() {
            [Lang.PL] = "Niepowodzenie!",
            [Lang.EN] = "Failure!"
        },        
        
    
    };


    // Loc.Get("msgKey")
    public static string Get(string key)
    {
        if(Dictionary.TryGetValue(key, out var translations) && translations.TryGetValue(CurrentLang, out var text))
        {
            return text;
        }
        return key;
    }


    // Loc.Format("msgKey", arg0, arg1, arg2...)
    public static string Format(string key, params object[] args)
    {
        return string.Format(Get(key), args);
    }


    // Lang Configs
    public static void LoadLangConfig()
    {
        if (File.Exists(LanguageConfigFile))
        {
            string lang = File.ReadAllText(LanguageConfigFile).Trim();
            if (Enum.TryParse(lang, true, out Lang parsedLang))
            {
                CurrentLang = parsedLang;
                return;
            }
        }
        CurrentLang = Lang.EN; // default
    }
    public static void Set(Lang lang)
    {
        CurrentLang = lang;
        File.WriteAllText(LanguageConfigFile, lang.ToString());
    }
}

