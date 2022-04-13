using Commands;

public static class NoteManager
{
    public static List<Note>? BackupNotes;
    public static string PrefColor = "White";
    public static List<Note> Notes = new(100);

    public static void ExecuteCommand(string command, string[]? args = null)
    {
        CommandsDictionary.Arguments = args;
        if (CommandsDictionary.Commands.ContainsKey(command))
        {
            CommandsDictionary.Commands[command].Action.Invoke();
        }
        else
            FancyPrint.Error("No command found, try info if you need help");
    }
}