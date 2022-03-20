using System.Text.Json;

public static class NoteSerialization
{
    private static readonly JsonSerializerOptions Options = new() {WriteIndented = true};
    public static void SerializeNotes()
    {
        using (FileStream fs = new FileStream("Data.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, NoteManager.Notes, Options);
            FancyPrint.Print($"{NoteManager.Notes.Count} notes were saved in Data.json!", ConsoleColor.Yellow);
        }
    }

    public static void DeserializeNotes()
    {
        try
        {
            if (!File.Exists("Data.json")) return;
            using (var s = new StreamReader("Data.json"))
            {
                NoteManager.Notes = new (JsonSerializer.Deserialize<List<Note>>(s.BaseStream)!);
                FancyPrint.Print($"{NoteManager.Notes.Count} notes were loaded from Data.json!", ConsoleColor.Yellow);
            }
        }
        catch 
        {
            FancyPrint.Print("Can't load from Data.json");
        }
    }
}