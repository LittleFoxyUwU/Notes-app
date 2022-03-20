using System.Text.Json;
namespace Commands;
public static class NoteCommands
{
    public static void Display()
    {
        if (NoteManager.Notes.Count == 0) return;
        FancyPrint.Print("==============================", ConsoleColor.Blue);
        foreach (Note note in NoteManager.Notes)
            FancyPrint.Print($"[{note.Time:g}] {note.Id}: {note.Text}", GetColor.GetColorByName(note.Color));
        FancyPrint.Print("==============================", ConsoleColor.Blue);
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
        NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);
        NoteManager.Notes.Add(note);
    }

    public static void AddNote(string text) => AddColorNote(NoteManager.PrefColor, text);

    public static void Delete(int id)
    {
        NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);
        NoteManager.Notes.Remove(NoteManager.Notes.Find(x => x.Id == id)!);
        ReorderNotes();
    }

    public static void DeleteAll()
    {
        NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);
        NoteManager.Notes = new List<Note>(100);
    }

    public static void Change(int id, string newText)
    {
        NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);
        NoteManager.Notes.First(x => x.Id == id).Text = newText;
    }
    
    private static void ReorderNotes()
    {
        NoteManager.BackupNotes = new List<Note>(NoteManager.Notes);
        for (int i = 0; i < NoteManager.Notes.Count; i++)
            NoteManager.Notes[i].Id = i + 1;
    }

    public static void Undo()
    {
        if (NoteManager.BackupNotes == null)
        {
            FancyPrint.Print("Nothing to undo!", ConsoleColor.Yellow);
            return;
        }
        NoteManager.Notes = new List<Note>(NoteManager.BackupNotes);
    }
}