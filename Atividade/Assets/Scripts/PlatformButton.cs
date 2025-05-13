using UnityEngine;

public class  PlatformButton : MonoBehaviour
{
    public string buttonID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StaticEventChannel.RaiseButtonPressed(buttonID);
        }
    }
}
