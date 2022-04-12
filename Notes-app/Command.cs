public class Command
{
    public readonly Action Action;
    public readonly string Description;
    public readonly string Example;
    public Command(Action action, string description, string example)
    {
        Action = action;
        Description = description;
        Example = example;
    }
}