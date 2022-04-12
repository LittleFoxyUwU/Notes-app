namespace Commands;
public static class NoteCommands
{
    public static void Display(string[]? args)
    {
        if (args != null)
        {
            try
            {
                Display(Int32.Parse(args[0]));
                return;
            }
            catch
            {
                FancyPrint.Error("Can't parse args to a number!");
                return;
            }
        }

        if (NoteManager.Notes.Count == 0)
        {
            FancyPrint.Error("Nothing to display! Create your first note using 'note: <text>'");
            return;
        }
        FancyPrint.Print("=====================================", ConsoleColor.Blue);
        foreach (Note note in NoteManager.Notes)
            FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", GetColor.GetColorByName(note.Color));
        FancyPrint.Print("=====================================", ConsoleColor.Blue);
    }

    private static void Display(int id)
    {
        Note note = NoteManager.Notes.First(x => x.Id == id);
        FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", GetColor.GetColorByName(note.Color));
    }

    public static void AddColorNote(string[]? args)
    {
        if (args!.Length < 2)
        {
            FancyPrint.Error("ERROR: Either argument \"Color\" or \"Text\" is missing!");
            return;
        }
        int id;
        if (NoteManager.Notes.Count == 0)
            id = 1;
        else
            id = NoteManager.Notes.Last().Id + 1;
        Note note = new Note(id, args[1], args[0]);
        BackUpNotes();
        NoteManager.Notes.Add(note);
    }

    public static void AddNote(string text) => AddColorNote(new[]{NoteManager.PrefColor, text});

    public static void Delete(string[]? args)
    {
        if (args == null)
        {
            NoteManager.Notes.Remove(NoteManager.Notes.Last());
            return;
        }

        int id;
        BackUpNotes();
        try
        {
            id = Int32.Parse(args[0]);
        }
        catch 
        {
            FancyPrint.Error("Can't parse args to a number!");
            return;
        }

        if (NoteManager.Notes.Find(x => x.Id == id) is null)
        {
            FancyPrint.Error($"Note with id {id} wasn't found!");
            return;
        }
        NoteManager.Notes.Remove(NoteManager.Notes.Find(x => x.Id == id)!);
        ReorderNotes();
    }

    public static void DeleteAll()
    {
        BackUpNotes();
        NoteManager.Notes = new List<Note>(100);
    }

    public static void ChangeText(int id, string newText)
    {
        BackUpNotes();
        NoteManager.Notes.First(x => x.Id == id).Text = newText;
        NoteManager.Notes.First(x => x.Id == id).Time = DateTime.Now;
    }

    public static void ChangeColor(int id, string color)
    {
        BackUpNotes();
        NoteManager.Notes.First(x => x.Id == id).Color = color;
    }
    
    private static void ReorderNotes()
    {
        BackUpNotes();
        for (int i = 0; i < NoteManager.Notes.Count; i++)
            NoteManager.Notes[i].Id = i + 1;
    }

    private static void BackUpNotes() => NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);

}