namespace Commands;
public static class NoteCommands
{
    public static void Display()
    {
        if (NoteManager.Notes.Count == 0) return;
        FancyPrint.Print("=====================================", ConsoleColor.Blue);
        foreach (Note note in NoteManager.Notes)
            FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", GetColor.GetColorByName(note.Color));
        FancyPrint.Print("=====================================", ConsoleColor.Blue);
    }

    public static void Display(int id)
    {
        Note note = NoteManager.Notes.First(x => x.Id == id);
        FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", GetColor.GetColorByName(note.Color));
    }

    public static void AddColorNote(string color, string text)
    {
        int id;
        if (NoteManager.Notes.Count == 0)
            id = 1;
        else
            id = NoteManager.Notes.Last().Id + 1;
        Note note = new Note(id, text, color);
        BackUpNotes();
        NoteManager.Notes.Add(note);
    }

    public static void AddNote(string text) => AddColorNote(NoteManager.PrefColor, text);

    public static void Delete(int id)
    {
        BackUpNotes();
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

    public static void BackUpNotes() => NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);

}