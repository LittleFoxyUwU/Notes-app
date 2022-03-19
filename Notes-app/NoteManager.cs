using Commands;

public static class NoteManager
{
    public static ConsoleColor PrefColor = Console.ForegroundColor;
    public static List<Note> Notes = new(100);
    
    public static void ExecuteCommand(string command, string[]? args = null)
    {
        switch (command)
        {
            case "info": BasicCommands.Info(); break;
            
            case "note":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Argument \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }
                NoteCommands.AddNote(string.Join(' ', args));
                break;
            
            case "colornote":
                if (args!.Length < 2)
                {
                    FancyPrint.Print("ERROR: Either argument \"Color\" or \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }
                NoteCommands.AddColorNote(GetColor.GetColorByName(args[0]), string.Join(' ', args[1..]));
                break;
                
            case "display":
                if (args != null)
                    NoteCommands.Display(int.Parse(args[0]));
                else
                    NoteCommands.Display();
                break;

            case "delete":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Argument \"ID\" not found!", ConsoleColor.Red);
                    break;
                }
                int id = int.Parse(args[0]);
                NoteCommands.Delete(id);
                break;
            
            case "exit": BasicCommands.Exit(); break;
            
            case "color":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Argument \"Color\" not found!", ConsoleColor.Red);
                    break;
                }
                BasicCommands.Color(GetColor.GetColorByName(args[0]));
                break;
                
            default: FancyPrint.Print("ERROR: Invalid Command!", ConsoleColor.Red); break;
        }
    }
}