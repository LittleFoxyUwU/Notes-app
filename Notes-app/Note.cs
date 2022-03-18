public class Note
{
    public int Id;
    public string Text;
    public DateTime Time;
    public ConsoleColor Color;
    public Note(int id, string text, ConsoleColor color)
    {
        Id = id;
        Text = text;
        Time = DateTime.Now;
        Color = color; 
    }
}