using System;
using UnityEngine;

public class StaticEventChannel
{
    public static Action<string> OnButtonPressed;

    public static void RaiseButtonPressed(string buttonID)
    {
        OnButtonPressed?.Invoke(buttonID);
    }
}
