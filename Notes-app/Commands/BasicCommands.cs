namespace Commands;

public static class BasicCommands
{
    public static void Info()
    {
        foreach (string key in CommandsDictionary.Commands.Keys)
        {
            var c = CommandsDictionary.Commands[key];
            FancyPrint.Print($"{key}:  " +
                             $"{c.Description}" +
                             $"\n\t {c.Example}", NoteManager.PrefColor);
        } 
    }

    public static void Exit()
    {
        NoteSerialization.SerializeNotes();
        Environment.Exit(1);
    }

    public static void Color(string[]? args)
    {
        if (args == null)
        {
            FancyPrint.Error("Argument color wasn't passed to a command!");
            return;
        }
        NoteManager.PrefColor = args[0];
    } 
    
    public static void Undo()
    {
        if (NoteManager.BackupNotes == null)
        {
            FancyPrint.Error("Nothing to undo!");
            return;
        }
        NoteManager.Notes = new List<Note>(NoteManager.BackupNotes);
    }
}
