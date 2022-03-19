public static class GetColor
{
    public static ConsoleColor GetColorByName(string name) => name.ToLower().Trim() switch
    {
        "red" => ConsoleColor.Red,
        "blue" => ConsoleColor.Blue,
        "green" => ConsoleColor.Green,
        "pink" => ConsoleColor.Magenta,
        "yellow" => ConsoleColor.Yellow,
        _ => ConsoleColor.White
    };
}