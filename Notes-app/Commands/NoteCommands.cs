namespace Commands;
using Newtonsoft.Json;
public static class NoteCommands
{
    public static void Display()
    {
        foreach (Note note in NoteManager.Notes)
            FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", note.Color);
    }

    public static void Display(int id)
    {
        Note note = NoteManager.Notes.First(x => x.Id == id);
        FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", note.Color);
    }

    public static void AddColorNote(ConsoleColor color, string text)
    {
        int id;
        if (NoteManager.Notes.Count == 0)
            id = 1;
        else
            id = NoteManager.Notes.Last().Id + 1;
        Note note = new Note(id, text, color);
        NoteManager.Notes.Add(note);
    }

    public static void AddNote(string text) => AddColorNote(NoteManager.PrefColor, text);

    public static void Delete(int id)
    {
        NoteManager.Notes.Remove(NoteManager.Notes.Find(x => x.Id == id)!);
        ReorderNotes();
    }
    
    private static void ReorderNotes()
    {
        for (int i = 0; i < NoteManager.Notes.Count; i++)
            NoteManager.Notes[i].Id = i + 1;
    }
}