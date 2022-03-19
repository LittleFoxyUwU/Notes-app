namespace Commands;

public static class BasicCommands
{
    private static string information = "note: <text>\tcolornote: <color> <text>\tdisplay: Optional(<ID>)\n" +
                                        "delete: <ID>\tcolor: <color>\t exit";

    public static void Info() => FancyPrint.Print(information, ConsoleColor.Green);
    
    public static void Exit() => Environment.Exit(1);
    
    public static void Color(ConsoleColor color) => NoteManager.PrefColor = color; 
}