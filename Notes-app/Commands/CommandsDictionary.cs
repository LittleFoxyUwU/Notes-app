namespace Commands;

public static class CommandsDictionary
{
    public static string[]? Arguments;
    public static readonly IDictionary<string, Command> Commands = new Dictionary<string, Command>()
    {
        {"info", new Command(BasicCommands.Info, "Displays information about commands", "info")},
        
        {"undo", new Command(BasicCommands.Undo, "Undoes the last change to notes", "undo")},
        
        {"exit", new Command(BasicCommands.Exit, "Exits and saves all notes", "exit")},
        
        {"save", new Command(NoteSerialization.SerializeNotes, "Saves all notes", "save")},
        
        {"note", new Command(() => NoteCommands.AddNote(string.Join(' ', Arguments!)),
            "Creates a new note with following text", "note: <text>")},
        
        {"color-note", new Command(() => NoteCommands.AddColorNote(Arguments),
            "Creates a new note with selected color", "color-note: <color> <text>")},
        
        {"display", new Command(() => NoteCommands.Display(Arguments),
            "Displays all notes, or a single note by id", "display: [id]")},
        
        {"delete", new Command(() => NoteCommands.Delete(Arguments),
            "Deletes note with the following id", "delete: <id>")},
        
        {"delete-all", new Command(NoteCommands.DeleteAll, "Deletes all notes!", "delete-all")},
        
        {"color", new Command(() => BasicCommands.Color(Arguments), "Changes default color", "color: <color>")}
    };
}