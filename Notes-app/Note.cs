public class Note
{
    public int Id{ get; set; }
    public string Text{ get; set; }
    public DateTime Time { get; set; }
    public string Color { get; set; }

    public Note()
    {
        Id = 0;
        Text = "None";
        Time = DateTime.Now;
        Color = "black";
    }
    
    public Note(int id, string text, string color)
    {
        Id = id;
        Text = text;
        Time = DateTime.Now;
        Color = color; 
    }
}