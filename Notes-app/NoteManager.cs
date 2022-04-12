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
    
    public static void LegacyCommand(string command, string[]? args = null)
    {
        switch (command)
        {

            case "changetext":
                if (args!.Length < 2)
                {
                    FancyPrint.Error(" Either argument \"Id\" or \"Text\" is missing!");
                    break;
                }
                NoteCommands.ChangeText(int.Parse(args[0]), string.Join(' ', args[1..]));
                break;
            
            case "changecolor":
                if (args!.Length < 2)
                {
                    FancyPrint.Print("ERROR: Either argument \"Id\" or \"Color\" is missing!", ConsoleColor.Red);
                    break;
                }
                NoteCommands.ChangeColor(int.Parse(args[0]), args[1]);
                break;

            default: FancyPrint.Print("ERROR: Invalid Command!", ConsoleColor.Red); break;
        }
    }
}