using Microsoft.VisualBasic;

public static class NoteManager
{
    public static ConsoleColor PrefColor = Console.ForegroundColor;
    public static List<Note> Notes = new(100);
    
    public static void ExecuteCommand(string command, string[]? args = null)
    {
        int id = 0;
        switch (command)
        {
            case "info":
                FancyPrint.Print("note: <text>\tcolornote: <color> <text>\tdisplay: Optional(<ID>)\n" +
                                 "delete: <ID>\tcolor: <color>\t exit", ConsoleColor.Green);
                break;
            
            case "note":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Argument \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }
                
                if (Notes.Count == 0)
                    id = 1;
                else
                    id = Notes.Last().Id + 1;
                Notes.Add(new Note(id, string.Join(' ', args), PrefColor)); break;
            
            case "colornote":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Arguments \"Color\" and \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }

                if (args.Length < 2)
                {
                    FancyPrint.Print("ERROR: Either argument \"Color\" or \"Text\" is missing!", ConsoleColor.Red);
                    break;
                }
                if (Notes.Count == 0)
                    id = 1;
                else
                    id = Notes.Last().Id + 1;
                Notes.Add(new Note(id, string.Join(' ', args[1..]), GetColorByName(args[0])));
                break;
                
            case "display":
                if (args != null)
                {
                    Note note = Notes.First(x => x.Id == int.Parse(args[0]));
                    FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", note.Color);
                    break;
                }
                foreach (Note note in Notes)
                    FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", note.Color);
                break;

            case "delete":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Argument \"ID\" not found!", ConsoleColor.Red);
                    break;
                }
                id = int.Parse(args[0]);
                Notes.Remove(Notes.Find(x => x.Id == id));
                ReorderTasks();
                break;
            
            case "exit": System.Environment.Exit(1); break;
            
            case "color":
                if (args == null)
                {
                    FancyPrint.Print("ERROR: Argument \"Color\" not found!", ConsoleColor.Red);
                    break;
                }

                PrefColor = GetColorByName(args[0].ToLower());
                break;
                
            default: FancyPrint.Print("ERROR: Invalid Command!", ConsoleColor.Red); break;
        }
    }

    private static void ReorderTasks()
    {
        for (int i = 0; i < Notes.Count; i++)
            Notes[i].Id = i + 1;
    }

    private static ConsoleColor GetColorByName(string name) => name.ToLower().Trim() switch
    {
        "red" => ConsoleColor.Red,
        "blue" => ConsoleColor.Blue,
        "green" => ConsoleColor.Green,
        "pink" => ConsoleColor.Magenta,
        _ => ConsoleColor.White
    };
}