using Commands;

public static class NoteManager
{
    public static List<Note>? BackupNotes;
    public static string PrefColor = Console.ForegroundColor.ToString();
    public static List<Note> Notes = new(100);
    
    public static void ExecuteCommand(string command, string[]? args = null)
    {
        switch (command)
        {
            case "info": BasicCommands.Info(); break;
            
            case "note": NoteCommands.AddNote(string.Join(' ', args!)); break;
            
            case "colornote":
                if (args!.Length < 2)
                {
                    FancyPrint.Print("ERROR: Either argument \"Color\" or \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }
                NoteCommands.AddColorNote(args[0], string.Join(' ', args[1..]));
                break;
                
            case "display":
                if (args != null)
                    NoteCommands.Display(int.Parse(args[0]));
                else
                    NoteCommands.Display();
                break;

            case "delete": NoteCommands.Delete(int.Parse(args![0])); break;
            
            case "deleteall": NoteCommands.DeleteAll(); break;

            case "color": BasicCommands.Color(args![0]); break;
            
            case "change":
                if (args!.Length < 2)
                {
                    FancyPrint.Print("ERROR: Either argument \"Id\" or \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }
                NoteCommands.Change(int.Parse(args[0]), string.Join(' ', args[1..]));
                break;
                
            case "undo": NoteCommands.Undo(); break;
            
            case "exit": BasicCommands.Exit(); break;
            
            default: FancyPrint.Print("ERROR: Invalid Command!", ConsoleColor.Red); break;
        }
    }
}