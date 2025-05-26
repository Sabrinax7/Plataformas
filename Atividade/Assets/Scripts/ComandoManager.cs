using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandoManager
{
    private Stack<ICommand> history = new Stack<ICommand>();
    private List<ICommand> replayList = new List<ICommand>();

    public void ExecuteCommand(ICommand cmd)
    {
        cmd.Execute();
        history.Push(cmd);
        replayList.Add(cmd);
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            ICommand last = history.Pop();
            last.Undo();
        }
    }

    public IEnumerator Replay(System.Action onFinish)
    {
        foreach (var cmd in replayList)
        {
            cmd.Execute();
            yield return new WaitForSeconds(1f);
        }
        onFinish?.Invoke();
    }

    public void SkipReplay(System.Action onFinish)
    {
        foreach (var cmd in replayList)
        {
            cmd.Execute();
        }
        onFinish?.Invoke();
    }

    public void Reset()
    {
        history.Clear();
        replayList.Clear();
    }
}