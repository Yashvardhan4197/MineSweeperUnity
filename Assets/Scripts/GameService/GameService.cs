
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
    //DATA
    [SerializeField] GameObject gridPrefab;
    [SerializeField] GameObject boardPrefab;
    [SerializeField] GameObject boardHolder;
    [SerializeField] Transform startPos;
    [SerializeField] int boardRows;
    [SerializeField] int boardCols;
    [SerializeField] float spacing;
    [SerializeField] float padding;
    [SerializeField] int bombNumber;

    //VIEWS
    [SerializeField] LobbyView lobbyView;

    //Services
    private BoardManager boardManager;
    private UIService uIService;
    public BoardManager BoardManager {  get { return boardManager; } }
    public UIService UIService { get { return uIService; } }


    private void Init()
    {
        boardManager=new BoardManager(boardPrefab,gridPrefab,boardHolder,startPos,padding);
        uIService= new UIService(lobbyView);
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
