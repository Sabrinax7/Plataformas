using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnStartClicked()
    {
        GameManager.Instance.LoadGameAndGUI();
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}