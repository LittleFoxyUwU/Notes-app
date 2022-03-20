Console.Title = "Notes";
Console.ForegroundColor = ConsoleColor.Black;
NoteSerialization.DeserializeNotes();
FancyPrint.Print("Print info to get help!\n<Command>:<args> or just <Command> if it doesn't have args", ConsoleColor.Green);
FancyPrint.Print("IF YOU EXIT PROGRAM USING ANYTHING ELSE EXCEPT COMMAND exit DATA WON'T BE SAVED", ConsoleColor.Red);
while (true)
{
    List<string> input = Console.ReadLine()!.Split(':').ToList();
    string command = input[0].ToLower().Trim();
    input.RemoveAt(0);
    if (input.Count == 0)
        NoteManager.ExecuteCommand(command);
    else if (!string.IsNullOrWhiteSpace(input[0]))
        NoteManager.ExecuteCommand(command, input[0].Split().SkipWhile(string.IsNullOrWhiteSpace).ToArray());
}