
public static class FancyPrint
{
    public static void Print(string s, ConsoleColor color)
    {
        var lastColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(s);
        Console.ForegroundColor = lastColor;
    }
}