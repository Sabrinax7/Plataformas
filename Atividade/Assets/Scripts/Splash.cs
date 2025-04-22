using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f); 
        GameManager.Instance.LoadScene("MainMenu");
    }
}
