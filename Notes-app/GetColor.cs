public static class GetColor
{
    /// <summary>Gets ConsoleColor with given name</summary>
    public static ConsoleColor GetColorByName(string name) => name.ToLower().Trim() switch
    {
        "red" => ConsoleColor.Red,
        "blue" => ConsoleColor.Blue,
        "green" => ConsoleColor.Green,
        "pink" or "magenta" => ConsoleColor.Magenta,
        "yellow" => ConsoleColor.Yellow,
        "white" or "light" => ConsoleColor.White,
        "black" or "dark" => ConsoleColor.Black,
        "cyan" => ConsoleColor.Cyan,
        "gray" => ConsoleColor.Gray,
        _ => ConsoleColor.White
    };
}