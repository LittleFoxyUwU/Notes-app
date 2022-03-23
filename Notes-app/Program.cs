Console.Title = "Notes";
NoteSerialization.DeserializeNotes();
FancyPrint.Print("\nPrint info to get help!\n<Command>:<args> or just <Command> if it doesn't have \n", ConsoleColor.Green);
FancyPrint.Print("IF YOU EXIT PROGRAM USING ANYTHING ELSE EXCEPT COMMAND exit DATA WON'T BE SAVED\n", ConsoleColor.Red);
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