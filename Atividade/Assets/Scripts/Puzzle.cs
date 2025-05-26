using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public int correctIndex;
    public int currentIndex;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            PuzzleManager.Instance.OnPieceClicked(this);
        });
    }

    public static void Swap(Puzzle a, Puzzle b)
    {
        int idxA = a.transform.GetSiblingIndex();
        int idxB = b.transform.GetSiblingIndex();

        a.transform.SetSiblingIndex(idxB);
        b.transform.SetSiblingIndex(idxA);

        int temp = a.currentIndex;
        a.currentIndex = b.currentIndex;
        b.currentIndex = temp;
    }

    public bool IsCorrect()
    {
        return currentIndex == correctIndex;
    }
}