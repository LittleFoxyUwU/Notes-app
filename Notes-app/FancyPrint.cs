public static class FancyPrint
{
    /// <summary> Prints colored text</summary>
    public static void Print(string s, ConsoleColor color)
    {
        var lastColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(s);
        Console.ForegroundColor = lastColor;
    }
    public static void Print(string s) => Print(s, ConsoleColor.White);

    public static void Print(string s, string color) => Print(s, GetColor.GetColorByName(color));
}