
using UnityEngine;

public class GameService : MonoBehaviour
{
    private static GameService instance;
    public static GameService Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] GameObject gridPrefab;
    [SerializeField] GameObject boardPrefab;
    [SerializeField] Transform startPos;


    [SerializeField] int boardRows;
    [SerializeField] int boardCols;
    [SerializeField] float spacing;
    [SerializeField] float padding;
    [SerializeField] int bombNumber;

    private BoardManager boardManager;
    public BoardManager BoardManager {  get { return boardManager; } }


    private void Init()
    {
        boardManager=new BoardManager(boardPrefab,gridPrefab,startPos,padding);
        StartGame();
    }
    public void StartGame()
    {
        boardManager.StartGame(bombNumber,boardRows,boardCols);
    }

    public void EndGame()
    {
        
    }
}
