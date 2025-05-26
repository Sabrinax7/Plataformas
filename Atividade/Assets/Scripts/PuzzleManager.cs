using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public Transform grid;
    public GameObject piecePrefab;
    public Sprite[] slicedSprites;

    public GameObject victoryPanel;
    public Button undoButton, replayButton, cancelReplayButton, restartButton;

    private Puzzle selected;
    private List<Puzzle> pieces = new List<Puzzle>();
    private ComandoManager invoker = new ComandoManager();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetupPuzzle();
        Shuffle();

        undoButton.onClick.AddListener(() => invoker.Undo());
        replayButton.onClick.AddListener(() => StartCoroutine(invoker.Replay(OnVictory)));
        cancelReplayButton.onClick.AddListener(() => invoker.SkipReplay(OnVictory));
        restartButton.onClick.AddListener(Restart);
    }

    void SetupPuzzle()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject obj = Instantiate(piecePrefab, grid);
            Puzzle piece = obj.GetComponent<Puzzle>();
            piece.correctIndex = i;
            piece.currentIndex = i;
            obj.GetComponent<Image>().sprite = slicedSprites[i];
            pieces.Add(piece);
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            int j = Random.Range(0, pieces.Count);
            Puzzle.Swap(pieces[i], pieces[j]);
        }
        invoker.Reset();
    }

    public void OnPieceClicked(Puzzle clicked)
    {
        if (selected == null)
        {
            selected = clicked;
        }
        else
        {
            if (selected != clicked)
            {
                var cmd = new TrocarCommand(selected, clicked);
                invoker.ExecuteCommand(cmd);
                CheckVictory();
            }
            selected = null;
        }
    }

    void CheckVictory()
    {
        foreach (var piece in pieces)
        {
            if (!piece.IsCorrect()) return;
        }
        OnVictory();
    }

    void OnVictory()
    {
        victoryPanel.SetActive(true);
    }

    void Restart()
    {
        foreach (Transform child in grid)
            Destroy(child.gameObject);

        pieces.Clear();
        victoryPanel.SetActive(false);
        SetupPuzzle();
        Shuffle();
    }
}
