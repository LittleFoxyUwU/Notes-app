Console.Title = "Notes";
FancyPrint.Print("Print info to get help!\n<Command>:<args> or just <Command> if it doesn't have args", ConsoleColor.Green);
while (true)
{
    List<string> input = Console.ReadLine()!.Split(':').ToList();
    string command = input[0].ToLower();
    input.RemoveAt(0);
    if (input.Count == 0)
        NoteManager.ExecuteCommand(command);
    else
        NoteManager.ExecuteCommand(command, input[0].Split().SkipWhile(string.IsNullOrWhiteSpace).ToArray());
}