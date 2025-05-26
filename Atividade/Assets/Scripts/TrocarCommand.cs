public class TrocarCommand : ICommand
{
    private Puzzle a, b;

    public TrocarCommand(Puzzle a, Puzzle b)
    {
        this.a = a;
        this.b = b;
    }

    public void Execute()
    {
        Puzzle.Swap(a, b);
    }

    public void Undo()
    {
        Puzzle.Swap(a, b); // trocar de novo desfaz
    }
}