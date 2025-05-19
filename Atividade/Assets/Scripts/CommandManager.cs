using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager
{
    public List<ICommand> commands;

    public CommandManager()
    {
        commands = new List<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void DoCommand()
    {
        commands[^1].Do();
    }

    public void UndoCommand()
    {
        ICommand command = commands[^1];
        commands.RemoveAt(commands.Count - 1);
        command.Undo();
    }
}
