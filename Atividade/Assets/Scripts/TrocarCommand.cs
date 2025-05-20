using UnityEngine;

public class TrocarCommand : ICommand
{
    public Puzzle pecaA, pecaB;

    public TrocarCommand(Puzzle a, Puzzle b)
    {
        pecaA = a;
        pecaB = b;
    }

    public void Execute()
    {
        Puzzle.Swap(pecaA, pecaB);
    }

    public void Undo()
    {
        Puzzle.Swap(pecaA, pecaB); 
    }
}
