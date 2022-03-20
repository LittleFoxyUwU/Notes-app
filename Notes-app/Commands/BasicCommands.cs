namespace Commands;

public static class BasicCommands
{
    private static string information = "note: <text>\ncolornote: <color> <text>\ndisplay: Optional(<ID>)\nchange: <ID> <new text>\n" +
                                        "delete: <ID>\ndeleteall\nundo\ncolor: <color>\n exit";

    public static void Info() => FancyPrint.Print(information, ConsoleColor.Green);

    public static void Exit()
    {
        NoteSerialization.SerializeNotes();
        Environment.Exit(1);
    }
    
    public static void Color(string color) => NoteManager.PrefColor = color; 
}