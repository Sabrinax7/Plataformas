using UnityEngine;

public class Door : MonoBehaviour
{
    public string buttonID;

    private void OnEnable()
    {
        StaticEventChannel.OnButtonPressed += CheckButton;
    }

    private void OnDisable()
    {
        StaticEventChannel.OnButtonPressed -= CheckButton;
    }

    private void CheckButton(string id)
    {
        if (id == buttonID)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        gameObject.SetActive(false); // Simula abrir a porta
    }
}