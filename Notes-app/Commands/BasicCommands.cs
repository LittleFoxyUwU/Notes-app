namespace Commands;

public static class BasicCommands
{
    private static string information = "note: <text>\ncolornote: <color> <text>\ndisplay: Optional(<ID>)" +
                                        "\nchangetext: <ID> <new text>\nchangecolor: <ID> <new color>" +
                                        "\ndelete: <ID>\ndeleteall\nundo\ncolor: <color>\nexit\nsave";

    public static void Info() => FancyPrint.Print(information, ConsoleColor.Green);

    public static void Exit()
    {
        NoteSerialization.SerializeNotes();
        Environment.Exit(1);
    }
    
    public static void Color(string color) => NoteManager.PrefColor = color; 
    
    public static void Undo()
    {
        if (NoteManager.BackupNotes == null)
        {
            FancyPrint.Print("Nothing to undo!", ConsoleColor.Yellow);
            return;
        }
        NoteManager.Notes = new List<Note>(NoteManager.BackupNotes);
    }
}
